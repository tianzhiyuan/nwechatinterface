namespace NWeChatInterface.Response
{
    /// <summary>
    /// OpenId结果 
    /// </summary>
    public class GetOpenIdResponse : AbstractResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string openid { get; set; }
        public string scope { get; set; }
    }
}
