using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 删除群发消息
    /// 请注意，只有已经发送成功的消息才能删除。删除消息只是将消息的图文详情页失效，
    /// 已经收到的用户，还是能在其本地看到消息卡片。 
    /// 另外，删除群发消息只能删除图文消息和视频消息，其他类型的消息一经发送，无法删除。
    /// </summary>
    public class DeleteMassMessage:IPostRequest<AbstractResponse>
    {
        public DeleteMassMessage(string accessToken, long msgid)
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
        public long MsgId { get; private set; }
        public string Data { get { return string.Format("{{\"msgid\":{0}}}", this.MsgId); }}
    }
}
