namespace NWeChatInterface.Response
{
    /// <summary>
    /// 获取二维码Ticket
    /// </summary>
    public class QRTicketResponse : WeChatResponse
    {
        public string ticket { get; set; }
        public int expire_seconds { get; set; }
        public string url { get; set; }
    }
}
