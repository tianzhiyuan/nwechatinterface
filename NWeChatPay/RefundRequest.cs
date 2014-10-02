using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatPay
{ 
    /// <summary>
    /// 退款请求类
    /// </summary>
    public class RefundRequest
    {
        public RefundRequest()
        {
            this.sign_type = "MD5";
            this.input_charset = "GBK";
            this.service_version = "1.1";
        }
        public string AppKey { get; set; }
        /// <summary>
        /// 签名类型，取值：MD5、RSA，默认：MD5
        /// </summary>
        public string sign_type { get; set; }
        /// <summary>
        /// 字符编码,取值：GBK、UTF-8，默认：GBK
        /// </summary>
        public string input_charset { get; set; }
        /// <summary>
        /// 签名，自动计算
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 多密钥支持的密钥序号，默认1
        /// 选填
        /// </summary>
        public int? sign_key_index { get; set; }
        /// <summary>
        /// 版本号 填写为1.0 时，操作员密码为明文 填写为1.1 时，操作员密码为MD5(密码)值
        /// 默认1.1
        /// </summary>
        public string service_version { get; set; }

        /// <summary>
        /// 商户号,由财付通统一分配的10 位正整数(120XXXXXXX)号
        /// 必填
        /// </summary>
        public string partner { get; set; }
        /// <summary>
        /// 商户系统内部的订单号, out_trade_no 和transaction_id 至少一个必填，同时存在时transaction_id 优先
        /// </summary>
        public string out_trade_no { get; set; }
        /// <summary>
        /// 财付通交易号, out_trade_no 和transaction_id 至少一个必填，同时存在时transaction_id 优先
        /// </summary>
        public string transaction_id { get; set; }
        /// <summary>
        /// 商户退款单号，32 个字符内、可包含字母,确保在商户系统唯一
        /// 必填
        /// </summary>
        public string out_refund_no { get; set; }
        /// <summary>
        /// 订单总金额，单位为分
        /// 必填
        /// </summary>
        public int total_fee { get; set; }
        /// <summary>
        /// 退款总金额,单位为分,可以做部分退款
        /// 必填
        /// </summary>
        public int refund_fee { get; set; }
        /// <summary>
        /// 操作员帐号,默认为商户号
        /// 必填
        /// </summary>
        public int op_user_id { get; set; }
        /// <summary>
        /// 操作员密码,默认为商户后台登录密码
        /// 必填
        /// </summary>
        public string op_user_password { get; set; }
        /// <summary>
        /// 转账退款接收退款的财付通帐号
        /// 一般无需填写，只有退银行失败，
        /// 资金转入商户号现金账号时（即状态为转入代发，查询返回的refund_status 是7 或11），
        /// 填写原退款单号并填写此字段，资金才会退到指定财付通账号。其他情况此字段忽略
        /// </summary>
        public string recv_user_id { get; set; }
        /// <summary>
        /// 转账退款接收退款的姓名(需与接收退款的财付通帐号绑定的姓名一致)
        /// 选填
        /// </summary>
        public string reccv_user_name { get; set; }
        /// <summary>
        /// 若通过接口(https://www.tenpay.com/cgi-bin/v1.0/pay_gate.cgi) 支付的商户订单号来退款，则取值为1；而通过本文档支付接口的，则无需传值
        /// 选填
        /// </summary>
        public int? user_spbill_no_flag { get; set; }
        /// <summary>
        /// 为空或者填1:商户号余额退款；2：现金帐号退款； 3:优先商户号退款，若商户号余额不足，再做现金帐号退款。使用2 或3 时，需联系财付通开通此功能。
        /// 选填
        /// </summary>
        public int? refund_type { get; set; }
        
    }
}
