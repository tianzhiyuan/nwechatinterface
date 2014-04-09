using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.CustomerServiceMessages
{
    public class ImageContent
    {
        public string media_id { get; set; }
    }
    /// <summary>
    /// 图片消息
    /// </summary>
    public class ImageMessage : CustomerServiceMessage
    {
        public ImageContent image { get; set; }
    }
}
