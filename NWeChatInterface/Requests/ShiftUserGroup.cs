using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 移动用户分组
    /// </summary>
    public class ShiftUserGroup:IPostRequest<WeChatResponse>
    {
        public ShiftUserGroup(string accessToken, string openId, int groupId)
        {
            this.AccessToken = accessToken;
            this.OpenId = openId;
            this.ToGroupId = groupId;
        }
        public string AccessToken { get; private set; }
        public string OpenId { get; private set; }
        public int ToGroupId { get; private set; }
        public string RequestUrl { get { return string.Format("https://api.weixin.qq.com/cgi-bin/groups/members/update?access_token={0}", this.AccessToken); } }
        public string Data { get { return string.Format("{{'openid':'{0}','to_groupid':{1}}}", this.OpenId, this.ToGroupId).Replace('\'', '"'); } }
    }
}
