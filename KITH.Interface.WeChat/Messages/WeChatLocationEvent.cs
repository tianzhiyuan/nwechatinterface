using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KITH.Interface.WeChat.Messages
{
    /// <summary>
    /// 微信上报地理位置事件
    /// </summary>
    public class WeChatLocationEvent : WeChatEventMsg
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Precision { get; set; }
    }


}
