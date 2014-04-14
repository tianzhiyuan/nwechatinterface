namespace NWeChatInterface.Response
{
    public class OpenIdResponse : WeChatResponse
    {
        public string access_token { get; internal set; }
        public string expires_in { get; internal set; }
        public string refresh_token { get; internal set; }
        public string openid { get; internal set; }
        public string scop { get; internal set; }
    }
}
