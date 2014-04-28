using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatPay
{
    /// <summary>
    /// 发货通知需要的参数
    /// </summary>
    public class DeliveryNotifyParam
    {
        public string AppId { get; set; }
        public string AppKey { get; set; }
        public string OpenId { get; set; }
        public string TransId { get; set; }
        public string OutTradeNo { get; set; }
        public DateTime DeliverTimeStamp { get; set; }
        public int DeliverStatus { get; set; }
        public string DeliveryMsg { get; set; }
        public string AccessToken { get; set; }
    }
}
