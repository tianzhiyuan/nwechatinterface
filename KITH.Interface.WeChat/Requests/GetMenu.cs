using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Results;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 获取当前的自定义菜单
    /// </summary>
    public class GetMenu : IGetRequest<MenuResult>
    {
        public string AccessToken { get; private set; }

        public GetMenu(string accessToken)
        {
            this.AccessToken = accessToken;
        }

        public string RequestUrl
        {
            get { return string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", this.AccessToken); }
        }
    }
}
