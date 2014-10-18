using NWeChatInterface.Models;

namespace NWeChatInterface.Response
{
    public class CreateUserGroupResponse : AbstractResponse
    {
        public UserGroup group { get; set; }
    }
}
