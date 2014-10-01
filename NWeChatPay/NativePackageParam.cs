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
        /// 返回消息,默认OK
        /// 当出现错误时，RetErrMsg 中填上UTF8 编码的错误提示信息
        /// </summary>
        public string RetErrMsg { get; set; }
    }
}
