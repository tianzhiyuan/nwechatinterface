using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Response
{
	public class GetCallbackIpResponse : AbstractResponse
	{
		public string ip_list { get; set; }
	}
}
