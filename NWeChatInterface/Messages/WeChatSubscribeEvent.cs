using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Messages
{
    public class WeChatSubscribeEvent : WeChatEventMsg
    {
        public CData EventKey { get; set; }
    }
}
