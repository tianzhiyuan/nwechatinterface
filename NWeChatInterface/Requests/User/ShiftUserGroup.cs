using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.User
{
    /// <summary>
    /// 移动用户分组
    /// </summary>
	[RequestPath("/cgi-bin/groups/members/update")]
	[RequestMethod(RequestMethod.POST)]
	public class ShiftUserGroup : AccessRequiredRequest<CommonResponse>
    {
        public string OpenId { get; set; }
        public int ToGroupId { get; set; }
        public override string Data { get { return string.Format("{{'openid':'{0}','to_groupid':{1}}}", this.OpenId, this.ToGroupId).Replace('\'', '"'); } }
    }
}
