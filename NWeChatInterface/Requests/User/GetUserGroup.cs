using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.User
{
    /// <summary>
    /// 获取所有用户分组
    /// </summary>
	[RequestPath("/cgi-bin/groups/get")]
	public class GetUserGroup : AccessRequiredRequest<GetUserGroupResponse>
    {
        
    }
}
