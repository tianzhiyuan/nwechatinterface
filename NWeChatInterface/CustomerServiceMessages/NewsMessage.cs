using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.CustomerServiceMessages
{
    public class Article
    {
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string picurl { get; set; }
    }
    public class NewsConent
    {
        public Article[] articles { get; set; }
    }
    /// <summary>
    /// 图文消息
    /// </summary>
    public class NewsMessage : CustomerServiceMessage
    {
        public NewsConent news { get; set; }
    }
}
