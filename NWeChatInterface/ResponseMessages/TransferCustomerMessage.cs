using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.ResponseMessages
{
    /// <summary>
    /// 如果公众号处于开发模式，需要在接收到用户发送的消息时，
    /// 返回一个MsgType为transfer_customer_service的消息，
    /// 微信服务器在收到这条消息时，会把这次发送的消息转到多客服系统。
    /// 用户被客服接入以后，客服关闭会话以前，处于会话过程中，用户发送的消息均会被直接转发至客服系统。
    /// </summary>
    public class TransferCustomerMessage : WeChatReponseMessage
    {
        public override CData MsgType
        {
            get { return WeChatMessageTypes.TRANSFER_CUSTOMER_SERVICE; }
        }
    }
}
