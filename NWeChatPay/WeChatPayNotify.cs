using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatPay
{
    /// <summary>
    /// 微信支付后台通知返回的对象
    /// </summary>
    public class WeChatPayNotify
    {
        public string SignType { get; set; }
        public string InputCharset { get; set; }
        public string Sign { get; set; }
        public int TradeMode { get; set; }
        public int TradeStatus { get; set; }
        public string Partner { get; set; }
        public string BankType { get; set; }
        public string BankBillNo { get; set; }
        /// <summary>
        /// 支付金额，单位为元，如果discount有值，
        /// 通知的total_fee + discount = 请求的total_fee
        /// 注意：这里单位是元，微信直接返回的值单位是分，这里已经转换
        /// </summary>
        public decimal TotalFee { get; set; }
        public int FeeType { get; set; }
        public string NotifyId { get; set; }
        public string OutTradeNo { get; set; }
        public string Attach { get; set; }
        public DateTime TimeEnd { get; set; }
        /// <summary>
        /// 运费，单位是元
        /// </summary>
        public decimal TransportFee { get; set; }
        /// <summary>
        /// 商品金额，单位是元
        /// </summary>
        public decimal ProductFee { get; set; }
        public decimal Discount { get; set; }
        public string TransactionId { get; set; }
        
    }
}
