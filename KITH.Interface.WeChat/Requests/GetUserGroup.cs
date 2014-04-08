using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KITH.Interface.WeChat.Results;

namespace KITH.Interface.WeChat.Requests
{
    /// <summary>
    /// 获取所有用户分组
    /// </summary>
    public class GetUserGroup:IGetRequest<GetUserGroupResult>
    {
        public GetUserGroup(string accessToken)
        {
            this.AccessToken = accessToken;
        }
        public string AccessToken { get; private set; }
        public string RequestUrl { get { return string.Format("https://api.weixin.qq.com/cgi-bin/groups/get?access_token={0}", this.AccessToken); } }
    }
}
