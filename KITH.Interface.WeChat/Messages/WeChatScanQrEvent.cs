using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace KITH.Interface.WeChat.Messages
{
    /// <summary>
    /// 用户扫描
    /// </summary>
    public class WeChatScanQrEvent : WeChatEventMsg
    {
        public CData EventKey { get; set; }
        public CData Ticket { get; set; }
        [XmlIgnore]
        public string Param{get { return EventKey.ToString().Split('_')[1]; }}
    }
}
