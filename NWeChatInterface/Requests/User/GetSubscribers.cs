using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.User
{
    /// <summary>
    /// 获取关注着列表
    /// </summary>
	[RequestPath("/cgi-bin/user/get")]
	public class GetSubscribers : AccessRequiredRequest<SubscriberListResponse>
    {
        public string NextOpenId { get; private set; }
        public GetSubscribers(string accessToken, string nextOpenId = null)
        {
            this.AccessToken = accessToken;
            this.NextOpenId = nextOpenId;
        }
        public override string Param
        {
            get
            {
                if (string.IsNullOrWhiteSpace(NextOpenId))
                {
                    return string.Format("access_token={0}",
                                         this.AccessToken);
                }
                else
                {
                    return
                        string.Format(
                            "access_token={0}&next_openid={1}",
                            this.AccessToken, this.NextOpenId);
                }
            }
        }
    }
}
