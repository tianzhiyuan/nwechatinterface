using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 设置用户备注
    /// </summary>
    public class SetUserRemark : IPostRequest<CommonResponse>
    {
        public string AccessToken { get; private set; }
        public string OpenId { get; private set; }
        public string Remark { get; private set; }
        public SetUserRemark(string accessToken, string openId, string remark)
        {
            this.AccessToken = accessToken;
            this.OpenId = openId;
            this.Remark = remark;
        }

        public string RequestUrl
        {
            get
            {
                return string.Format("https://api.weixin.qq.com/cgi-bin/user/info/updateremark?access_token={0}",
                                     this.AccessToken);
            }
        }

        public string Data
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(JsonHelper.WriteStart());
                sb.AppendFormat("{0},{1}", JsonHelper.WriteObject("openid", this.OpenId),
                                JsonHelper.WriteObject("remark", this.Remark));
                sb.Append(JsonHelper.WriteEnd());
                return sb.ToString();
            }
        }
    }
}
