using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Response
{
	public class GetUserSummaryResponse : AbstractResponse
	{
		public UserSummury[] list { get; set; }
	}

	public class UserSummury
	{
		public string ref_date { get; set; }
		public int user_source { get; set; }
		public int new_user { get; set; }
		public int cancel_user { get; set; }
	}
}
