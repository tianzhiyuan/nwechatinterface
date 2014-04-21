using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 群发消息
    /// </summary>
    public class SendMassMessage:IPostRequest<AbstractResponse>
    {

        protected SendMassMessage(string accessToken)
        {
            this.AccessToken = accessToken;
        }
        public SendMassMessage(string accessToken, int group_id) : this(accessToken)
        {
            this.SendByGroupId = true;
            this.GroupId = group_id;
        }
        public SendMassMessage(string accessToken, string[] userOpenIds) : this(accessToken)
        {
            this.SendByGroupId = false;
            this.UserIds = userOpenIds;
        }
        public bool SendByGroupId { get; private set; }
        public string[] UserIds { get; private set; }
        public int GroupId { get; private set; }
        public string MediaId { get; private set; }
        public string AccessToken { get; private set; }

        public string RequestUrl
        {
            get
            {
                return string.Format("https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token={0}",
                                     this.AccessToken);
            }
        }

        public string Data
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append("{");
                if (this.SendByGroupId)
                {
                    sb.AppendFormat("'filter':{{'group_id':'{0}'}},", this.GroupId);
                }
                else
                {
                    sb.AppendFormat("'touser':[{0}]",
                                    string.Join(",", this.UserIds.Select(o => string.Format("\"{0}\"", o))));
                }
                sb.AppendFormat("'mpnews':{{'media_id':'{0}'}},", this.MediaId);
                sb.AppendFormat("'msgtype':'mpnews'");
                sb.Append("}");
                sb.Replace('\'', '"');
                return sb.ToString();
            }
        }
    }
}
