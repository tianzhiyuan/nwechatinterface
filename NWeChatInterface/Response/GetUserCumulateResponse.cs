using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Response
{
	public class GetUserCumulateResponse : AbstractResponse
	{
		public CumulateUser[] list { get; set; }
	}
	public class CumulateUser
	{
		public string ref_date { get; set; }
		public int cumulate_user { get; set; }
	}
}
