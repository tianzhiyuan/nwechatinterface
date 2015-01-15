using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.Message
{
    /// <summary>
    /// 删除群发消息
    /// 请注意，只有已经发送成功的消息才能删除。删除消息只是将消息的图文详情页失效，
    /// 已经收到的用户，还是能在其本地看到消息卡片。 
    /// 另外，删除群发消息只能删除图文消息和视频消息，其他类型的消息一经发送，无法删除。
    /// </summary>
    [RequestMethod(RequestMethod.POST)]
	[RequestPath("/cgi-bin/message/mass/delete")]
	public class DeleteMassMessage : AccessRequiredRequest<CommonResponse>
    {
        public long MsgId { get; set; }
        public override string Data { get { return string.Format("{{\"msgid\":{0}}}", this.MsgId); }}
    }
}
