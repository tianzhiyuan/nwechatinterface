using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using KITH.Interface.WeChat.Requests;

namespace KITH.Interface.WeChat
{
    /// <summary>
    /// 微信OAuth类
    /// 
    /// 微信网页授权步骤：
    /// 1. 引导用户打开OAuth回调页面，通过调用该方法获得此Url<see cref="BuildUrl"/>
    /// 2. redirectUrl中会拿到code字段（和state字段）
    /// 3. 通过Code获取到openid<see cref="GetOpenIdByCode"/>
    /// </summary>
    public class WeChatOAuth
    {
        /// <summary>
        /// 只能获取到openid
        /// </summary>
        public const string SnsapiBase = "snsapi_base";
        /// <summary>
        /// 能获取到openid及用户信息
        /// </summary>
        public const string SnsapiUserinfo = "snsapi_userinfo";
        /// <summary>
        /// 构建微信OAuth2.0授权Url
        /// </summary>
        /// <param name="scope">授权域，必须是<value>snsapi_base</value>或者<value>snsapi_userinfo</value>之一</param>
        /// <param name="appid">当前服务号AppId</param>
        /// <param name="redirectUrl">回调Url</param>
        /// <param name="state">选填状态参数，限制为：a-zA-Z0-9</param>
        /// <returns></returns>
        public static string BuildUrl(string scope, string appid, string redirectUrl, string state = null)
        {
            if (scope != SnsapiBase && scope != SnsapiUserinfo) throw new ArgumentException("scope参数错误");
            if (string.IsNullOrWhiteSpace(state)) state = "1";
            return
                string.Format(
                    "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope={2}&state={3}#wechat_redirect",
                    appid,
                    HttpUtility.HtmlEncode(redirectUrl),
                    scope,
                    state);
        }
        public static string BuildBaseUrl(string appid, string redirectUrl, string state = null)
        {
            return BuildUrl(SnsapiBase, appid, redirectUrl, state);
        }
        public static string BuildUserInfoUrl(string appid, string redirectUrl, string state = null)
        {
            return BuildUrl(SnsapiUserinfo, appid, redirectUrl, state);
        }
    }
}
