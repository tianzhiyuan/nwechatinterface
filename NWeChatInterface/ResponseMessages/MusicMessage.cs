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
        public CData Title { get; set; }
        [JsonProperty("description")]
        public CData Description { get; set; }
        [JsonProperty("musicurl")]
        public CData MusicUrl { get; set; }
        [JsonProperty("hqmusicurl")]
        public CData HQMusicUrl { get; set; }
        [JsonProperty("thumb_media_id")]
        public CData ThumbMediaId { get; set; }
    }
    /// <summary>
    /// 音乐消息
    /// </summary>
    public class MusicMessage : WeChatReponseMessage
    {
        [JsonProperty("music")]
        public MusicContent Music { get; set; }
        public override CData MsgType
        {
            get { return WeChatMessageTypes.MUSIC; }
        }
    }
}
