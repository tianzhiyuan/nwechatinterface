﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace NWeChatPay
{
    /// <summary>
    /// 微信支付辅助类
    /// </summary>
    public class WeChatPayHelper
    {
        private int _timeOut = 10;

        /// <summary>
        /// 请求超时时间，单位秒。默认10s
        /// </summary>
        public int TimeOut
        {
            get { return this._timeOut; }
            set { _timeOut = value; }
        }

        /// <summary>
        /// 获取微信版本号
        /// </summary>
        /// <param name="useragent">User Agent</param>
        /// <returns>微信版本，如5.0</returns>
        public static string GetWeChatVersion(string useragent)
        {
            if (!string.IsNullOrWhiteSpace(useragent) && useragent.Contains("MicroMessenger/"))
            {
                var version = useragent.Substring(useragent.IndexOf("MicroMessenger/") + "MicroMessenger/".Length);
                return version;
            }
            return string.Empty;
        }
        /// <summary>
        /// 判断是否能够使用微信支付
        /// 微信版本必须大于5.0 才能使用微信支付
        /// </summary>
        /// <param name="useragent">User Agent</param>
        /// <returns>True，能使用</returns>
        public static bool TenpaySupported(string useragent)
        {
            var version = GetWeChatVersion(useragent);
            if (string.IsNullOrWhiteSpace(version)) return false;
            var major = version[0] + "";
            int v;
            if (int.TryParse(major, out v))
            {
                if (v >= 5) return true;
            }
            return false;
        }
        /// <summary>
        /// 生成JS支付请求参数
        /// </summary>
        /// <returns>JS请求参数，是一个Json对象</returns>
        public string CreateJSApiParam(JSApiParam param)
        {
            param.Validate();
            if (string.IsNullOrWhiteSpace(param.Charset))
            {
                param.Charset = JSApiParam.UTF8;
            }
            if (string.IsNullOrWhiteSpace(param.NonceStr))
            {
                param.NonceStr = CreateNonce();
            }
            
            var parameters = new Dictionary<string, string>();
            parameters.Add("appId", param.AppId);
            parameters.Add("package", CreatePackage(param));
            parameters.Add("timeStamp", Epoch.ConvertToEpoch(param.TimeStamp).ToString());
            parameters.Add("nonceStr", param.NonceStr);
            parameters.Add("paySign", CreatePaySign(parameters, param.AppKey));
            parameters.Add("signType", "SHA1");
            return DictionaryToJson(parameters);
        }
        /// <summary>
        /// 生成Native原生支付Url
        /// </summary>
        /// <param name="param"></param>
        public string CreateNativePayUrl(NativePayParam param)
        {
            
            if (string.IsNullOrWhiteSpace(param.NonceStr))
            {
                param.NonceStr = CreateNonce();
            }
            var parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("appid", param.AppId));
            parameters.Add(new KeyValuePair<string, string>("timestamp", Epoch.ConvertToEpoch(param.TimeStamp).ToString()));
            parameters.Add(new KeyValuePair<string, string>("noncestr", param.NonceStr));
            parameters.Add(new KeyValuePair<string, string>("productid", param.ProductId));
            var sign = CreatePaySign(parameters, param.AppKey);
            parameters.Add(new KeyValuePair<string, string>("sign", sign));
            var dic = parameters.ToDictionary(p => p.Key, p => p.Value);
            var urlparam = string.Format("weixin://wxpay/bizpayurl?{0}", FormatUrlQuery(dic, false, ""));

            return urlparam;
        }
        /// <summary>
        /// 生成Native原生支付回调package
        /// </summary>
        /// <returns></returns>
        /*
		 * <xml> <AppId><![CDATA[wwwwb4f85f3a797777]]></AppId>
		 * <Package><![CDATA[a=1&url=http%3A%2F%2Fwww.qq.com]]></Package>
		 * <TimeStamp> 1369745073</TimeStamp>
		 * <NonceStr><![CDATA[iuytxA0cH6PyTAVISB28]]></NonceStr>
		 * <RetCode>0</RetCode> <RetErrMsg><![CDATA[ok]]></ RetErrMsg>
		 * <AppSignature><![CDATA[53cca9d47b883bd4a5c85a9300df3da0cb48565c]]>
		 * </AppSignature> <SignMethod><![CDATA[sha1]]></ SignMethod > </xml>
		 */
        public string CreateNativePackage(NativePackageParam param)
        {
            param.Validate();
            if (string.IsNullOrWhiteSpace(param.Charset))
            {
                param.Charset = JSApiParam.UTF8;
            }
            if (string.IsNullOrWhiteSpace(param.NonceStr))
            {
                param.NonceStr = CreateNonce();
            }
            
            var parameters = new Dictionary<string, string>();
            parameters.Add("AppId", param.AppId);
            parameters.Add("Package", CreatePackage(param));
            parameters.Add("TimeStamp", Epoch.ConvertToEpoch(param.TimeStamp).ToString());
            parameters.Add("NonceStr", param.NonceStr);
            parameters.Add("RetCode", param.RetCode);
            parameters.Add("RetErrMsg", param.RetErrMsg);
            parameters.Add("AppSignature", CreatePaySign(parameters, param.AppKey));
            parameters.Add("SignMethod", "sha1");
            return ToXml(parameters);
        }
        /// <summary>
        /// 生成收货地址共享请求Json参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string CreateAddressParam(AddressParam param)
        {
            if (string.IsNullOrWhiteSpace(param.NonceStr))
            {
                param.NonceStr = CreateNonce();
            }
            var parameters = new Dictionary<string, string>();
            parameters.Add("appId", param.AppId);
            parameters.Add("timeStamp", Epoch.ConvertToEpoch(param.TimeStamp).ToString());
            parameters.Add("nonceStr", param.NonceStr);
            parameters.Add("accessToken", param.AccessToken);
            parameters.Add("url", param.Url);
            var addrSign = Hash(FormatUrlQuery(parameters, false, ""), SHA1);
            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("appId", param.AppId));
            list.Add(new KeyValuePair<string, string>("scope", "jsapi_address"));
            list.Add(new KeyValuePair<string, string>("signType", "sha1"));
            list.Add(new KeyValuePair<string, string>("addrSign", addrSign));
            list.Add(new KeyValuePair<string, string>("timeStamp", Epoch.ConvertToEpoch(param.TimeStamp).ToString()));
            list.Add(new KeyValuePair<string, string>("nonceStr", param.NonceStr));
            return DictionaryToJson(list);
        }
        /// <summary>
        /// 发货通知
        /// </summary>
        public void SendDeliveryNotify(DeliveryNotifyParam param)
        {
            var url = string.Format(Resource.DeliverNotify_Url, param.AccessToken);
            var jsonParam = new List<KeyValuePair<string, string>>();
            jsonParam.Add(new KeyValuePair<string, string>("appid", param.AppId));
            jsonParam.Add(new KeyValuePair<string, string>("openid", param.OpenId));
            jsonParam.Add(new KeyValuePair<string, string>("transid", param.TransId));
            jsonParam.Add(new KeyValuePair<string, string>("out_trade_no", param.OutTradeNo));
            jsonParam.Add(new KeyValuePair<string, string>("deliver_timestamp",
                                                           Epoch.ConvertToEpoch(param.DeliverTimeStamp).ToString()));
            jsonParam.Add(new KeyValuePair<string, string>("deliver_status", param.DeliverStatus.ToString()));
            jsonParam.Add(new KeyValuePair<string, string>("deliver_msg", param.DeliveryMsg));
            jsonParam.Add(new KeyValuePair<string, string>("app_signature", CreatePaySign(jsonParam, param.AppKey)));
            jsonParam.Add(new KeyValuePair<string, string>("sign_method", "sha1"));
            var json = DictionaryToJson(jsonParam);
            try
            {
                var request = WebRequest.Create(url);
                request.Method = "POST";
                var postBytes = Encoding.UTF8.GetBytes(json);
                using (var writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(postBytes);
                }
                using (var response = request.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var body = reader.ReadToEnd();
                    var obj = JsonConvert.DeserializeObject<WeChatPayResponse>(body, new JsonSerializerSettings()
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                    if (obj.errcode != 0)
                    {
                        throw new WeChatPayException(obj.errmsg);
                    }
                }
            }
            catch (Exception error)
            {
                throw new WeChatPayException(Resource.NetworkError, error);
            }
        }

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <exception cref="WeChatPayException">请求失败或者网络错误</exception>
        public OrderInfo QueryOrder(OrderQuery query)
        {
            var url = string.Format(Resource.OrderQuery_Url, query.AccessToken);
            var packageParam = new Dictionary<string, string>();
            packageParam.Add("out_trade_no", query.OutTradeNo);
            packageParam.Add("partner", query.Partner);
            var sign = Hash(FormatUrlQuery(packageParam, false, "") + "&key=" + query.PartnerKey, MD5).ToUpper();
            packageParam.Add("sign", sign);
            var package = FormatUrlQuery(packageParam, false, "");
            var jsonParam = new List<KeyValuePair<string, string>>();
            jsonParam.Add(new KeyValuePair<string, string>("appid", query.AppId));
            jsonParam.Add(new KeyValuePair<string, string>("package", package));
            jsonParam.Add(new KeyValuePair<string, string>("timestamp", Epoch.ConvertToEpoch(query.TimeStamp).ToString()));
            jsonParam.Add(new KeyValuePair<string, string>("app_signature", CreatePaySign(jsonParam, query.AppKey)));
            jsonParam.Add(new KeyValuePair<string, string>("sign_method", "sha1"));
            var json = DictionaryToJson(jsonParam);
            try
            {
                var request = WebRequest.Create(url);
                request.Method = "POST";
                var postBytes = Encoding.UTF8.GetBytes(json);
                using (var writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(postBytes);
                }
                using (var response = request.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var body = reader.ReadToEnd();
                    var obj = JsonConvert.DeserializeObject<OrderResponse>(body, new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    if (obj.errcode != 0)
                    {
                        throw new WeChatPayException(obj.errmsg);
                    }
                    return obj.order_info;
                }
            }
            catch (Exception error)
            {
                throw new WeChatPayException(Resource.NetworkError, error);
            }
        }

        /// <summary>
        /// 解析用户维权请求对象
        /// </summary>
        /// <param name="input"></param>
        public PayFeedback ParsePayFeedback(Stream input)
        {
            var obj = (PayFeedback)_payFeedbackSerializer.Deserialize(input);
            return obj;
        }
        /// <summary>
        /// 解析用户维权请求对象
        /// </summary>
        /// <param name="xml"></param>
        public PayFeedback ParsePayFeedback(string xml)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            return ParsePayFeedback(stream);
        }
        /// <summary>
        /// 解析微信支付回调
        /// </summary>
        /// <param name="values"></param>
        /// <param name="appKey"></param>
        /// <returns></returns>
        public WeChatPayNotify ParsePayNotify(NameValueCollection values, string appKey)
        {
            if (values == null) return null;
            var notify = new WeChatPayNotify();
            notify.SignType = values["sign_type"];
            notify.Sign = values["sign"];
            notify.InputCharset = values["input_charset"];
            var dic = values.Keys.Cast<string>().ToDictionary(key => key, key => values[key]);
            var sign = CreatePaySign(dic, appKey, MD5);
            if (sign != notify.Sign) return null;
            int tradeMode;
            int.TryParse(values["trade_mode"], out tradeMode);
            notify.TradeMode = tradeMode;
            int tradeStatus;
            int.TryParse(values["trade_status"], out tradeStatus);
            notify.TradeStatus = tradeStatus;
            notify.Partner = values["partner"];
            notify.BankType = values["bank_type"];
            notify.BankBillNo = values["bank_billno"];
            notify.TotalFee = ((decimal) tryParseInt(values["total_fee"]))/100;
            notify.FeeType = tryParseInt(values["fee_type"]);
            notify.NotifyId = values["notify_id"];
            notify.TransactionId = values["transation_id"];
            notify.OutTradeNo = values["out_trade_no"];
            notify.Attach = values["attach"];
            DateTime dt;
            DateTime.TryParseExact(values["time_end"], "yyyyMMddhhmmss", null, DateTimeStyles.None, out dt);
            notify.TimeEnd = dt;
            notify.TransportFee = ((decimal) tryParseInt(values["transport_fee"]))/100;
            notify.ProductFee = ((decimal) tryParseInt(values["product_fee"]))/100;
            notify.Discount = ((decimal) tryParseInt(values["discount"]))/100;
            
            return notify;
        }
        
        /// <summary>
        /// 标记客户的投诉处理状态
        /// </summary>
        /// <param name="accessToken">AccessToken</param>
        /// <param name="feedbackId">客户投诉单号</param>
        /// <param name="userOpenId">客户OpenId</param>
        /// <exception cref="WeChatPayException">请求错误</exception>
        public WeChatPayResponse UpdateFeedback(string accessToken, string feedbackId, string userOpenId)
        {
            var url = string.Format(Resource.UpdateFeedback_Url, accessToken, userOpenId, feedbackId);
            var request = WebRequest.Create(url);
            request.Method = "POST";
            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var body = reader.ReadToEnd();
                var obj = JsonConvert.DeserializeObject<WeChatPayResponse>(body, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return obj;

            }
        }
        /// <summary>
        /// 发起微信退款请求
        /// </summary>
        public RefundResponse Refund(RefundRequest refund)
        {
            var queryDic = new Dictionary<string, string>();
            queryDic.Add("sign_type", refund.sign_type);
            queryDic.Add("input_charset", refund.input_charset);
            queryDic.Add("service_version", refund.service_version);
            if (refund.sign_key_index != null)
            {
                queryDic.Add("sign_key_index", refund.sign_key_index.Value.ToString());
            }
            queryDic.Add("partner", refund.partner);
            queryDic.Add("out_trade_no", refund.out_trade_no);
            queryDic.Add("transation_id", refund.transaction_id);
            queryDic.Add("out_refund_no", refund.out_refund_no);
            queryDic.Add("total_fee", refund.total_fee.ToString());
            queryDic.Add("refund_fee", refund.refund_fee.ToString());
            queryDic.Add("op_user_id", refund.op_user_id.ToString());
            if (refund.service_version == "1.1")
            {
                refund.op_user_password = Hash(refund.op_user_password, MD5);
            }
            queryDic.Add("op_user_password", refund.op_user_password);
            if (!string.IsNullOrWhiteSpace(refund.recv_user_id))
            {
                queryDic.Add("recv_user_id", refund.recv_user_id);
            }
            if (!string.IsNullOrWhiteSpace(refund.reccv_user_name))
            {
                queryDic.Add("reccv_user_name", refund.reccv_user_name);
            }
            if (refund.user_spbill_no_flag != null)
            {
                queryDic.Add("user_spbill_no_flag", refund.user_spbill_no_flag.Value.ToString());
            }
            if (refund.refund_type != null)
            {
                queryDic.Add("refund_type", refund.refund_type.Value.ToString());
            }
            var sign = Hash(FormatUrlQuery(queryDic, false, "") + "&key=" + refund.AppKey, refund.sign_type, refund.input_charset).ToUpper();
            queryDic.Add("sign", sign);
            var query = FormatUrlQuery(queryDic, true, refund.input_charset);
            var url = string.Format("https://mch.tenpay.com/refundapi/gateway/refund.xml?{0}", query);
            
            try
            {
                var request = (HttpWebRequest) WebRequest.Create(url);
                request.Timeout = this.TimeOut*1000;
                request.Method = "POST";
                using (var response = request.GetResponse())
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    var content = sr.ReadToEnd();
                    var parameters = XmlToDictionary(content);
                    var signParameters = parameters.Where(o => o.Key != "sign").ToDictionary(o => o.Key, o => o.Value);
                    var retSign = Hash(FormatUrlQuery(signParameters, false, "")+ "&key=" + refund.AppKey, MD5, parameters["sign_type"]).ToUpper();
                    if (retSign == parameters["sign"])
                    {
                        throw new Exception("sign error");
                    }
                    return MapResponse(parameters);
                }

            }
            catch (Exception ex)
            {
                
            }

            
            return null;
        }
        #region private methods
        private int tryParseInt(string source)
        {
            int value;
            int.TryParse(source, out value);
            return value;
        }

        private static readonly XmlSerializer _payFeedbackSerializer = new XmlSerializer(typeof (PayFeedback),
                                                                                         new XmlRootAttribute("xml"));
        private RefundResponse MapResponse(IDictionary<string, string> dictionary)
        {
            var response = new RefundResponse();
            response.sign = dictionary["sign"];
            response.sign_type = dictionary["sign_type"];
            response.input_charset = dictionary["input_charset"];
            response.retcode = tryParseInt(dictionary["retcode"]);
            response.retmsg = dictionary["retmsg"];
            response.partner = dictionary["partner"];
            response.transation_id = dictionary["transaction_id"];
            response.out_trade_no = dictionary["out_trade_no"];
            response.out_refund_no = dictionary["out_refund_no"];
            response.refund_id = dictionary["refund_id"];
            response.refund_channel = tryParseInt(dictionary["refund_channel"]);
            response.refund_fee = tryParseInt(dictionary["refund_fee"]);
            response.refund_status = tryParseInt(dictionary["refund_status"]);
            response.reccv_user_name = dictionary["reccv_user_name"];
            response.recv_user_id = dictionary["recv_user_id"];
            return response;
        }
        #endregion
        #region internal methods
        private static readonly char[] nonceRange =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        internal static string CreateNonce(int length = 16)
        {
            var rd = new Random();
            var sb = new StringBuilder(length);
            for (var i = 0; i < length; i++)
            {
                sb.Append(nonceRange[rd.Next(nonceRange.Length - 1)]);
            }
            return sb.ToString();
        }
        private const string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
        
        /// <summary>
        /// Url编码，注意编码之后要使用大写形式，如"/" ---->> "%3A"，而不是"%3a"
        /// 使用GBK进行编码
        /// </summary>
        /// <returns></returns>
        internal static string UrlEncode(string value, string encoding)
        {
            var sb = new StringBuilder();
            foreach (var symbol in value)
            {
                var unencoded = symbol + "";
                var encoded = HttpUtility.UrlEncode(unencoded, Encoding.GetEncoding(encoding));
                if (encoded != unencoded)
                {
                    sb.Append(encoded.ToUpper());
                }
                else
                {
                    sb.Append(encoded);
                }
            }
            return sb.ToString();
        }

        internal const string MD5 = "MD5";
        internal const string SHA1 = "SHA1";
        /// <summary>
        /// 哈希函数，支持MD5和SHA1
        /// </summary>
        /// <param name="origin">待哈希串</param>
        /// <param name="method">哈希方法</param>
        /// <param name="encoding">编码</param>
        /// <returns></returns>
        public static string Hash(string origin, string method, string encoding = "UTF-8")
        {
            if (origin == null) return null;
            using (var algo = HashAlgorithm.Create(method))
            {
                if (algo == null) return null;
                var bytes = Encoding.GetEncoding(encoding).GetBytes(origin);
                var bytearray = algo.ComputeHash(bytes);
                return BitConverter.ToString(bytearray).Replace("-", "");
            }
        }
        internal static string DictionaryToJson(IEnumerable<KeyValuePair<string, string>> dic)
        {
            var entries = dic.Select(d => string.Format("\"{0}\": \"{1}\"", d.Key, d.Value));
            return "{" + string.Join(",", entries.ToArray()) + "}";
        }
        internal static string ToXml(IEnumerable<KeyValuePair<string, string>> pairs)
        {
            var buffer = new StringBuilder();
            buffer.Append("<xml>");
            foreach (var pair in pairs)
            {
                int temp;
                if (int.TryParse(pair.Value, out temp))
                {
                    buffer.AppendFormat("<{0}>{1}</{0}>", pair.Key, pair.Value);
                }
                else
                {
                    buffer.AppendFormat("<{0}><![CDATA[{1}]]</{0}>", pair.Key, pair.Value);
                }
            }
            buffer.Append("</xml>");
            return buffer.ToString();
        }
        internal static IDictionary<string, string> XmlToDictionary(string xml)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNode root = xmlDoc.SelectSingleNode("root");
            XmlNodeList xnl = root.ChildNodes;

            var dic = xnl.Cast<XmlNode>().ToDictionary(xnf => xnf.Name, xnf => xnf.InnerXml);
            return dic;
        } 
        internal static string FormatUrlQuery(IDictionary<string, string> dic, bool NeedUrlEncode, string encoding)
        {
            var pairs = dic.OrderBy(o => o.Key).ToArray();
            var queryStr = string.Join("&",
                                       pairs.Select(
                                           o => o.Key.ToLower() + "=" + (NeedUrlEncode ? UrlEncode(o.Value, encoding) : o.Value)));
            return queryStr;
        }
        /// <summary>
        /// 生成订单详情package
        /// </summary>
        /// <returns></returns>
        internal static string CreatePackage(JSApiParam param)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("bank_type", "WX");
            parameters.Add("body", param.Body);
            parameters.Add("partner", param.Partner);
            parameters.Add("out_trade_no", param.OutTradeNo);
            parameters.Add("total_fee", param.TotalFee.ToString());
            parameters.Add("fee_type", "1");
            parameters.Add("notify_url", param.NotifyUrl);
            parameters.Add("spbill_create_ip", param.ClientIp);
            parameters.Add("input_charset", param.Charset);
            if (!string.IsNullOrWhiteSpace(param.Attach))
            {
                parameters.Add("attach", param.Attach);
            }
            if (param.TimeStart != null)
            {
                parameters.Add("time_start", Epoch.ConvertToEpoch(param.TimeStart.Value).ToString());
            }
            if (param.TimeExpire != null)
            {
                parameters.Add("time_expire", Epoch.ConvertToEpoch(param.TimeExpire.Value).ToString());
            }
            if (param.TransportFee != null)
            {
                parameters.Add("transport_fee", param.TransportFee.Value.ToString());
            }
            if (param.ProductFee != null)
            {
                parameters.Add("product_fee", param.ProductFee.Value.ToString());
            }
            if (!string.IsNullOrWhiteSpace(param.GoodsTag))
            {
                parameters.Add("goods_tag", param.GoodsTag);
            }
            var unsignedQueryStr = FormatUrlQuery(parameters, false, param.Charset);
            var packageStr = FormatUrlQuery(parameters, true, param.Charset) + "&sign=" +
                             Hash(unsignedQueryStr + "&key=" + param.PartnerKey, MD5);
            return packageStr;
        }
        /// <summary>
        /// 生成支付签名paySign
        /// </summary>
        /// <returns></returns>
        internal static string CreatePaySign(IEnumerable<KeyValuePair<string, string>> dicParam, string appkey, string method=SHA1)
        {
            var dictionary = dicParam.ToDictionary(pair => pair.Key.ToLower(), pair => pair.Value);
            dictionary.Add("appkey", appkey);
            var unsignedStr = FormatUrlQuery(dictionary, false, "");
            return Hash(unsignedStr, method).ToLower();
        }
        public class OrderResponse:WeChatPayResponse
        {
            public OrderInfo order_info { get; set; }
        }
        #endregion
    }
}
