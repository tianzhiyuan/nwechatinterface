using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 根据用户openid获取用户所属分组
    /// </summary>
    public class GetUserBelongGroup : IPostRequest<GetUserBelongGroupResponse>
    {
        public GetUserBelongGroup(string accessToken, string openid)
        {
            this.AccessToken = accessToken;
            this.OpenId = openid;
        }
        public string OpenId { get; private set; }
        public string AccessToken { get; private set; }
        public string RequestUrl { get { return string.Format("https://api.weixin.qq.com/cgi-bin/groups/getid?access_token={0}", this.AccessToken); } }

        public string Data
        {
            get { return string.Format("{{'openid':'{0}'}}", this.OpenId).Replace(@"'", "\""); }

        }
    }
}
