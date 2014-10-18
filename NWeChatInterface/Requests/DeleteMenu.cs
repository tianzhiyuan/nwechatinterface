using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 删除自定义菜单
    /// </summary>
    public class DeleteMenu:IGetRequest<CommonResponse>
    {
        public string AccessToken { get; private set; }
        public DeleteMenu(string accessToken)
        {
            this.AccessToken = accessToken;
        }
        public string RequestUrl { get { return string.Format("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}", this.AccessToken); } }
    }
}
