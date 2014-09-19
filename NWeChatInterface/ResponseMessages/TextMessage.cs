using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace NWeChatInterface.ResponseMessages
{
    public class TextContent
    {
        public string content { get; set; }
    }
    /// <summary>
    /// 文本消息
    /// </summary>
    public class TextMessage : WeChatReponseMessage, IResponseMessage
    {
        
        [XmlIgnore]
        [JsonProperty("text")]
        public TextContent text { get { return new TextContent() {content = this.Content}; } }
        /// <summary>
        /// 内容
        /// </summary>
        [JsonIgnore]
        public CData Content { get; set; }
        public override CData MsgType
        {
            get { return WeChatMessageTypes.TEXT; }
        }
    }
}
