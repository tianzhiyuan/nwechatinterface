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

namespace NWeChatInterface
{
    
    /// <summary>
    /// 微信推送消息类型
    /// </summary>
    public class WeChatMessageTypes
    {
        /// <summary>
        /// 文本类型
        /// </summary>
        public const string text = "text";
        /// <summary>
        /// 图片
        /// </summary>
        public const string image = "image";
        /// <summary>
        /// 音频
        /// </summary>
        public const string voice = "voice";
        /// <summary>
        /// 视频
        /// </summary>
        public const string video = "video";
        /// <summary>
        /// 位置
        /// </summary>
        public const string location = "location";
        /// <summary>
        /// 链接
        /// </summary>
        public const string link = "link";
        /// <summary>
        /// 事件
        /// </summary>
        public const string @event = "event";
        /// <summary>
        /// 图文
        /// </summary>
        public const string news = "news";
        /// <summary>
        /// 音乐消息，在发送客服消息中会用到
        /// </summary>
        public const string music = "music";
    }
    /// <summary>
    /// 微信推送的事件类型
    /// </summary>
    public class WeChatEventTypes
    {
        /// <summary>
        /// 关注事件 或 用户未关注时扫描带参二维码
        /// </summary>
        public const string subscribe = "subscribe";
        /// <summary>
        /// 取消关注
        /// </summary>
        public const string unsubscribe = "unsubscribe";
        /// <summary>
        /// 用户已关注时扫描二维码
        /// </summary>
        public const string scan = "SCAN";
        /// <summary>
        /// 上报地理位置
        /// </summary>
        public const string location = "LOCATION";
        /// <summary>
        /// 自定义菜单点击事件 
        /// </summary>
        public const string click = "CLICK";
        /// <summary>
        /// 点击自定义菜单链接事件
        /// </summary>
        public const string view = "VIEW";
    }
    /// <summary>
    /// 微信推送消息基础类
    /// </summary>
    public abstract class WeChatBaseMsg
    {
        /// <summary>
        /// 发送着帐号OpenId
        /// </summary>
        public CData FromUserName { get; set; }
        /// <summary>
        /// 开发者微信号
        /// </summary>
        public CData ToUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public long CreateTime { get; set; }
        [XmlIgnore]
        public DateTime CreatedAt { get { return new DateTime(1970, 1, 1).AddSeconds(this.CreateTime); } }
        /// <summary>
        /// 消息类型 <see cref="WeChatMessageTypes"/>
        /// </summary>
        public CData MsgType { get; set; }
        /// <summary>
        /// 序列化当前对象
        /// </summary>
        /// <returns></returns>
        public abstract string Serialize();
        protected static string GetMsgType(string xmlDoc)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlDoc);
            var typeNode = doc.SelectSingleNode("xml/MsgType").ChildNodes[0].Value;
            return typeNode;
        }
        
        protected virtual string Serialize(XmlSerializer serializer)
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
            if (msgType == WeChatMessageTypes.@event)
            {
                return WeChatEventMsg.ReadFrom(xmlDoc);
            }
            return WeChatNormalMsg.ReadFrom(xmlDoc);
        }
    }
    
    
    
    
    
    
    
    
    
    
}
