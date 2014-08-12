using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace NWeChatInterface.ResponseMessages
{
    public class VideoContent
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [XmlIgnore]
        [JsonProperty("thumb_media_id")]
        public string ThumbMediaId { get; set; }
    }
    /// <summary>
    /// 视频消息
    /// </summary>
    public class VideoMessage : WeChatBaseMsg, ICustomerServiceMessage
    {
        [JsonProperty("video")]
        public VideoContent Video { get; set; }
        public override CData MsgType
        {
            get { return WeChatMessageTypes.VIDEO; }
        }
    }
}
