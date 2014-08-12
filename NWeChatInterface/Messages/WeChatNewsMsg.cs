using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NWeChatInterface.Messages
{
    public class Articles : List<item>
    {

    }
    public class item
    {
        public CData Title { get; set; }
        public CData Description { get; set; }
        public CData PicUrl { get; set; }
        public CData Url { get; set; }
    }
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
