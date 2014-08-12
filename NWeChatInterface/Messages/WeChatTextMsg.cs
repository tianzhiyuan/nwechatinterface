using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Messages
{
    /// <summary>
    /// 微信文本消息
    /// </summary>
    public class WeChatTextMsg : WeChatNormalMsg
    {
        public override CData MsgType
        {
            get { return WeChatMessageTypes.TEXT; }
        }
        public CData Content { get; set; }
    }
}
