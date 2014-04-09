using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.CustomerServiceMessages
{
    public class TextContent
    {
        public string content { get; set; }
    }
    /// <summary>
    /// 文本消息
    /// </summary>
    public class TextMessage:CustomerServiceMessage
    {
        public TextContent text { get; set; }
    }
}
