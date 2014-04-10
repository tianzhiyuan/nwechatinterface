using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Messages
{
    /// <summary>
    /// 微信音频消息
    /// </summary>
    public class WeChatVoiceMsg : WeChatMediaMsg
    {
        public CData Format { get; set; }
        public CData Recognition { get; set; }
        public override CData MsgType
        {
            get { return WeChatMessageTypes.voice; }
        }
    }
}
