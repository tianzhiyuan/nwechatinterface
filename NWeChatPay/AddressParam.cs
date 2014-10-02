using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatPay
{
    /// <summary>
    /// 生成微信地址共享Json参数需要的参数
    /// </summary>
    public class AddressParam
    {
        /// <summary>
        /// AppId
        /// 必填
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// AccessToken
        /// 必填
        /// oauth获取的token，获取token的scope是snsapi_base
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// 签名使用的url必须是调用时所在页面的url，此url域名要与填写Oauth2.0授权域名一致
        /// 参与签名使用的url必须带上微信服务器返回的code和state参数
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 时间戳
        /// 默认为当前时间
        /// </summary>
        public DateTime TimeStamp { get; set; }
        /// <summary>
        /// 随机数
        /// 如果为空，则会自动填充
        /// </summary>
        public string NonceStr { get; set; }
    }
}
