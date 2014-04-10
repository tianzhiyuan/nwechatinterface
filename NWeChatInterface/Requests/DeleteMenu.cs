using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Requests
{
    public class DeleteMenu:IGetRequest<WeChatResponse>
    {
        public string AccessToken { get; private set; }
        public DeleteMenu(string accessToken)
        {
            this.AccessToken = accessToken;
        }
        public string RequestUrl { get { return string.Format("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}", this.AccessToken); } }
    }
}
