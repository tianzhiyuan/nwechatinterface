using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.User
{
    /// <summary>
    /// 创建用户分组
    /// </summary>
    [RequestMethod(RequestMethod.POST)]
	[RequestPath("/cgi-bin/groups/create")]
	public class CreateUserGroup : AccessRequiredRequest<CreateUserGroupResponse>
    {
        public string GroupName { get; set; }
        public override string Data { get { return string.Format("{{'group':{{'name':'{0}'}}}}", this.GroupName).Replace('\'', '"'); } }
    }
}
