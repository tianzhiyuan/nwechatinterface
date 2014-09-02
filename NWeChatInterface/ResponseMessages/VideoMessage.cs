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
        public CData MediaId { get; set; }
        [JsonProperty("title")]
        public CData Title { get; set; }
        [JsonProperty("description")]
        public CData Description { get; set; }
        [XmlIgnore]
        [JsonProperty("thumb_media_id")]
        public CData ThumbMediaId { get; set; }
    }
    /// <summary>
    /// 视频消息
    /// </summary>
    public class VideoMessage : WeChatBaseMsg, IResponseMessage
    {
        [JsonProperty("video")]
        public VideoContent Video { get; set; }
        public override CData MsgType
        {
            get { return WeChatMessageTypes.VIDEO; }
        }
    }
}
