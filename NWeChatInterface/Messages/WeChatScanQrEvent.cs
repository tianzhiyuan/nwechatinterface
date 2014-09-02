using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NWeChatInterface.Messages
{
    /// <summary>
    /// 用户扫描
    /// </summary>
    public class WeChatScanQrEvent : WeChatEventMsg
    {
        /// <summary>
        /// 事件KEY值，是一个32位无符号整数，即创建二维码时的二维码scene_id
        /// </summary>
        public CData EventKey { get; set; }
        /// <summary>
        /// 二维码的ticket，可用来换取二维码图片
        /// </summary>
        public CData Ticket { get; set; }
        [XmlIgnore]
        public string Param{get { return EventKey.ToString().Split('_')[1]; }}
    }
}
