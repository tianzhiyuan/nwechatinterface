using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;
using Newtonsoft.Json;

namespace NWeChatInterface.Requests.Message
{
	/// <summary>
	/// 查询群发消息发送状态
	/// </summary>
	[RequestPath("/cgi-bin/message/mass/get")]
	[RequestMethod(RequestMethod.POST)]
	public class GetMassMessageStatus : AccessRequiredRequest<SendMassMessageResponse>
	{
		[JsonProperty("msg_id")]
		public int MsgId { get; set; }
		public override string Data
		{
			get { return string.Format("{{{0}}}", JsonHelper.WriteObject("msg_id", MsgId.ToString())); }
		}
	}
}
