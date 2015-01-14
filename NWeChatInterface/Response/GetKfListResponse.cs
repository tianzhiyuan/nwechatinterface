using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Models;

namespace NWeChatInterface.Response
{
	public class GetKfListResponse : AbstractResponse
	{
		public KfAccount[] kf_list { get; set; }
	}
}
