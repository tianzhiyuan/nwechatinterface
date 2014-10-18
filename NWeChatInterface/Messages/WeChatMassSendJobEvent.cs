using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Messages
{
    /// <summary>
    /// 群发错误码
    /// </summary>
    public enum WeChatMassSendErrCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        SUCCESS = 0,
        /// <summary>
        /// 涉嫌广告
        /// </summary>
        SUSPECTED_AD = 10001,
        /// <summary>
        /// 涉嫌政治
        /// </summary>
        SUSPECTED_POLITICS = 20001,
        /// <summary>
        /// 涉嫌色情 
        /// </summary>
        SUSPECTED_PORN = 20002,
        /// <summary>
        /// 涉嫌社会 
        /// </summary>
        SUSPECTED_SOCIATY = 20004,
        /// <summary>
        /// 涉嫌违法犯罪
        /// </summary>
        SUSPECTED_ILLEGAL = 20006,
        /// <summary>
        /// 涉嫌欺诈 
        /// </summary>
        SUSPECTED_FRAUD = 20008,
        /// <summary>
        /// 涉嫌版权 
        /// </summary>
        SUSPECTED_COPYRIGHT = 20013,
        /// <summary>
        /// 涉嫌其他
        /// </summary>
        SUSPECTED_OTHER = 21000,
        /// <summary>
        /// 涉嫌互推(互相宣传)
        /// </summary>
        SUSPECTED_CROSS_PUSH = 22000,    }
    /// <summary>
    /// 微信群发消息结果推送事件
    /// </summary>
    public class WeChatMassSendJobEvent:WeChatEventMsg
    {
        /// <summary>
        /// 群发的消息ID
        /// </summary>
        public long MsgID { get; set; }
        /// <summary>
        /// 群发的结果，为“send success”或“send fail”或“err(num)”。
        /// 但send success时，也有可能因用户拒收公众号的消息、系统错误等原因造成少量用户接收失败
        /// err(num)是审核失败的具体原因，可能的情况如下：
        /// err(10001), 涉嫌广告 
        /// err(20001), 涉嫌政治 
        /// err(20004), 涉嫌社会 
        /// err(20002), 涉嫌色情 
        /// err(20006), 涉嫌违法犯罪 
        /// err(20008), 涉嫌欺诈 
        /// err(20013), 涉嫌版权 
        /// err(22000), 涉嫌互推(互相宣传) 
        /// err(21000), 涉嫌其他
        /// </summary>
        public CData Status { get; set; }
        /// <summary>
        /// group_id下粉丝数；或者openid_list中的粉丝数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 过滤（过滤是指特定地区、性别的过滤、用户设置拒收的过滤，用户接收已超4条的过滤）后，准备发送的粉丝数，原则上，FilterCount = SentCount + ErrorCount
        /// </summary>
        public int FilterCount { get; set; }
        /// <summary>
        /// 发送成功的粉丝数
        /// </summary>
        public int SendCount { get; set; }
        /// <summary>
        /// 发送失败的粉丝数
        /// </summary>
        public int ErrorCount { get; set; }
        /// <summary>
        /// 错误码
        /// </summary>
        public WeChatMassSendErrCode ErrCode
        {
            get
            {
                var ret = WeChatMassSendErrCode.SUCCESS;
                var err = (string)this.Status;
                if (string.IsNullOrWhiteSpace(err))
                {
                    return ret;
                }

                if (!err.StartsWith("err"))
                {
                    return ret;
                }
                var code = err.Replace("err(", "").Replace(")", "");
                Enum.TryParse(code, true, out ret);
                return ret;
            }

        }
    }
}
