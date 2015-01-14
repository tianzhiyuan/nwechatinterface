using NWeChatInterface.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Requests
{
	/// <summary>
	/// 开发者通过本接口，根据AppID获取公众号中所设置的客服基本信息，包括客服工号、客服昵称、客服登录账号
	/// </summary>
	public class GetKfList : IGetRequest<GetKfListResponse>
	{
		public string AccessToken { get; private set; }
		public GetKfList(string accessToken)
		{
			this.AccessToken = accessToken;
		}
		public string RequestUrl { get { return string.Format("https://api.weixin.qq.com/cgi-bin/customservice/getkflist?access_token={0}", this.AccessToken); } }
	}
}
