using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using NWeChatInterface.Messages;
using Newtonsoft.Json;

namespace NWeChatInterface
{
    
    
    
    /// <summary>
    /// 微信推送消息基类，同时也是返回给微信时消息的基类
    /// </summary>
    public abstract class WeChatBaseMsg
    {
        /// <summary>
        /// 开发者微信号
        /// </summary>
        [JsonProperty("touser")]
        public CData ToUserName { get; set; }
        /// <summary>
        /// 发送着帐号OpenId
        /// </summary>
        [JsonIgnore]
        public CData FromUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonIgnore]
        public long CreateTime { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public DateTime CreatedAt
        {
            get { return Epoch.ConvertToLocalTime(this.CreateTime); }
            set { this.CreateTime = Epoch.ConvertToEpoch(value); }
        }

        /// <summary>
        /// 消息类型 <see cref="WeChatMessageTypes"/>
        /// </summary>
        [JsonProperty("msgtype")]
        public virtual CData MsgType { get; set; }

		public string Encrypt { get; set; }
        /// <summary>
        /// 序列化当前对象
        /// </summary>
        /// <returns></returns>
        public virtual string Serialize()
        {
            var type = this.GetType();
            XmlSerializer serializer;
            if (!_serializers.TryGetValue(type, out serializer))
            {
                lock (_lock)
                {
                    if (!_serializers.TryGetValue(type, out serializer))
                    {
                        serializer = new XmlSerializer(type, new XmlRootAttribute("xml"));
                        _serializers.Add(type, serializer);
                    }
                }
            }
            return this.Serialize(serializer);
        }
        protected static string GetMsgType(string xmlDoc)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlDoc);
            var typeNode = doc.SelectSingleNode("xml/MsgType").ChildNodes[0].Value;
            return typeNode;
        }
        
        protected string Serialize(XmlSerializer serializer)
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
        /// <summary>
        /// 由XML字符串反序列化为微信消息对象
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <returns></returns>
        public static WeChatBaseMsg LoadFrom(string xmlDoc)
        {
            var msgType = GetMsgType(xmlDoc);
            if (msgType == WeChatMessageTypes.EVENT)
            {
                return WeChatEventMsg.ReadFrom(xmlDoc);
            }
            return WeChatNormalMsg.ReadFrom(xmlDoc);
        }

        private static readonly object _lock = new object();
        private static readonly IDictionary<Type, XmlSerializer> _serializers = new Dictionary<Type, XmlSerializer>();
    }
    
    
    
    
    
    
    
    
    
    
}
