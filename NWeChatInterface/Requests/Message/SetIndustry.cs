using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.Message
{
	/// <summary>
	/// 设置所属行业
	/// 设置行业可在MP中完成，每月可修改行业1次
	/// </summary>
	[RequestPath("/cgi-bin/template/api_set_industry")]
	[RequestMethod(RequestMethod.POST)]
	public class SetIndustry : AccessRequiredRequest<CommonResponse>
	{
		public int IndustryId1 { get; set; }
		public int IndustryId2 { get; set; }
		public override string Data
		{
			get
			{
				return string.Format("{{{0},{1}}}", JsonHelper.WriteObject("industry_id1", IndustryId1.ToString()),
									 JsonHelper.WriteObject("industry_id2", IndustryId2.ToString()));
			}
		}
	}
}
