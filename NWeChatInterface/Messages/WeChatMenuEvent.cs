using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Messages
{
    /// <summary>
    /// 用户点击自定义菜单后，微信会把点击事件推送给开发者，请注意，点击菜单弹出子菜单，不会产生上报。
    /// 如果Event=CLICK，那么EventKey就是事件Key值
    /// 如果Event=VIEW，那么EventKey就是设置的跳转URL
    /// </summary>
    public class WeChatMenuEvent : WeChatEventMsg
    {
        public CData EventKey { get; set; }
    }
}
