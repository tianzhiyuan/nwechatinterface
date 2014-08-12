using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Messages
{
    /// <summary>
    /// 微信多媒体消息
    /// </summary>
    public abstract class WeChatMediaMsg : WeChatNormalMsg
    {
        /// <summary>
        /// 消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public CData MediaId { get; set; }
    }
}
