using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Models;
using Newtonsoft.Json;

namespace NWeChatInterface.ResponseMessages
{
    
    /// <summary>
    /// 图文消息
    /// </summary>
    public class NewsMessage : WeChatReponseMessage
    {
        [JsonIgnore]
        public int ArticleCount { get; set; }
        public override CData MsgType
        {
            get { return WeChatMessageTypes.NEWS; }
        }
        [JsonProperty("news")]
        public Articles Articles { get; set; }
    }
}
