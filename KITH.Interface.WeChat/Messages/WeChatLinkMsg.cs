using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KITH.Interface.WeChat.Messages
{
    /// <summary>
    /// 微信链接消息
    /// </summary>
    public class WeChatLinkMsg : WeChatNormalMsg
    {

        public CData Title { get; set; }

        public CData Description { get; set; }

        public CData Url { get; set; }
    }
}
