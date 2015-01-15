using NWeChatInterface.Models;
using NWeChatInterface.Response;
using Newtonsoft.Json;

namespace NWeChatInterface.Requests.Message
{
    
    /// <summary>
    /// 发送模版消息
    /// 模板消息仅用于公众号向用户发送重要的服务通知，
    /// 只能用于符合其要求的服务场景中，如信用卡刷卡通知，商品购买成功通知等。
    /// 不支持广告等营销类消息以及其它所有可能对用户造成骚扰的消息。
    /// </summary>
	[RequestPath("/cgi-bin/message/template/send")]
	public class SendTemplateMessage : AccessRequiredRequest<SendTemplateResponse>
    {
        
        public TemplateMessage Message { get; set; }
        


        public override string Data { get { return JsonConvert.SerializeObject(this.Message); } }
    }
}
