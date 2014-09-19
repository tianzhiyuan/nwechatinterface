using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Response
{
    public class SendMassMessageResponse : AbstractResponse
    {
        /// <summary>
        /// 群发消息ID
        /// </summary>
        public long msg_id { get; set; }
        /// <summary>
        /// 媒体文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb），次数为news，即图文消息
        /// </summary>
        public long type { get; set; }
    }
}
