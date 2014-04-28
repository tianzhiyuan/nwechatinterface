using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace NWeChatPay
{
    /// <summary>
    /// 微信支付辅助类
    /// </summary>
    public class WeChatPayHelper
    {
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
            var parameters = new Dictionary<string, string>();
            parameters.Add("appId", param.AppId);
            parameters.Add("package", CreatePackage(param));
            parameters.Add("timeStamp", Epoch.Now.ToString());
            parameters.Add("nonceStr", CreateNonce());
            parameters.Add("paySign", CreatePaySign(parameters, param.AppKey));
            parameters.Add("signType", "SHA1");
            return DictionaryToJson(parameters);
        }


        #region private methods
        /// <summary>
        /// 生成订单详情package
        /// </summary>
        /// <returns></returns>
        string CreatePackage(JSApiParam param)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("bank_type", "WX");
            parameters.Add("body", param.Body);
            parameters.Add("partner", param.Partner);
            parameters.Add("out_trade_no", param.OutTradeNo);
            parameters.Add("total_fee", param.TotalFee);
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
            if (!string.IsNullOrWhiteSpace(param.TransportFee))
            {
                parameters.Add("transport_fee", param.TransportFee);
            }
            if (!string.IsNullOrWhiteSpace(param.ProductFee))
            {
                parameters.Add("product_fee", param.ProductFee);
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
        string CreatePaySign(IDictionary<string, string> dicParam, string appkey)
        {
            var dictionary = dicParam.ToDictionary(pair => pair.Key.ToLower(), pair => pair.Value);
            dictionary.Add("appkey", appkey);
            var unsignedStr = FormatUrlQuery(dictionary, false, "");
            return Hash(unsignedStr, SHA1).ToLower();
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

        internal static string MD5 = "MD5";
        internal static string SHA1 = "SHA1";
        /// <summary>
        /// 哈希函数，支持MD5和SHA1
        /// </summary>
        /// <param name="origin">待哈希串</param>
        /// <param name="method">哈希方法</param>
        /// <returns></returns>
        internal static string Hash(string origin, string method)
        {
            if (origin == null) return null;
            using (var algo = HashAlgorithm.Create(method))
            {
                if (algo == null) return null;
                var bytearray = algo.ComputeHash(Encoding.UTF8.GetBytes(origin));
                return BitConverter.ToString(bytearray).Replace("-", "");
            }
        }
        internal static string DictionaryToJson(IDictionary<string, string> dic)
        {
            var entries = dic.Select(d => string.Format("\"{0}\": \"{1}\"", d.Key, d.Value));
            return "{" + string.Join(",", entries.ToArray()) + "}";
        }
        internal static string FormatUrlQuery(IDictionary<string, string> dic, bool NeedUrlEncode, string encoding)
        {
            var pairs = dic.OrderBy(o => o.Key).ToArray();
            var queryStr = string.Join("&",
                                       pairs.Select(
                                           o => o.Key.ToLower() + "=" + (NeedUrlEncode ? UrlEncode(o.Value, encoding) : o.Value)));
            return queryStr;
        }
        #endregion
    }
}
