using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Results;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 微信网页授权接口
    /// 根据回调中获取到的code，拿到openid
    /// </summary>
    public class GetOpenIdByCode:IGetRequest<GetOpenIdResult>
    {
        public string appid { get; private set; }
        public string secret { get; private set; }
        public string code { get; private set; }
        public GetOpenIdByCode(string appid, string secret, string code)
        {
            this.appid = appid;
            this.secret = secret;
            this.code = code;
        }
        public string RequestUrl
        {
            get
            {
                return
                    string.Format(
                        "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code",
                        this.appid,
                        this.secret,
                        this.code);
            }
        }
    }
}
