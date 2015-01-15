using NWeChatInterface.Response;
using Newtonsoft.Json;

namespace NWeChatInterface.Requests.Kf
{
	[RequestMethod(RequestMethod.POST)]
	[RequestPath("/customservice/kfaccount/add")]
	public class CreateKfAccount : AccessRequiredRequest<CommonResponse>
	{
		[JsonProperty("kf_account")]
		public string KfAccount { get; set; }
		[JsonProperty("nickname")]
		public string NickName { get; set; }
		[JsonProperty("password")]
		public string Password { get; set; }
		public override string Data { get { return SerializeJson(this); } }
	}
}
