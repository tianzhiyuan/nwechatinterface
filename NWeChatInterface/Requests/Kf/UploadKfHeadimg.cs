using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.Kf
{
	/// <summary>
	/// TODO
	/// </summary>
	[RequestPath("/customservice/kfacount/uploadheadimg")]
	public class UploadKfHeadimg : AccessRequiredRequest<CommonResponse>
	{
		public string KfAccount { get; set; }
		

		public override string Param
		{
			get
			{
				return string.Format(
					"access_token={0}&kf_account={1}", AccessToken,
					KfAccount);
			}
		}
	}
}
