using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests
{
	public class UploadKfHeadimg : IWeChatRequest<CommonResponse>
	{
		public string AccessToken { get; private set; }
		public string KfAccount { get; private set; }
		public UploadKfHeadimg(string accessToken, string account)
		{
			this.AccessToken = accessToken;
			this.KfAccount = account;
		}

		public string RequestUrl
		{
			get
			{
				return string.Format(
					"http://api.weixin.qq.com/customservice/kfacount/uploadheadimg?access_token={0}&kf_account={1}", AccessToken,
					KfAccount);
			}
		}
	}
}
