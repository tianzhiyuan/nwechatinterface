using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public const string TEXT = "text";
        /// <summary>
        /// 图片
        /// </summary>
        public const string IMAGE = "image";
        /// <summary>
        /// 音频
        /// </summary>
        public const string VOICE = "voice";
        /// <summary>
        /// 视频
        /// </summary>
        public const string VIDEO = "video";
        /// <summary>
        /// 位置
        /// </summary>
        public const string LOCATION = "location";
        /// <summary>
        /// 链接
        /// </summary>
        public const string LINK = "link";
        /// <summary>
        /// 事件
        /// </summary>
        public const string EVENT = "event";
        /// <summary>
        /// 图文
        /// </summary>
        public const string NEWS = "news";
        /// <summary>
        /// 音乐消息，在发送客服消息中会用到
        /// </summary>
        public const string MUSIC = "music";
    }
}
