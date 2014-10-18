using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;
using Newtonsoft.Json;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 当用户主动发消息给公众号的时候（包括发送信息、点击自定义菜单、订阅事件、扫描二维码事件、支付成功事件、用户维权），
    /// 微信将会把消息数据推送给开发者，
    /// 开发者在一段时间内（目前修改为48小时）可以调用客服消息接口，
    /// 通过POST一个JSON数据包来发送消息给普通用户，在48小时内不限制发送次数。
    /// 此接口主要用于客服等有人工消息处理环节的功能，方便开发者为用户提供更加优质的服务。
    /// </summary>
    public class SendCustomerServiceMessage : IPostRequest<CommonResponse>
    {
        public SendCustomerServiceMessage(string accessToken, IResponseMessage message)
        {
            this.AccessToken = accessToken;
            this.Message = message;
        }
        public IResponseMessage Message { get; private set; }
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
