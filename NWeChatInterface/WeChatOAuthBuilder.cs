using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NWeChatInterface.Requests;

namespace NWeChatInterface
{
    /// <summary>
    /// 微信OAuth类
    /// 
    /// 微信网页授权步骤：
    /// 1. 引导用户打开OAuth回调页面，通过调用该方法获得此Url<see cref="BuildUrl"/>
    /// 2. redirectUrl中会拿到code字段（和state字段）
    /// 3. 通过Code获取到openid<see cref="GetOpenIdByCode"/>
    /// </summary>
    public class WeChatOAuthBuilder
    {
        /// <summary>
        /// 只能获取到openid
        /// </summary>
        public const string SNSAPI_BASE = "snsapi_base";
        /// <summary>
        /// 能获取到openid及用户信息
        /// </summary>
        public const string SNSAPI_USERINFO = "snsapi_userinfo";
        /// <summary>
        /// 网页应用授权登录
        /// </summary>
        public const string SNSAPI_LOGIN = "snsapi_login";
        /// <summary>
        /// 构建微信OAuth2.0授权Url
        /// </summary>
        /// <param name="scope">授权域，必须是<value>snsapi_base</value>或者<value>snsapi_userinfo</value>或者<value>snsapi_login</value>之一</param>
        /// <param name="appid">当前服务号AppId</param>
        /// <param name="redirectUrl">回调Url</param>
        /// <param name="state">选填状态参数，限制为：a-zA-Z0-9用于保持请求和回调的状态，
        /// 授权请求后原样带回给第三方。该参数可用于防止csrf攻击（跨站请求伪造攻击），
        /// 建议第三方带上该参数，可设置为简单的随机数加session进行校验</param>
        /// <returns>跳转的Url</returns>
        public static string BuildUrl(string scope, string appid, string redirectUrl, string state = null)
        {
            if (scope != SNSAPI_BASE && scope != SNSAPI_USERINFO && scope != SNSAPI_LOGIN)
                throw new ArgumentException("scope参数错误");
            if (string.IsNullOrWhiteSpace(state)) state = "1";
            if (scope == SNSAPI_LOGIN)
            {
                return
                    string.Format(
                        "https://open.weixin.qq.com/connect/qrconnect?appid={0}&redirect_uri={1}&response_type=code&scope={2}&state={3}#wechat_redirect",
                        appid,
                        MyUrlEncode(redirectUrl),
                        scope,
                        state
                        );
            }
            return
                string.Format(
                    "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope={2}&state={3}#wechat_redirect",
                    appid,
                    MyUrlEncode(redirectUrl),
                    scope,
                    state);
        }
        public static string BuildBaseUrl(string appid, string redirectUrl, string state = null)
        {
            return BuildUrl(SNSAPI_BASE, appid, redirectUrl, state);
        }
        public static string BuildUserInfoUrl(string appid, string redirectUrl, string state = null)
        {
            return BuildUrl(SNSAPI_USERINFO, appid, redirectUrl, state);
        }
        public static string BuildLoginUrl(string appid, string redirectUrl, string state = null)
        {
            return BuildUrl(SNSAPI_LOGIN, appid, redirectUrl, state);
        }
        /// <summary>
        /// URL编码
        /// </summary>
        /// <param name="value">The value to Url encode</param>
        /// <returns>Returns a Url encoded string</returns>
        public static string MyUrlEncode(string value)
        {
            StringBuilder result = new StringBuilder();

            string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
            foreach (char symbol in value)
            {
                if (unreservedChars.IndexOf(symbol) != -1)
                {
                    result.Append(symbol);
                }
                else
                {
                    result.Append('%' + String.Format("{0:X2}", (int)symbol));
                }
            }

            return result.ToString();
        }
    }
}
