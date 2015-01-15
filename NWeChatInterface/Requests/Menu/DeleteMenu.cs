using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.Menu
{
    /// <summary>
    /// 删除自定义菜单
    /// </summary>
	[RequestPath("/cgi-bin/menu/delete")]
	public class DeleteMenu : AccessRequiredRequest<CommonResponse>
    {
    }
}
