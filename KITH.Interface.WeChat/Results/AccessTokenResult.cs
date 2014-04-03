namespace KITH.Interface.WeChat.Results
{
    /// <summary>
    /// AccessToken获取结果
    /// </summary>
    public class AccessTokenResult : AbstractResult
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
}
