using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatPay
{
    /// <summary>
    /// 生成Native原生支付时需要的参数
    /// </summary>
    public class NativePackageParam : JSApiParam
    {
        /// <summary>
        /// 返回值 0代表正确
        /// </summary>
        public string RetCode { get; set; }
        /// <summary>
        /// 返回消息，可以填ok
        /// </summary>
        public string RetErrMsg { get; set; }
    }
}
