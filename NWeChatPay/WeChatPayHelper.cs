using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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
        const string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
        internal static string UrlEncode(string value)
        {
            var sb = new StringBuilder();
            foreach (var symbol in value)
            {
                if (unreservedChars.IndexOf(symbol) != -1)
                {
                    sb.Append(symbol);
                }
                else
                {
                    sb.Append(string.Format("%{0:X2}", (int) symbol));
                }
            }
            return sb.ToString();
        }
        internal static string Sha1(string origin)
        {
            if (origin == null) return null;
            using (var algo = HashAlgorithm.Create("SHA1"))
            {
                if (algo == null) return null;
                var bytearray = algo.ComputeHash(Encoding.UTF8.GetBytes(origin));
                return BitConverter.ToString(bytearray).Replace("-", "");
            }
        }
    }
}
