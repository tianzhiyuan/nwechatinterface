using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Results;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 根据OpenId获取用户信息
    /// </summary>
    public class GetUserInfo : IGetRequest<UserInfoResult>
    {
        public string OpenId { get; private set; }
        public string AccessToken { get; private set; }
        public string Lang { get; private set; }
        public GetUserInfo(string openid, string accessToken, string lang = "zh_CN")
        {
            this.OpenId = openid;
            this.AccessToken = accessToken;
            this.Lang = lang;
        }
        public string RequestUrl
        {
            get
            {
                return string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang={2}",
                                     this.AccessToken,
                                     this.OpenId,
                                     this.Lang);
            }
        }
    }
}
