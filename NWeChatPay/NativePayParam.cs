using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatPay
{
    /// <summary>
    /// Native原生支付生成URL需要的参数
    /// </summary>
    public class NativePayParam
    {
        public NativePayParam()
        {
            this.TimeStamp = DateTime.Now;
        }
        /// <summary>
        /// 公众号ID
        /// 必填
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 商品唯一ID
        /// 必填 32字符以下
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// AppKey
        /// 必填
        /// </summary>
        public string AppKey { get; set; }
        /// <summary>
        /// 随机字符串
        /// 选填 32字符以下（为空时会自动填充）
        /// </summary>
        public string NonceStr { get; set; }
        /// <summary>
        /// 时间戳
        /// 默认为当前时间
        /// </summary>
        public DateTime TimeStamp { get; set; }
    }
}
