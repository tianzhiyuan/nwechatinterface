using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NWeChatInterface.ResponseMessages
{
    public class VoiceContent
    {
        [JsonProperty("media_id")]
        public CData MediaId { get; set; }
    }
    /// <summary>
    /// 语音消息
    /// </summary>
    public class VoiceMessage : WeChatReponseMessage
    {
        [JsonProperty("voice")]
        public VoiceContent Voice { get; set; }
        public override CData MsgType
        {
            get { return WeChatMessageTypes.VOICE; }
        }
    }
}
