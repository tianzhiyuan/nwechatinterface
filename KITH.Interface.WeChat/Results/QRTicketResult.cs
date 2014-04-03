using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KITH.Interface.WeChat.Results
{
    /// <summary>
    /// 获取二维码Ticket
    /// </summary>
    public class QRTicketResult : AbstractResult
    {
        public string ticket { get; set; }
        public int expire_seconds { get; set; }
    }
}
