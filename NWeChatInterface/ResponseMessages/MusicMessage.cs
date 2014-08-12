using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NWeChatInterface.ResponseMessages
{
    public class MusicContent
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("musicurl")]
        public string MusicUrl { get; set; }
        [JsonProperty("hqmusicurl")]
        public string HQMusicUrl { get; set; }
        [JsonProperty("thumb_media_id")]
        public string ThumbMediaId { get; set; }
    }
    /// <summary>
    /// 音乐消息
    /// </summary>
    public class MusicMessage : WeChatBaseMsg, ICustomerServiceMessage
    {
        [JsonProperty("music")]
        public MusicContent Music { get; set; }
        public override CData MsgType
        {
            get { return WeChatMessageTypes.MUSIC; }
        }
    }
}
