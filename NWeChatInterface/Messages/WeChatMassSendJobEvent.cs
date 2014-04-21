using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Messages
{
    /// <summary>
    /// 微信群发消息结果推送
    /// </summary>
    public class WeChatMassSendJobEvent:WeChatEventMsg
    {
        public CData MsgID { get; set; }
        public CData Status { get; set; }
        public int TotalCount { get; set; }
        public int FilterCount { get; set; }
        public int SendCount { get; set; }
        public int ErrorCount { get; set; }
    }
}
