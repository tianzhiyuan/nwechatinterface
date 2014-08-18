using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface
{
    /// <summary>
    /// 微信推送的事件类型
    /// </summary>
    public static class WeChatEventTypes
    {
        /// <summary>
        /// 关注事件 或 用户未关注时扫描带参二维码
        /// </summary>
        public const string EVENT_SUBSCRIBE = "subscribe";
        /// <summary>
        /// 取消关注
        /// </summary>
        public const string EVENT_UNSUBSCRIBE = "unsubscribe";
        /// <summary>
        /// 用户已关注时扫描二维码
        /// </summary>
        public const string EVENT_SCAN = "SCAN";
        /// <summary>
        /// 上报地理位置
        /// </summary>
        public const string EVENT_LOCATION = "LOCATION";
        /// <summary>
        /// 自定义菜单点击事件 
        /// </summary>
        public const string EVENT_CLICK = "CLICK";
        /// <summary>
        /// 点击自定义菜单链接事件
        /// </summary>
        public const string EVENT_VIEW = "VIEW";
        /// <summary>
        /// 群发结束消息推送
        /// </summary>
        public const string EVENT_MASSSENDJOBFINISH = "MASSSENDJOBFINISH";
    }
}
