using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 获取某个用户属于哪个用户组
    /// </summary>
    public class GetBelongUserGroup:IPostRequest<GetBelongUserGroupResponse>
    {
        public GetBelongUserGroup(string accessToken, string openId)
        {
            this.AccessToken = accessToken;
            this.OpenId = openId;
        }
        public string AccessToken { get; private set; }
        public string OpenId { get; private set; }
        public string RequestUrl { get { return string.Format("https://api.weixin.qq.com/cgi-bin/groups/getid?access_token={0}", this.AccessToken); } }
        public string Data { get { return string.Format("{{\"openid\":\"{0}\"}}", this.OpenId); } }
    }
}
