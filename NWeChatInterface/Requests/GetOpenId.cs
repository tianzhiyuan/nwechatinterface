using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 根据Code获取OpenId
    /// </summary>
    public class GetOpenId : IGetRequest<OpenIdResponse>
    {
        public string Code { get; private set; }

        public string AccessToken { get; private set; }
        public string AppId { get; private set; }
        public GetOpenId(string code, string accessToken, string appid)
        {
            this.Code = code;
            this.AccessToken = accessToken;
            this.AppId = appid;
        }
        public string RequestUrl
        {
            get
            {
                return string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code",
                    this.AppId,
                    this.AccessToken,
                    this.Code);
            }
        }
    }
}
