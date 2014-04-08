using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Messages
{
    /// <summary>
    /// 微信图片消息
    /// </summary>
    public class WeChatImageMsg : WeChatMediaMsg
    {
        public CData PicUrl { get; set; }

    }
}
