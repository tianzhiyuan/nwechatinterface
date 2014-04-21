using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace NWeChatInterface.Messages
{
    /// <summary>
    /// 微信事件推送基础类，
    /// 同时也是：
    /// 微信关注/取消关注事件
    /// </summary>
    public class WeChatEventMsg : WeChatBaseMsg
    {
        /// <summary>
        /// 事件类型<see cref="WeChatEventTypes"/>
        /// </summary>
        public CData Event { get; set; }

        protected static XmlSerializer _serializer = new XmlSerializer(typeof(WeChatEventMsg),
                                                                       new XmlRootAttribute("xml"));

        private static Dictionary<string, XmlSerializer> _serializerCache = new Dictionary<string, XmlSerializer>();

        private static XmlSerializer _qrsceneSerializer = new XmlSerializer(typeof(WeChatScanQrEvent),
                                                                            new XmlRootAttribute("xml"));
        static WeChatEventMsg()
        {
            _serializerCache.Add(WeChatEventTypes.scan,
                                 new XmlSerializer(typeof (WeChatScanQrEvent), new XmlRootAttribute("xml")));
            _serializerCache.Add(WeChatEventTypes.location,
                                 new XmlSerializer(typeof (WeChatLocationEvent), new XmlRootAttribute("xml")));
            var menuSerializer = new XmlSerializer(typeof (WeChatMenuEvent), new XmlRootAttribute("xml"));
            _serializerCache.Add(WeChatEventTypes.click, menuSerializer);
            _serializerCache.Add(WeChatEventTypes.view, menuSerializer);
            _serializerCache.Add(WeChatEventTypes.masssendjobfinish,
                                 new XmlSerializer(typeof (WeChatMassSendJobEvent), new XmlRootAttribute("xml")));
        }
        public static WeChatEventMsg ReadFrom(string xmlDoc)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(xmlDoc));
            var msg = (WeChatEventMsg)_serializer.Deserialize(stream);
            if (msg.Event == WeChatEventTypes.unsubscribe)
            {
                return msg;
            }
            if (msg.Event == WeChatEventTypes.subscribe)
            {
                if (xmlDoc.Contains("EventKey"))
                {
                    //带参二维码扫描事件
                    stream.Position = 0;
                    return (WeChatEventMsg)_qrsceneSerializer.Deserialize(stream);
                }
                return msg;
            }
            XmlSerializer realSerializer;
            if (_serializerCache.TryGetValue(msg.Event, out realSerializer))
            {
                stream.Position = 0;
                return (WeChatEventMsg)realSerializer.Deserialize(stream);
            }
            throw new ArgumentException(string.Format("failed to deserialize obj with xml{0}", xmlDoc));
        }

        public override string Serialize()
        {
            XmlSerializer serializer = null;
            if (this.MsgType == WeChatEventTypes.unsubscribe)
            {
                serializer = _serializer;
            }
            else if (this.MsgType == WeChatEventTypes.subscribe)
            {
                serializer = _serializer;
            }
            else
            {
                _serializerCache.TryGetValue(this.MsgType, out serializer);
            }
            if (serializer == null)
            {
                throw new ArgumentNullException(string.Format("serializer not found for type {0}", this.GetType()));
            }

            return base.Serialize(_serializer);

        }
    }
}
