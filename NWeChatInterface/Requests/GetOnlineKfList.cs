using NWeChatInterface.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Requests
{
	/// <summary>
	/// 开发者通过本接口，根据AppID获取公众号中当前在线的客服的接待信息，
	/// 包括客服工号、客服登录账号、客服在线状态（手机在线、PC客户端在线、手机和PC客户端全都在线）、
	/// 客服自动接入最大值、客服当前接待客户数。
	/// 开发者利用本接口提供的信息，结合客服基本信息，可以开发例如“指定客服接待”等功能；
	/// 结合会话记录，可以开发”在线客服实时服务质量监控“等功能。
	/// </summary>
	public class GetOnlineKfList : IGetRequest<GetOnlineKfListResponse>
	{

		public GetOnlineKfList(string accessToken)
		{
			this.AccessToken = accessToken;
		}
		public string AccessToken { get; private set; }
		public string RequestUrl { get { return string.Format("https://api.weixin.qq.com/cgi-bin/customservice/getonlinekflist?access_token={0}", AccessToken); } }
	}
}
