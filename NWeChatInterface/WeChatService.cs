using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using NWeChatInterface.Requests;
using NWeChatInterface.Response;
using Newtonsoft.Json;

namespace NWeChatInterface
{
    /// <summary>
    /// 微信公众平台接口服务
    /// </summary>
    public class WeChatService
    {
        private JsonSerializer _serializer;
        
        public WeChatService()
        {
            _serializer = new JsonSerializer()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                };
        }
        

        TData DoRequest<TData>(WebRequest request, IWeChatRequest from)
            where TData : IResponse
        {
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new JsonTextReader(new StreamReader(stream)))
            {
                var obj = _serializer.Deserialize<TData>(reader);
                if (obj.errcode != 0)
                {
                    throw new WeChatRequestException(obj.errcode, from);
                }
                return obj;
            }
        }

        public TResult Get<TResult>(IGetRequest<TResult> request) where TResult : class ,IResponse
        {
            var url = request.RequestUrl;
            var req = WebRequest.Create(url);
            req.Method = "GET";
            var data = DoRequest<TResult>(req, request);
            return data;
        }

        public TResult Get<TResult>(IPostRequest<TResult> request) where TResult : class, IResponse
        {
            var url = request.RequestUrl;
            var req = WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/json";
            var requestData = request.Data;
            if (!string.IsNullOrEmpty(requestData))
            {
                var bytes = Encoding.UTF8.GetBytes(requestData);
                req.ContentLength = bytes.Length;
                using (var stream = req.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            
            var data = DoRequest<TResult>(req, request);
            return data;
        }

        public UploadMediaResponse UploadMedia(UploadMedia request)
        {
            //var b = "----------------------------" + DateTime.Now.Ticks.ToString("x");
            //using (var client = new HttpClient())
            //using (var formData = new MultipartFormDataContent())
            //{
                
            //    var bytes = new ByteArrayContent(request.Content);
            //    //formData.Headers.Remove("Content-Type");
            //    //formData.Headers.TryAddWithoutValidation("Contenty-Type", "multipart/form-data; boundary=" + b);
            //    bytes.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
            //    bytes.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            //        {
            //            Name = "\"file\"",
            //            FileName = "\"" + request.FileName + "\""
            //        };
            //    formData.Add(bytes, "file", request.FileName);
            //    var response = client.PostAsync(request.RequestUrl, formData).Result;
            //    if (!response.IsSuccessStatusCode)
            //    {
            //        throw new Exception("Remote server failed");
            //    }
            //    using (var reader = new JsonTextReader(new StreamReader(response.Content.ReadAsStreamAsync().Result)))
            //    {
            //        var obj = _serializer.Deserialize<UploadMediaResult>(reader);
            //        if (obj.errcode != 0)
            //        {
            //            throw new WeChatRequestException(obj.errcode, request);
            //        }
            //        return obj;
            //    }
            //}
            string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(request.RequestUrl);
            httpWebRequest.ContentType = "multipart/form-data; boundary=" + boundary;
            httpWebRequest.Method = "POST";
            httpWebRequest.KeepAlive = true;
            httpWebRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
            Stream memStream = new System.IO.MemoryStream();
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            memStream.Write(boundarybytes, 0, boundarybytes.Length);
            string header =
                string.Format(
                    "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n Content-Type: application/octet-stream\r\n\r\n",
                    "file", request.FileName);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            memStream.Write(headerbytes, 0, headerbytes.Length);
            memStream.Write(request.Content, 0, request.ContentLength);
            memStream.Write(boundarybytes, 0, boundarybytes.Length);


            memStream.Position = 0;
            byte[] tempBuffer = new byte[memStream.Length];
            memStream.Read(tempBuffer, 0, tempBuffer.Length);
            httpWebRequest.ContentLength = memStream.Length;
            memStream.Close();
            var requestStream = httpWebRequest.GetRequestStream();
            requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            var result = DoRequest<UploadMediaResponse>(httpWebRequest, request);
            return result;
            
            
        }

        /// <summary>
        /// 发送客服消息
        /// </summary>
        /// <param name="message">待发送的客服消息</param>
        /// <param name="accessToken">AccessToken</param>
        public void SendCustomerServiceMessage(CustomerServiceMessage message, string accessToken)
        {
            var targetUrl = string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}",
                                          accessToken);
            var request = WebRequest.Create(targetUrl);
            request.Method = "POST";
            request.ContentType = "application/json";
            var data = JsonConvert.SerializeObject(message, new JsonSerializerSettings() {});
            var bytes = Encoding.UTF8.GetBytes(data);
            request.ContentLength = bytes.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }
            using (var response = request.GetResponse())
            using (var stream = new StreamReader(response.GetResponseStream()))
            {
                var result = stream.ReadToEnd();
            }
        }

        /// <summary>
        /// 验证消息真实性
        /// </summary>
        /// <param name="nonce">随机数</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="token">微信公众号配置的Token</param>
        /// <param name="signature">签名</param>
        /// <returns>是否匹配</returns>
        public bool VerifySignature(string nonce, string timestamp, string token, string signature)
        {
            var list = new string[] {nonce, timestamp, token};
            Array.Sort(list);
            using (var algo = HashAlgorithm.Create("SHA1"))
            {
                var byteArray = algo.ComputeHash(Encoding.UTF8.GetBytes(string.Join("",list)));
                var result = BitConverter.ToString(byteArray).Replace("-", "");
                return result == signature;
            }
        }
    }
}
