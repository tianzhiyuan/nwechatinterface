using NWeChatInterface.Models;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.User
{
    /// <summary>
    /// 更新用户组名称
    /// </summary>
	[RequestPath("/cgi-bin/groups/update")]
	[RequestMethod(RequestMethod.POST)]
	public class UpdateUserGroupName : AccessRequiredRequest<CommonResponse>
    {
        
        public UserGroup Group { get; set; }
        
        public override string Data
        {
            get
            {
                return string.Format("{{'group':{{'id':{0},'name':'{1}'}}}}", this.Group.id, this.Group.name)
                             .Replace('\'', '\"');
            }
        }
    }
}
