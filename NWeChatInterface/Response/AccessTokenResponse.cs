namespace NWeChatInterface.Response
{
    /// <summary>
    /// AccessToken获取结果
    /// </summary>
    public class AccessTokenResponse : WeChatResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
}
