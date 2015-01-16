using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;
using Newtonsoft.Json;

namespace NWeChatInterface.Requests.Kf
{
	/// <summary>
	/// 开发者可以通过该接口为公众号删除客服帐号
	/// </summary>
	[RequestPath("/customservice/kfaccount/del")]
	[RequestMethod(RequestMethod.POST)]
	public class DeleteKfAccount : AccessRequiredRequest<CommonResponse>
	{
		[JsonProperty("kf_account")]
		public string Account { get; set; }
		[JsonProperty("nickname")]
		public string Nickname { get; set; }
		[JsonIgnore]
		public override string Data
		{
			get { return SerializeJson(this); }
		}
	}
}
