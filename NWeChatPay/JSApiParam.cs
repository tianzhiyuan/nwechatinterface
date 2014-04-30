using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatPay
{
    /// <summary>
    /// 生成JS支付API请求所需要的参数
    /// </summary>
    public class JSApiParam
    {
        public const string GBK = "GBK";
        public const string UTF8 = "UTF-8";
        /// <summary>
        /// 公众号ID，类似"wxf8b4f85f3a794e77"
        /// 必填
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 支付签名中用到的Key
        /// 必填
        /// 类似"2Wozy2aksie1puXUBpWD8oZxiD1DfQuEaiC7KcRATv1Ino3mdopKaPGQQ7TtkNySuAmCaDCrw4xhPY5qKTBl7Fzm0RgR3c0WaVYIXZARsxzHV2x7iwPPzOz94dnwPWSn"
        /// </summary>
        public string AppKey { get; set; }
        /// <summary>
        /// 财付通商户权限密钥Key
        /// 必填
        /// 类似8934e7d15453e97507ef794cf7b0519d
        /// </summary>
        public string PartnerKey { get; set; }
        /// <summary>
        /// 商品描述
        /// 必填
        /// 128字节以下
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 财付通商户身份标识，类似1900000109
        /// 必填
        /// </summary>
        public string Partner { get; set; }
        /// <summary>
        /// 商户系统内部的订单号，32个字符内，能包含字母和数字
        /// 必填
        /// </summary>
        public string OutTradeNo { get; set; }
        /// <summary>
        /// 订单总金额，单位为分，例如10元，这里要传 1000
        /// 必填
        /// </summary>
        public string TotalFee { get; set; }
        /// <summary>
        /// 支付完成通知URL，需要绝对路径，在255字符内
        /// 必填
        /// </summary>
        public string NotifyUrl { get; set; }
        /// <summary>
        /// 用户浏览器IP，格式为IPV4整型
        /// 必填
        /// </summary>
        public string ClientIp { get; set; }
        /// <summary>
        /// Linux时间戳
        /// 选填（如果为空则默认填充当前时间）
        /// </summary>
        public string TimeStamp { get; set; }
        /// <summary>
        /// 随机字符串
        /// 选填（如果为空则随机生成）
        /// </summary>
        public string NonceStr { get; set; }
        /// <summary>
        /// 编码方式
        /// 默认为UTF-8,取值范围 GBK、UTF-8
        /// </summary>
        public string Charset { get; set; }
        /// <summary>
        /// 附加数据，原样返回
        /// 128字节以下
        /// 选填
        /// </summary>
        public string Attach { get; set; }
        /// <summary>
        /// 交易起始时间
        /// 选填
        /// </summary>
        public DateTime? TimeStart { get; set; }
        /// <summary>
        /// 交易失效时间
        /// 选填
        /// </summary>
        public DateTime? TimeExpire { get; set; }
        /// <summary>
        /// 物流费用,单位为分，如果有值，必须保证TransportFee + ProductFee = TotalFee
        /// 选填
        /// </summary>
        public string TransportFee { get; set; }
        /// <summary>
        /// 商品费用，单位为分，如果有值，必须保证TransportFee + ProductFee = TotalFee
        /// 选填
        /// </summary>
        public string ProductFee { get; set; }
        /// <summary>
        /// 商品标记，优惠券可能用到
        /// 选填
        /// </summary>
        public string GoodsTag { get; set; }
        internal void Validate()
        {
            if (string.IsNullOrWhiteSpace(AppId))
            {
                throw new WeChatPayException(Resource.AppId_Null);
            }
            if (string.IsNullOrWhiteSpace(AppKey))
            {
                throw new WeChatPayException(Resource.AppKey_Null);
            }
            if (string.IsNullOrWhiteSpace(PartnerKey))
            {
                throw new WeChatPayException(Resource.PartnerKey_Null);
            }
            if (string.IsNullOrWhiteSpace(Body) || string.IsNullOrWhiteSpace(Partner) ||
                string.IsNullOrWhiteSpace(OutTradeNo) || string.IsNullOrWhiteSpace(TotalFee) ||
                string.IsNullOrWhiteSpace(NotifyUrl) || string.IsNullOrWhiteSpace(ClientIp))
            {
                throw new WeChatPayException(Resource.Parameter_Missing);
            }
        }
    }
}
