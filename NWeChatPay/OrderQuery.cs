using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatPay
{
    /// <summary>
    /// 订单查询
    /// </summary>
    public class OrderQuery
    {
        public OrderQuery()
        {
            this.TimeStamp = DateTime.Now;
        }
        public string AppId { get; set; }
        public string AppKey { get; set; }
        public string AccessToken { get; set; }
        /// <summary>
        /// 时间戳
        /// 默认为当前时间
        /// </summary>
        public DateTime TimeStamp { get; set; }
        public string OutTradeNo { get; set; }
        public string Partner { get; set; }
        public string PartnerKey { get; set; }
    }
}
