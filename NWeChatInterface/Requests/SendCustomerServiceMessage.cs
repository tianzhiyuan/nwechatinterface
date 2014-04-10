using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NWeChatInterface.Requests
{
    public class SendCustomerServiceMessage : IPostRequest<WeChatResponse>
    {
        public SendCustomerServiceMessage(string accessToken, CustomerServiceMessage message)
        {
            this.AccessToken = accessToken;
            this.Message = message;
        }
        public CustomerServiceMessage Message { get; private set; }
        public string AccessToken { get; private set; }

        public string RequestUrl
        {
            get
            {
                return string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}",
                                     this.AccessToken);
            }
        }

        public string Data
        {
            get
            {
                return JsonConvert.SerializeObject(this.Message, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }
    }
}
