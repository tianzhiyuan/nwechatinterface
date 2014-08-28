namespace NWeChatInterface.Response
{
    public class OpenIdResponse : WeChatResponse
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
        public string openid { get; set; }
        public string scop { get; set; }
    }
}
