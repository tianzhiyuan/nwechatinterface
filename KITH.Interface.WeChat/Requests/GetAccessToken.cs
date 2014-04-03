using KITH.Interface.WeChat.Results;

namespace KITH.Interface.WeChat.Requests
{
    /// <summary>
    /// 获取AccessToken
    /// </summary>
    public class GetAccessToken : IGetRequest<AccessTokenResult>
    {
        public string GrandType { get; private set; }
        public string AppId { get; private set; }
        public string Secret { get; private set; }
        public GetAccessToken(string appId, string secret, string grandType = "client_credential")
        {
            GrandType = grandType;
            AppId = appId;
            Secret = secret;
        }

        public string RequestUrl
        {
            get
            {
                return
                    string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type={0}&appid={1}&secret={2}",
                                  this.GrandType, this.AppId, this.Secret);
            }
        }
    }
}
