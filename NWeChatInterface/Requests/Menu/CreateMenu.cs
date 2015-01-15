using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.Menu
{
    /// <summary>
    /// 创建自定义菜单接口
    /// 自定义菜单最多包括3个一级菜单，
    /// 每个一级菜单最多包含5个二级菜单。
    /// 一级菜单最多4个汉字，二级菜单最多7个汉字，
    /// 多出来的部分将会以“...”代替。
    /// 请注意，创建自定义菜单后，由于微信客户端缓存，需要24小时微信客户端才会展现出来。
    /// 建议测试时可以尝试取消关注公众账号后再次关注，则可以看到创建后的效果。
    /// </summary>
    [RequestMethod(RequestMethod.POST)]
	[RequestPath("/cgi-bin/menu/create")]
	public class CreateMenu : AccessRequiredRequest<CommonResponse>
    {
        public Models.Menu Menu { get; set; }

        public override string Data
        {
            get
            {
                return SerializeJson(Menu);
            }
        }
    }
}
