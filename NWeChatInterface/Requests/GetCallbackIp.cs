using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests
{
	/// <summary>
	/// 如果公众号基于安全等考虑，需要获知微信服务器的IP地址列表，以便进行相关限制，可以通过该接口获得微信服务器IP地址列表。
	/// </summary>
	[RequestPath("/cgi-bin/getcallbackip")]
	public class GetCallbackIp : AccessRequiredRequest<GetCallbackIpResponse>
	{
	}
}
