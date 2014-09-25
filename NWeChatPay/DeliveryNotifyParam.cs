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
        public DeliveryNotifyParam()
        {
            this.DeliverTimeStamp = DateTime.Now;
            this.DeliveryMsg = "";
        }
        public string AppId { get; set; }
        public string AppKey { get; set; }
        public string OpenId { get; set; }
        public string TransId { get; set; }
        public string OutTradeNo { get; set; }
        /// <summary>
        /// 发货时间，默认为当前时间
        /// </summary>
        public DateTime DeliverTimeStamp { get; set; }
        /// <summary>
        /// 发货状态，0为发货失败，需要在Msg中填写信息，1为成功
        /// </summary>
        public int DeliverStatus { get; set; }
        public string DeliveryMsg { get; set; }
        public string AccessToken { get; set; }
    }
}
