using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.CustomerServiceMessages
{
    public class VoiceContent
    {
        public string media_id { get; set; }
    }
    /// <summary>
    /// 语音消息
    /// </summary>
    public class VoiceMessage : CustomerServiceMessage
    {
        public VoiceContent voice { get; set; }
    }
}
