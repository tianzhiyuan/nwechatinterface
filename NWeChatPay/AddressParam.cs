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
        /// </summary>
        public string AccessToken { get; set; }
        public string Url { get; set; }
        /// <summary>
        /// Linux时间戳
        /// 如果为空 则取当前时间
        /// </summary>
        public string TimeStamp { get; set; }
        /// <summary>
        /// 随机数
        /// 如果为空，则会自动填充
        /// </summary>
        public string NonceStr { get; set; }
    }
}
