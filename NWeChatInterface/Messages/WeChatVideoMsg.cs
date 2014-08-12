using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Messages
{
    /// <summary>
    /// 微信视频消息
    /// </summary>
    public class WeChatVideoMsg : WeChatMediaMsg
    {
        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public CData ThumbMediaId { get; set; }
        
        public override CData MsgType
        {
            get { return WeChatMessageTypes.VIDEO; }
        }
    }
}
