using System.Collections.Generic;

namespace NWeChatInterface.Response
{
    public class OpenIdList
    {
        public IList<string>  openid { get; set; }
    }
    /// <summary>
    /// 获取所有关注者列表的返回值
    /// </summary>
    public class SubscriberListResponse : WeChatResponse
    {
        public int total { get; set; }
        public int count { get; set; }
        public OpenIdList data { get; set; }
        public string next_openid { get; set; }
    }
}
