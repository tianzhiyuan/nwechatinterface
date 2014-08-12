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
        /// <summary>
        /// 语音格式，如amr，speex等
        /// </summary>
        public CData Format { get; set; }
        /// <summary>
        /// 开通语音识别功能，用户每次发送语音给公众号时，微信会在推送的语音消息XML数据包中，增加一个Recongnition字段。
        /// </summary>
        public CData Recognition { get; set; }
        public override CData MsgType
        {
            get { return WeChatMessageTypes.voice; }
        }
    }
}
