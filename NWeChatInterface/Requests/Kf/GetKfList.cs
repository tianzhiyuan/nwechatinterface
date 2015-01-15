using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.Kf
{
	/// <summary>
	/// 开发者通过本接口，根据AppID获取公众号中所设置的客服基本信息，包括客服工号、客服昵称、客服登录账号
	/// </summary>
	[RequestPath("/cgi-bin/customservice/getkflis")]
	public class GetKfList : AccessRequiredRequest<GetKfListResponse>
	{
		
	}
}
