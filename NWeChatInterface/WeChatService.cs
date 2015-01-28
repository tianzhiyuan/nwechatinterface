using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using NWeChatInterface.Requests;
using NWeChatInterface.Response;
using Newtonsoft.Json;
using Tencent;

namespace NWeChatInterface
{
    /// <summary>
    /// 微信公众平台接口服务
    /// </summary>
    public class WeChatService : IWeChatService
    {
        private readonly JsonSerializer _serializer;

        public WeChatService()
        {
            _serializer = new JsonSerializer()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                };
        }

        private int _timeOut = 10;

        /// <summary>
        /// 请求超时时间，单位秒。默认10s
        /// </summary>
        public int TimeOutSeconds
        {
            get { return this._timeOut; }
            set { _timeOut = value; }
        }
        TData DoRequest<TData>(WebRequest request, IWeChatRequest from)
            where TData : AbstractResponse
        {
            using (var response = request.GetResponse())
            using (var stream = new StreamReader(response.GetResponseStream()))
            {
                var text = stream.ReadToEnd();
                using (var reader = new JsonTextReader(new StringReader(text)))
                {
                    return this._serializer.Deserialize<TData>(reader);
                }
            }

        }

       
		public TResponse Execute<TResponse>(IWeChatRequest<TResponse> request) where TResponse : AbstractResponse
		{
			string baseUrl = "https://api.weixin.qq.com";
			var requestType = request.GetType();
			var requestPathAttribute = (RequestPath) requestType.GetCustomAttributes(typeof (RequestPath), true)[0];
			var requestMethod = (RequestMethod) requestType.GetCustomAttributes(typeof (RequestMethod), true)[0];
			var uri = new UriBuilder(baseUrl) {Path = requestPathAttribute.Path, Query = request.Param};
			var url = uri.ToString();
			if (requestPathAttribute.IsFull)
			{
				url = new UriBuilder(requestPathAttribute.Path) {Query = request.Param}.Uri.AbsolutePath;
			}
			var httpRequest = WebRequest.Create(url);
			httpRequest.Method = requestMethod.Method;
			httpRequest.ContentType = "application/json";
			string requestData = request.Data;
			if (!string.IsNullOrWhiteSpace(requestData))
			{
				var bytes = Encoding.UTF8.GetBytes(requestData);
				httpRequest.ContentLength = bytes.Length;
				using (var stream = httpRequest.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
				}
			}
			var response = DoRequest<TResponse>(httpRequest, request);
			return response;
		}

        public UploadResponse Execute(UploadMedia request)
        {
            
            string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(request.Param);
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
            var result = DoRequest<UploadResponse>(httpWebRequest, request);
            return result;


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
            var list = new string[] { nonce, timestamp, token };
            Array.Sort(list);
            using (var algo = HashAlgorithm.Create("SHA1"))
            {
                var byteArray = algo.ComputeHash(Encoding.UTF8.GetBytes(string.Join("", list)));
                var result = BitConverter.ToString(byteArray).Replace("-", "");
                return System.String.Compare(result, signature, System.StringComparison.OrdinalIgnoreCase) == 0;
            }
        }

        public WeChatBaseMsg Parse(string data)
        {
            return WeChatBaseMsg.LoadFrom(data);
        }

	    public WeChatBaseMsg ParseEncrypt(string encryptData, string timestamp, string nonce, string signature, string accessToken,
	                                      string appId, string aesKey)
	    {
		    var wxMsgCrypt = new WXBizMsgCrypt(accessToken, aesKey, appId);
		    string decryptMsg = "";
		    int code = wxMsgCrypt.DecryptMsg(signature, timestamp, nonce, encryptData, ref decryptMsg);
			if (code == 0)
			{
				return this.Parse(decryptMsg);
			}
		    throw new Exception(string.Format("识别加密消息串发生错误，错误码{0}", code));
	    }

	    

	    #region IWeChatService Members
        TResponse IWeChatService.Execute<TResponse>(IWeChatRequest<TResponse> request)
        {
            var media = request as UploadMedia;
            if (media != null)
            {
                return this.Execute(media) as TResponse;
            }
            return this.Execute(request);
        }
        bool IWeChatService.VerifySignature(string nonce, string timestamp, string token, string signature)
        {
            return this.VerifySignature(nonce, timestamp, token, signature);
        }
        WeChatBaseMsg IWeChatService.Parse(string data)
        {
            return this.Parse(data);
        }
        #endregion



    }
}
