using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.User
{
    /// <summary>
    /// 获取某个用户属于哪个用户组
    /// </summary>
	[RequestPath("/cgi-bin/groups/getid")]
	[RequestMethod(RequestMethod.POST)]
	public class GetBelongUserGroup : AccessRequiredRequest<GetBelongUserGroupResponse>
    {
        public string OpenId { get; set; }
        public override string Data { get { return string.Format("{{\"openid\":\"{0}\"}}", this.OpenId); } }
    }
}
