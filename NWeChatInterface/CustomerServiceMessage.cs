using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface
{
    /// <summary>
    /// class that indicate a customer service message
    /// </summary>
    public abstract class CustomerServiceMessage
    {
        /// <summary>
        /// 目标用户openid
        /// </summary>
        public string touser { get; set; }
        /// <summary>
        /// 消息类型<see cref="WeChatMessageTypes"/>
        /// </summary>
        public string msgtype { get; set; }
        
    }
}
