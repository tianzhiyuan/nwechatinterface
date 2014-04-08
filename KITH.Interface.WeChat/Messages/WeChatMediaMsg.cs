using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Messages
{
    /// <summary>
    /// 微信多媒体消息
    /// </summary>
    public abstract class WeChatMediaMsg : WeChatNormalMsg
    {
        public CData MediaId { get; set; }
    }
}
