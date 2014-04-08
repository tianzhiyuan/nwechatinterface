﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace NWeChatInterface.Messages
{
    /// <summary>
    /// 微信普通消息
    /// </summary>
    public class WeChatNormalMsg : WeChatBaseMsg
    {
        protected static XmlSerializer _serializer = new XmlSerializer(typeof(WeChatNormalMsg), new XmlRootAttribute("xml"));

        protected static Dictionary<string, XmlSerializer> _serializerCache =
            new Dictionary<string, XmlSerializer>();


        //public const string image = "image";
        //public const string voice = "voice";
        //public const string video = "video";
        //public const string location = "location";
        //public const string link = "link";
        //public const string @event = "event";
        static WeChatNormalMsg()
        {
            _serializerCache.Add(WeChatMessageTypes.text, new XmlSerializer(typeof(WeChatTextMsg), new XmlRootAttribute("xml")));
            _serializerCache.Add(WeChatMessageTypes.image, new XmlSerializer(typeof(WeChatImageMsg), new XmlRootAttribute("xml")));
            _serializerCache.Add(WeChatMessageTypes.voice, new XmlSerializer(typeof(WeChatVoiceMsg), new XmlRootAttribute("xml")));
            _serializerCache.Add(WeChatMessageTypes.video, new XmlSerializer(typeof(WeChatVideoMsg), new XmlRootAttribute("xml")));
            _serializerCache.Add(WeChatMessageTypes.location,
                                 new XmlSerializer(typeof(WeChatLocationMsg), new XmlRootAttribute("xml")));
            _serializerCache.Add(WeChatMessageTypes.link, new XmlSerializer(typeof(WeChatLinkMsg), new XmlRootAttribute("xml")));
            //_serializerCache.Add(WeChatMessageTypes.@event, new DataContractSerializer(typeof));
        }
        public long MsgId { get; set; }
        public static WeChatNormalMsg ReadFrom(string xmlDoc)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(xmlDoc));

            var msg = (WeChatNormalMsg)_serializer.Deserialize(stream);
            XmlSerializer realSerializer;
            stream.Position = 0;
            if (_serializerCache.TryGetValue(msg.MsgType, out realSerializer))
            {
                return (WeChatNormalMsg)realSerializer.Deserialize(stream);
            }
            throw new ArgumentException(string.Format("xml invalid"));
        }

        public override string Serialize()
        {
            XmlSerializer serializer;
            if (_serializerCache.TryGetValue(this.MsgType, out serializer))
            {
                var ms = new MemoryStream();
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                var setting = new XmlWriterSettings()
                {
                    OmitXmlDeclaration = true,
                    Encoding = Encoding.UTF8,
                    Indent = true
                };
                var xtw = System.Xml.XmlWriter.Create(ms, setting);
                serializer.Serialize(xtw, this, ns);
                ms.Seek(0, SeekOrigin.Begin);
                var sr = new StreamReader(ms);
                return sr.ReadToEnd();
            }
            throw new ArgumentNullException(string.Format("serializer not found for type {0}", this.GetType()));
        }
    }
}
