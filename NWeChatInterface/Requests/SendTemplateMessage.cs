using NWeChatInterface.Models;
using NWeChatInterface.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NWeChatInterface.Requests
{
    
    /// <summary>
    /// 发送模版消息
    /// 模板消息仅用于公众号向用户发送重要的服务通知，
    /// 只能用于符合其要求的服务场景中，如信用卡刷卡通知，商品购买成功通知等。
    /// 不支持广告等营销类消息以及其它所有可能对用户造成骚扰的消息。
    /// </summary>
    public class SendTemplateMessage : IPostRequest<SendTemplateResponse>
    {
        public SendTemplateMessage(string accessToken, TemplateMessage message)
        {
            this.AccessToken = accessToken;
            this.Message = message;
        }
        public TemplateMessage Message { get; private set; }
        public string AccessToken { get; private set; }
        

        public string RequestUrl
        {
            get
            {
                return string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}",
                                     this.AccessToken);
            }
        }

        public string Data { get { return JsonConvert.SerializeObject(this.Message); } }
    }
}
