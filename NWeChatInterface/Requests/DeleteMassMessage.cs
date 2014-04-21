using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 删除群发消息
    /// 请注意，只有已经发送成功的消息才能删除删除消息只是将消息的图文详情页失效，
    /// 已经收到的用户，还是能在其本地看到消息卡片。
    /// </summary>
    public class DeleteMassMessage:IPostRequest<AbstractResponse>
    {
        public DeleteMassMessage(string accessToken, string msgid)
        {
            this.AccessToken = accessToken;
            this.MsgId = msgid;
        }
        public string AccessToken { get; private set; }

        public string RequestUrl
        {
            get
            {
                return string.Format("https://api.weixin.qq.com//cgi-bin/message/mass/delete?access_token={0}",
                                     this.AccessToken);
            }
        }
        public string MsgId { get; private set; }
        public string Data { get { return string.Format("{{\"msgid\":{0}}}", this.MsgId); }}
    }
}
