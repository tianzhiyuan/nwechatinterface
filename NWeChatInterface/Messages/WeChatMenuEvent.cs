using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Messages
{
    /// <summary>
    /// 用户自定义菜单菜单事件，包括单击（CLICK）和链接跳转（VIEW）
    /// </summary>
    public class WeChatMenuEvent : WeChatEventMsg
    {
        public CData EventKey { get; set; }
    }
}
