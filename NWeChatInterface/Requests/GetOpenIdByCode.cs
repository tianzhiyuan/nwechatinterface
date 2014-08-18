using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 微信网页授权接口
    /// 根据回调中获取到的code，拿到openid
    /// </summary>
    public class GetOpenIdByCode : IGetRequest<GetOpenIdResponse>
    {
        public string AppId { get; private set; }
        public string AppSecret { get; private set; }
        public string Code { get; private set; }
        public GetOpenIdByCode(string appid, string secret, string code)
        {
            this.AppId = appid;
            this.AppSecret = secret;
            this.Code = code;
        }
        public string RequestUrl
        {
            get
            {
                return
                    string.Format(
                        "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code",
                        this.AppId,
                        this.AppSecret,
                        this.Code);
            }
        }
    }
}
