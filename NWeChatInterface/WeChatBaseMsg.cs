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
    /// 
    /// 被动响应消息和客服消息基类
    /// 注意如果是被动响应消息，回复格式为XML，如果为客服消息回复格式是json
    /// 
    /// 现在有微信公众号客服软件，客服消息应用场景不大
    /// 客服消息：
    /// 当用户主动发消息给公众号的时候（包括发送信息、点击自定义菜单、订阅事件、扫描二维码事件、支付成功事件、用户维权），
    /// 微信将会把消息数据推送给开发者，开发者在一段时间内（目前修改为48小时）可以调用客服消息接口，
    /// 通过POST一个JSON数据包来发送消息给普通用户，在48小时内不限制发送次数。
    /// 此接口主要用于客服等有人工消息处理环节的功能，方便开发者为用户提供更加优质的服务。
    /// 
    /// 
    /// 被动响应消息
    /// 对于每一个POST请求，开发者在响应包中返回特定XML结构，
    /// 对该消息进行响应（现支持回复文本、图片、图文、语音、视频、音乐）。
    /// 请注意，回复图片等多媒体消息时需要预先上传多媒体文件到微信服务器。
    /// </summary>
    public abstract class WeChatBaseMsg
    {
        /// <summary>
        /// 发送着帐号OpenId
        /// </summary>
        [JsonIgnore]
        public CData FromUserName { get; set; }
        /// <summary>
        /// 开发者微信号
        /// </summary>
        [JsonProperty("touser")]
        public CData ToUserName { get; set; }
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
