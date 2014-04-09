using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.CustomerServiceMessages
{
    public class MusicContent
    {
        public string title { get; set; }
        public string description { get; set; }
        public string musicurl { get; set; }
        public string hqmusicurl { get; set; }
        public string thumb_media_id { get; set; }
    }
    /// <summary>
    /// 音乐消息
    /// </summary>
    public class MusicMessage : CustomerServiceMessage
    {
        public MusicContent music { get; set; }
    }
}
