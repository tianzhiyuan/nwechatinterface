using NWeChatInterface.Response;
using Newtonsoft.Json;

namespace NWeChatInterface.Requests.Kf
{
	/// <summary>
	/// 设置客服信息
	/// </summary>
	[RequestPath("/customservice/kfaccount/update")]
	[RequestMethod(RequestMethod.POST)]
	public class UpdateKfAccount : AccessRequiredRequest<CommonResponse>
	{
		[JsonProperty("kf_account")]
		public string KfAccount { get; set; }
		[JsonProperty("nickname")]
		public string NickName { get; set; }
		[JsonProperty("password")]
		public string Password { get; set; }
		
		public override string Data { get { return JsonConvert.SerializeObject(this); } }
	}
}
