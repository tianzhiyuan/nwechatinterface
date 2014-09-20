using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Messages
{
    /// <summary>
    /// 模版消息送达推送
    /// 成功时 Status=success
    /// 失败时 Status=failed:userblock 或者 Status=failed:system failed
    /// </summary>
    public class WeChatTemplateSendJobEvent : WeChatEventMsg
    {
        public long MsgID { get; set; }
        public CData Status { get; set; }
    }
}
