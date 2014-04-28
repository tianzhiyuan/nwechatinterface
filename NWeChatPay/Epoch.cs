using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatPay
{
    /// <summary>
    /// Linux时间和DateTime(本地时间)之间的转换
    /// 精度到秒
    /// </summary>
    internal class Epoch
    {
        private static DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        public static long Now
        {
            get { return (long)(DateTime.UtcNow - _epoch).TotalSeconds; }
        }
        public static DateTime ConvertToLocalTime(long epoch)
        {
            return _epoch.AddSeconds(epoch).ToLocalTime();
        }
        public static long ConvertToEpoch(DateTime time)
        {
            return (long)(time - _epoch.ToLocalTime()).TotalSeconds;
        }
    }
}
