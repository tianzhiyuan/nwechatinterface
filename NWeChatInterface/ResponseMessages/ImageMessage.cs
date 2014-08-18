using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NWeChatInterface.ResponseMessages
{
    public class ImageContent
    {
        [JsonProperty("media_id")]
        public CData MediaId { get; set; }
    }

    /// <summary>
    /// 图片消息
    /// </summary>
    public class ImageMessage : WeChatBaseMsg, ICustomerServiceMessage
    {
        [JsonProperty("image")]
        public ImageContent Image { get; set; }

        public override CData MsgType
        {
            get { return WeChatMessageTypes.IMAGE; }
        }
    }

}
