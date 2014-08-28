using NWeChatInterface.Models;

namespace NWeChatInterface.Response
{
    public class CreateUserGroupResponse : WeChatResponse
    {
        public UserGroup group { get; set; }
    }
}
