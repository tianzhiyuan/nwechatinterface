using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.CustomerServiceMessages
{
    public class VideoContent
    {
        public string media_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
    /// <summary>
    /// 视频消息
    /// </summary>
    public class VideoMessage : CustomerServiceMessage
    {
        public VideoContent video { get; set; }
    }
}
