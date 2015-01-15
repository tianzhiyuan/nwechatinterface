using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.Kf
{
	/// <summary>
	/// 开发者通过本接口，根据AppID获取公众号中当前在线的客服的接待信息，
	/// 包括客服工号、客服登录账号、客服在线状态（手机在线、PC客户端在线、手机和PC客户端全都在线）、
	/// 客服自动接入最大值、客服当前接待客户数。
	/// 开发者利用本接口提供的信息，结合客服基本信息，可以开发例如“指定客服接待”等功能；
	/// 结合会话记录，可以开发”在线客服实时服务质量监控“等功能。
	/// </summary>
	[RequestPath("/cgi-bin/customservice/getonlinekflist")]
	public class GetOnlineKfList : AccessRequiredRequest<GetOnlineKfListResponse>
	{

		
	}
}
