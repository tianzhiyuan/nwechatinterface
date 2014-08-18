﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NWeChatInterface.ResponseMessages
{
    public class Article
    {
        [JsonProperty("title")]
        public CData Title { get; set; }
        [JsonProperty("description")]
        public CData Description { get; set; }
        [JsonProperty("url")]
        public CData Url { get; set; }
        [JsonProperty("picurl")]
        public CData PicUrl { get; set; }
    }
    public class NewsConent
    {
        public Article[] articles { get; set; }
    }
    /// <summary>
    /// 图文消息
    /// </summary>
    public class NewsMessage : WeChatBaseMsg, ICustomerServiceMessage
    {
        [JsonProperty("news")]
        public NewsConent Articles { get; set; }
        public int ArticleCount { get; set; }
        public override CData MsgType
        {
            get { return WeChatMessageTypes.NEWS; }
        }
    }
}
