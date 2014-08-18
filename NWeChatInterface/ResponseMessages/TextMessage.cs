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
    public class TextMessage : WeChatBaseMsg, ICustomerServiceMessage
    {
        /// <summary>
        /// 注意如果是被动响应消息，这个值不需要填写
        /// 如果是客服消息，使用这个属性
        /// </summary>
        [XmlIgnore]
        [JsonProperty("text")]
        public TextContent text { get; set; }
        /// <summary>
        /// 如果是被动响应消息，使用这个属性
        /// 如果是客服消息，不需要设置这个属性
        /// </summary>
        [JsonIgnore]
        public CData Content { get; set; }
        public override CData MsgType
        {
            get { return WeChatMessageTypes.TEXT; }
        }
    }
}
