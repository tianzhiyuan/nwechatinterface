using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 网页授权获取用户基本信息
    /// </summary>
	[RequestPath("/sns/userinfo")]
	[RequestMethod(RequestMethod.GET)]
    public class GetOAuthUserInfo : IWeChatRequest<UserInfoResponse>
    {
        public GetOAuthUserInfo(string accessToken, string openId, string lang = "zh_CN")
        {
            this.AccessToken = accessToken;
            this.OpenId = openId;
            this.Lang = lang;
        }
        /// <summary>
        /// 网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同
        /// </summary>
        public string AccessToken { get; private set; }
        /// <summary>
        /// 用户的唯一标识
        /// </summary>
        public string OpenId { get; private set; }
        /// <summary>
        /// 返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语
        /// </summary>
        public string Lang { get; private set; }

        public string Param
        {
            get
            {
                return string.Format("access_token={0}&openid={1}&lang={2}",
                                     this.AccessToken, this.OpenId, this.Lang);
            }
        }

		public string Data { get { return ""; } }
    }
}
