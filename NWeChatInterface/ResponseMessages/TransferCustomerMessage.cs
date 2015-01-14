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
		/// <summary>
		/// 如果您有多个客服人员同时登陆了多客服并且开启了自动接入在进行接待，
		/// 每一个客户的消息转发给多客服时，
		/// 多客服系统会将客户分配给其中一个客服人员。
		/// 如果您希望将某个客户的消息转给指定的客服来接待，
		/// 可以在返回transfer_customer_service消息时附上TransInfo信息指定一个客服帐号。 
		/// 需要注意，如果指定的客服没有接入能力(不在线、没有开启自动接入或者自动接入已满)，
		/// 该用户会一直等待指定客服有接入能力后才会被接入，而不会被其他客服接待。
		/// 建议在指定客服时，先查询客服的接入能力（获取在线客服接待信息接口），
		/// 指定到有能力接入的客服，保证客户能够及时得到服务。
		/// </summary>
		public TransferInfo TransInfo { get; set; }
    }

	public class TransferInfo
	{
		public CData KfAccount { get; set; }
	}
}
