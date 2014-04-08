using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Messages
{
    /// <summary>
    /// 微信视频消息
    /// </summary>
    public class WeChatVideoMsg : WeChatMediaMsg
    {
        public CData ThumbMediaId { get; set; }
    }
}
