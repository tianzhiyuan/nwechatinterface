﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Messages
{
    /// <summary>
    /// 微信位置消息
    /// </summary>
    public class WeChatLocationMsg : WeChatNormalMsg
    {

        public decimal Location_X { get; set; }

        public decimal Location_Y { get; set; }

        public int Scale { get; set; }

        public CData Label { get; set; }
        public override CData MsgType
        {
            get { return WeChatMessageTypes.LOCATION; }
        }
    }
}
