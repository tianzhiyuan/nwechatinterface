using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NWeChatPay
{
    /*
     * 流程示意
     * ____________                       ______________               ____________
     * |   用户   |                       | 微信平台   |               | 商家     |
     * ------------                       --------------               ------------
     *      |                                   |                           |
     *      |     1. 发起投诉                   |                           |
     *      |       ------------------->        |   2.投诉派发给商家        |
     *      |                                   |   ----------------->      |(通过WeChatPayHelper.ParsePayFeedback()解析)
     *      |                                   |                           |
     *      |                                   |                           |
     *      |                                   |                           |
     *      |                   3. 商家与用户进行必要的沟通，解决投诉       |
     *      |              < ------------------------------------------>    |
     *      |                                   |                           |
     *      |                                   |                           |
     *      |                                   |                           |
     *      |                                   |                           |
     *      |                                   |       商家发起消除        |
     *      |                                   |    投诉申请的请求         |(通过调用WeChatPayHelper.UpdateFeedback())
     *      |                                   |   <-----------------      |
     *      |        平台发送撤销确认给用户     |                           |
     *      |       <---------------------      |                           |
     *      |                                   |                           |
     *      |   用户认为已经解决（或拒绝）      |                           |
     *      |   （或者7天超时，默认确认）       |                           |
     *      |       ------------------>         |                           |
     *      |                                   |   发送投诉撤销（或拒绝，如果是拒绝，则转到步骤3）的通知
     *      |                                   |   ------------------>     |(通过调用WeChatPayHelper.ParsePayFeedback()解析，并检查MsgType)
     *      |                                   |                           |
     *      V                                   V                           V
     */
    /// <summary>
    /// 客户维权类型
    /// </summary>
    public class PayFeedBackTypes
    {
        /// <summary>
        /// 用户提交投诉
        /// </summary>
        public const string Request = "request";
        /// <summary>
        /// 确认消除投诉
        /// </summary>
        public const string Confirm = "confirm";
        /// <summary>
        /// 拒绝维权消除投诉
        /// </summary>
        public const string Reject = "reject";
    }
    /// <summary>
    /// 客户维权
    /// </summary>
    public class PayFeedback
    {
        public string OpenId { get; set; }
        public string AppId { get; set; }
        public long TimeStamp { get; set; }
        public string MsgType { get; set; }
        public string FeedBackId { get; set; }
        public string Reason { get; set; }
        public string AppSignature { get; set; }
        [XmlIgnore]
        public DateTime TimeStampLocal { get { return Epoch.ConvertToLocalTime(this.TimeStamp); } }
        #region 投诉请求部分 MsgType == "request"
        public string TransId { get; set; }
        public string Solution { get; set; }
        public string ExtInfo { get; set; }
        public string SignMethod { get; set; }
        public PictureInfoList PicInfo { get; set; }
        #endregion
        /// <summary>
        /// 检查签名是否正确
        /// </summary>
        /// <param name="appkey">AppKey</param>
        /// <returns>是否匹配</returns>
        public bool CheckSignature(string appkey)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("appid", this.AppId));
            parameters.Add(new KeyValuePair<string, string>("timestamp", this.TimeStamp.ToString()));
            parameters.Add(new KeyValuePair<string, string>("openid", this.OpenId));
            var signature = WeChatPayHelper.CreatePaySign(parameters, appkey);
            return signature == this.AppSignature;
        }
    }

    public class PictureInfoList : List<item> { }
    public class item
    {
        public string PicUrl { get; set; }
    }
}
