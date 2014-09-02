using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using NWeChatInterface.Models;

namespace NWeChatInterface.Messages
{
    
    /// <summary>
    /// 微信图文消息
    /// </summary>
    public class WeChatNewsMsg : WeChatBaseMsg
    {
        /// <summary>
        /// 图文消息个数，限制为10条以内
        /// </summary>
        public int ArticleCount { get; set; }
        public Articles Articles { get; set; }
        private static readonly XmlSerializer _serializer = new XmlSerializer(typeof (WeChatNewsMsg), new XmlRootAttribute("xml")); 
        public override string Serialize()
        {
            return base.Serialize(_serializer);
        }
        public override CData MsgType
        {
            get { return WeChatMessageTypes.NEWS; }
        }
    }
}
