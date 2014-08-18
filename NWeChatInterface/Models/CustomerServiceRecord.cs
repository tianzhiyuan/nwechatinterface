using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Models
{
    /// <summary>
    /// 操作ID(会化状态）定义
    /// </summary>
    public enum OperCode
    {
        /// <summary>
        /// 创建未接入会话
        /// </summary>
        NonAccessSession = 1000,
        /// <summary>
        /// 接入会话
        /// </summary>
        AccessSession = 1001,
        /// <summary>
        /// 主动发起会话
        /// </summary>
        StartSession = 1002,
        /// <summary>
        /// 关闭会话
        /// </summary>
        CloseSession = 1004,
        /// <summary>
        /// 抢接会话
        /// </summary>
        GrabSession = 1005,
        /// <summary>
        /// 公众号收到消息
        /// </summary>
        ReceiveMessage = 2001,
        /// <summary>
        /// 客服发送消息
        /// </summary>
        CustomerServiceSendMessage = 2002,
        /// <summary>
        /// 客服发送消息
        /// </summary>
        CustomerServiceReceiveMessage = 2003,
    }
    public class CustomerServiceRecord
    {
        /// <summary>
        /// 客服账号
        /// </summary>
        public string worker { get; set; }
        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 操作ID（会话状态），具体说明见下文
        /// </summary>
        public int opercode { get; set; }
        /// <summary>
        /// 操作时间，UNIX时间戳
        /// </summary>
        public long time { get; set; }
        /// <summary>
        /// 聊天记录
        /// </summary>
        public string text { get; set; }
    }
}
