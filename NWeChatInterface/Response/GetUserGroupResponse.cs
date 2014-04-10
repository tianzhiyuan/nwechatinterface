using NWeChatInterface.Models;

namespace NWeChatInterface.Response
{
    public class GetUserGroupResponse:WeChatResponse
    {
        public UserGroup[] groups { get; set; }
    }
}
