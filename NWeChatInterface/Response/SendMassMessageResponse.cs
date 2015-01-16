using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Requests.Message;

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
        public string type { get; set; }

		/// <summary>
		/// 消息状态 SEND_SUCCESS表示发送成功 只有在调用 <see cref="GetMassMessageStatus"/>时才有返回
		/// </summary>
		public string msg_status { get; set; }
    }
}
