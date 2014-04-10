using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Models;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 更新用户组名称
    /// </summary>
    public class UpdateUserGroupName : IPostRequest<WeChatResponse>
    {
        public UpdateUserGroupName(string accessToken, UserGroup group)
        {
            this.AccessToken = accessToken;
            this.Group = group;
        }
        
        public string AccessToken { get; private set; }
        public UserGroup Group { get; private set; }
        public string RequestUrl { get { return string.Format("https://api.weixin.qq.com/cgi-bin/groups/update?access_token={0}", this.AccessToken); } }

        public string Data
        {
            get
            {
                return string.Format("{{'group':{{'id':{0},'name':'{1}'}}}}", this.Group.id, this.Group.name)
                             .Replace('\'', '\"');
            }
        }
    }
}
