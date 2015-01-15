using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.User
{
    /// <summary>
    /// 根据OpenId获取用户信息
    /// </summary>
	[RequestPath("/cgi-bin/user/info")]
	public class GetUserInfo : AccessRequiredRequest<UserInfoResponse>
    {
        public string OpenId { get; set; }
        /// <summary>
        /// 返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语
        /// </summary>
        public string Lang { get; set; }
        
        public override string Param
        {
            get
            {
                return string.Format("access_token={0}&openid={1}&lang={2}",
                                     this.AccessToken,
                                     this.OpenId,
                                     this.Lang);
            }
        }

		
    }
}
