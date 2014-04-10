using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 获取关注着列表
    /// </summary>
    public class GetSubscribers : IGetRequest<SubscriberListResponse>
    {
        public string AccessToken { get; private set; }
        public string NextOpenId { get; private set; }
        public GetSubscribers(string accessToken, string nextOpenId = null)
        {
            this.AccessToken = accessToken;
            this.NextOpenId = nextOpenId;
        }
        public string RequestUrl
        {
            get
            {
                if (string.IsNullOrWhiteSpace(NextOpenId))
                {
                    return string.Format("https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}",
                                         this.AccessToken);
                }
                else
                {
                    return
                        string.Format(
                            "https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}",
                            this.AccessToken, this.NextOpenId);
                }
            }
        }
    }
}
