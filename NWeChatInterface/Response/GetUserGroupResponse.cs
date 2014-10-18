using NWeChatInterface.Models;

namespace NWeChatInterface.Response
{
    public class GetUserGroupResponse : AbstractResponse
    {
        public UserGroup[] groups { get; set; }
    }
}
