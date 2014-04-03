using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KITH.Interface.WeChat.Messages
{
    /// <summary>
    /// 微信音频消息
    /// </summary>
    public class WeChatVoiceMsg : WeChatMediaMsg
    {
        public CData Format { get; set; }
        public CData Recognition { get; set; }
    }
}
