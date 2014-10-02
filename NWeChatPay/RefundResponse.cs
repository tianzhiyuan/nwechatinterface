using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NWeChatPay
{
    public enum RefundChannel
    {
        ToTenpayAccount = 0,
        ToBank = 1,
    }
    public enum RefundStatus
    {
        /// <summary>
        /// 未确定，需要商户原退款单号重新发起
        /// </summary>
        UnConfirmed = 1,
        /// <summary>
        /// 退款失败
        /// </summary>
        Failed = 3,
        /// <summary>
        /// 退款成功
        /// </summary>
        Success = 4,
        /// <summary>
        /// 退款处理中
        /// </summary>
        Processing = 8,
        /// <summary>
        /// 转入代发，退款到银行发现用户的卡作废或者冻结了，导致原路退款银行卡失败，资金回流到商户的现金帐号，需要商户人工干预，通过线下或者财付通转账的方式进行退款
        /// </summary>
        NeedManual = 7,
    }
    /// <summary>
    /// 退款应答
    /// </summary>
    public class RefundResponse
    {
        /// <summary>
        /// 签名类型，取值：MD5、RSA，默认：MD5
        /// </summary>
        public string sign_type { get; set; }
        /// <summary>
        /// 字符编码,取值：GBK、UTF-8，默认：GBK
        /// </summary>
        public string input_charset { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 返回状态码，0 表示成功，其他未定义
        /// </summary>
        public int retcode { get; set; }
        /// <summary>
        /// 返回信息，如非空，为错误原因
        /// </summary>
        public string retmsg { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string partner { get; set; }
        /// <summary>
        /// 财付通交易号，28 位长的数值，其中前10 位为商户号，之后8 位为订单产生的日期，如20090415，最后10 位是流水号
        /// </summary>
        public string transation_id { get; set; }
        /// <summary>
        /// 商户系统内部的订单号
        /// </summary>
        public string out_trade_no { get; set; }
        /// <summary>
        /// 商户退款单号
        /// </summary>
        public string out_refund_no { get; set; }
        /// <summary>
        /// 财付通退款单号
        /// </summary>
        public string refund_id { get; set; }
        /// <summary>
        /// 退款渠道,0:退到财付通、1:退到银行
        /// </summary>
        public string refund_channel { get; set; }
        /// <summary>
        /// 退款总金额,单位为分,可以做部分退款
        /// </summary>
        public int refund_fee { get; set; }
        /// <summary>
        /// 退款状态：4，10：
        /// 退款成功。3，5，6：退款失败。
        /// 8，9，11：退款处理中。
        /// 1，2：未确定，需要商户原退款单号重新发起。
        /// 7：转入代发，退款到银行发现用户的卡作废或者冻结了，导致原路退款银行卡失败，资金回流到商户的现金帐号，需要商户人工干预，通过线下或者财付通转账的方式进行退款
        /// </summary>
        public int refund_status { get; set; }
        /// <summary>
        /// 转账退款接收退款的财付通帐号
        /// </summary>
        public string recv_user_id { get; set; }
        /// <summary>
        /// 转账退款接收退款的姓名(需与接收退款的财付通帐号绑定的姓名一致
        /// </summary>
        public string reccv_user_name { get; set; }
        /// <summary>
        /// 获取退款状态
        /// </summary>
        [XmlIgnore]
        public RefundStatus RefundStatus
        {
            get
            {
                RefundStatus status;
                switch (this.refund_status)
                {
                    case 4:
                    case 10:
                        status = RefundStatus.Success;
                        break;
                    case 3:
                    case 5:
                    case 6:
                        status = RefundStatus.Failed;
                        break;
                    case 8:
                    case 9:
                    case 11:
                        status = RefundStatus.Processing;
                        break;
                    case 1:
                    case 2:
                        status = RefundStatus.UnConfirmed;
                        break;
                    case 7:
                        status = RefundStatus.NeedManual;
                        break;
                    default:
                        status = RefundStatus.UnConfirmed;
                        break;
                }
                return status;
            }
        }
    }
}
