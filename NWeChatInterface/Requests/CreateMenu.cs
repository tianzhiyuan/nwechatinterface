
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Models;
using NWeChatInterface.Response;
using Newtonsoft.Json;
namespace NWeChatInterface.Requests
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
    public class CreateMenu:IPostRequest<CommonResponse>
    {
        public CreateMenu(string accessToken, Menu menu)
        {
            this.AccessToken = accessToken;
            this.Menu = menu;
        }
        public Menu Menu { get; private set; }
        public string AccessToken { get; private set; }
        public string RequestUrl { get { return string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", this.AccessToken); } }

        public string Data
        {
            get
            {
                return JsonConvert.SerializeObject(this.Menu,
                                                   new JsonSerializerSettings()
                                                       {
                                                           NullValueHandling = NullValueHandling.Ignore,
                                                           ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                                       });
            }
        }
    }
}
