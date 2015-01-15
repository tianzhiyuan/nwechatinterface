using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.Menu
{
    /// <summary>
    /// 获取当前的自定义菜单
    /// </summary>
	[RequestPath("/cgi-bin/menu/get")]
	public class GetMenu : AccessRequiredRequest<MenuResponse>
    {

    }
}
