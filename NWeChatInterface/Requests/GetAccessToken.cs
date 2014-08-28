using NWeChatInterface.Response;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 获取AccessToken
    /// 
    /// access_token是公众号的全局唯一票据，公众号调用各接口时都需使用access_token。
    /// 正常情况下access_token有效期为7200秒，重复获取将导致上次获取的access_token失效。
    /// 由于获取access_token的api调用次数非常有限，建议开发者全局存储与更新access_token，
    /// 频繁刷新access_token会导致api调用受限，影响自身业务。
    /// 
    /// 公众平台的开发接口的access_token其存储至少要保留512个字符空间
    /// </summary>
    public class GetAccessToken : IGetRequest<AccessTokenResponse>
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
