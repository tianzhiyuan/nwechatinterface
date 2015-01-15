using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.User
{
    /// <summary>
    /// 根据用户openid获取用户所属分组
    /// </summary>
	[RequestPath("/cgi-bin/groups/getid")]
	public class GetUserBelongGroup : AccessRequiredRequest<GetUserBelongGroupResponse>
    {
        public string OpenId { get; set; }
        
        public override string Data
        {
            get { return string.Format("{{'openid':'{0}'}}", this.OpenId).Replace(@"'", "\""); }

        }
    }
}
