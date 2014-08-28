using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 群发消息
    /// 在公众平台网站上，为订阅号提供了每天一条的群发权限，为服务号提供每月（自然月）4条的群发权限。
    /// 
    /// 
    /// 1、该接口暂时仅提供给已微信认证的服务号
    /// 2、虽然开发者使用高级群发接口的每日调用限制为100次，但是用户每月只能接收4条，请小心测试
    /// 3、无论在公众平台网站上，还是使用接口群发，用户每月只能接收4条群发消息，多于4条的群发将对该用户发送失败。
    /// 4、具备微信支付权限的公众号，在使用高级群发接口上传、群发图文消息类型时，可使用a标签加入外链
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
