using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Models;

namespace NWeChatInterface.Response
{
	public class GetOnlineKfListResponse : AbstractResponse
	{
		public KfAccount[] kf_online_list { get; set; }
	}
}
