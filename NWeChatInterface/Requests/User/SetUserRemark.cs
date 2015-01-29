using System.Text;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.User
{
    /// <summary>
    /// 设置用户备注
    /// </summary>
	[RequestPath("/cgi-bin/user/info/updateremark")]
	[RequestMethod(RequestMethod.POST)]
	public class SetUserRemark : AccessRequiredRequest<CommonResponse>
    {
        public string OpenId { get; set; }
        public string Remark { get; set; }

        public override string Data
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(JsonHelper.WriteStart());
                sb.AppendFormat("{0},{1}", JsonHelper.WriteObject("openid", this.OpenId),
                                JsonHelper.WriteObject("remark", this.Remark));
                sb.Append(JsonHelper.WriteEnd());
                return sb.ToString();
            }
        }
    }
}
