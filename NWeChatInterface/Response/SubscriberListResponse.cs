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
        public int total { get; internal set; }
        public int count { get; internal set; }
        public OpenIdList data { get; internal set; }
        public string next_openid { get; internal set; }
    }
}
