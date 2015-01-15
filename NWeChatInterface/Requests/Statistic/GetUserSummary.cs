using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.Statistic
{
	[RequestPath("/datacube/getusersummary")]
	[RequestMethod(RequestMethod.POST)]
	public class GetUserSummary : AccessRequiredRequest<GetUserSummaryResponse>
	{
		public DateTime BeginDate { get; set; }
		public DateTime EndDate { get; set; }

		public override string Data
		{
			get
			{
				return string.Format("{{{0}, {1}}}",
				                     JsonHelper.WriteObject("begin_date", BeginDate.ToString("yyyy-MM-dd")),
				                     JsonHelper.WriteObject("end_date", EndDate.ToString("yyyy-MM-dd")));
			}
		}
	}
}
