using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KITH.Interface.WeChat.Results
{
    public class OpenIdList
    {
        public IList<string>  openid { get; set; }
    }
    /// <summary>
    /// 获取所有关注者列表的返回值
    /// </summary>
    public class SubscriberListResult : AbstractResult
    {
        public int total { get; set; }
        public int count { get; set; }
        public OpenIdList data { get; set; }
        public string next_openid { get; set; }
    }
}
