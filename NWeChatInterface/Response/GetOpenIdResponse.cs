namespace NWeChatInterface.Response
{
    /// <summary>
    /// OpenId结果 
    /// </summary>
    public class GetOpenIdResponse : WeChatResponse
    {
        public string access_token { get; internal set; }
        public int expires_in { get; internal set; }
        public string refresh_token { get; internal set; }
        public string openid { get; internal set; }
        public string scope { get; internal set; }
    }
}
