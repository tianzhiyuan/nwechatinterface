using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KITH.Interface.WeChat.Messages
{
    /// <summary>
    /// 微信文本消息
    /// </summary>
    public class WeChatTextMsg : WeChatNormalMsg
    {
        public CData Content { get; set; }
    }
}
