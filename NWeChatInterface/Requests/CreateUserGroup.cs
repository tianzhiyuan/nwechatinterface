using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 创建用户分组
    /// </summary>
    public class CreateUserGroup : IPostRequest<CreateUserGroupResponse>
    {
        public CreateUserGroup(string accessToken, string groupName)
        {
            this.AccessToken = accessToken;
            this.GroupName = groupName;
        }
        public string AccessToken { get; private set; }
        public string GroupName { get; private set; }
        public string RequestUrl { get { return string.Format("https://api.weixin.qq.com/cgi-bin/groups/create?access_token={0}", this.AccessToken); } }
        public string Data { get { return string.Format("{{'group':{{'name':'{0}'}}}}", this.GroupName).Replace('\'', '"'); } }
    }
}
