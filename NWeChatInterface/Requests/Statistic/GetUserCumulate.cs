using NWeChatInterface.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Requests.Statistic
{
	[RequestPath("/datacube/getusercumulate")]
	[RequestMethod(RequestMethod.POST)]
	public class GetUserCumulate : AccessRequiredRequest<GetUserCumulateResponse>
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
