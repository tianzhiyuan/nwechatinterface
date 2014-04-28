using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatPay
{
    public class OrderInfo
    {
        public string trade_state { get; set; }
        public string trade_mode { get; set; }
        public string bank_type { get; set; }
        public string bank_billno { get; set; }
        public string total_fee { get; set; }
        public string fee_type { get; set; }
        public string transaction_id { get; set; }
        public string out_trade_no { get; set; }
        public string is_split { get; set; }
        public string is_refund { get; set; }
        public string attach { get; set; }
    }
}
