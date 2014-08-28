using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 将一条长链接转成短链接。
    /// 
    /// 主要使用场景： 开发者用于生成二维码的原链接（商品、支付二维码等）太长导致扫码速度和成功率下降，
    /// 将原长链接通过此接口转成短链接再生成二维码将大大提升扫码速度和成功率。
    /// </summary>
    public class CreateShortUrl : IPostRequest<CreateShortUrlResponse>
    {
        public string AccessToken { get; private set; }
        public string LongUrl { get; private set; }
        public string Action { get; private set; }
        public CreateShortUrl(string accessToken, string long_url, string action = "long2short")
        {
            this.AccessToken = accessToken;
            this.LongUrl = long_url;
            this.Action = action;
        }
        public string RequestUrl { get { return string.Format("https://api.weixin.qq.com/cgi-bin/shorturl?access_token={0}", this.AccessToken); } }
        public string Data { get { return string.Format("{{'action':'{0}', 'long_url':'{1}'}}", this.Action, this.LongUrl).Replace("'", "\""); } }
    }
}
