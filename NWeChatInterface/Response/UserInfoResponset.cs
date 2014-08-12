using System;

namespace NWeChatInterface.Response
{
    public enum UserInfoSex
    {
        Unknown = 0,
        Male = 1,
        Female = 2
    }
    /// <summary>
    /// 获取用户信息的返回结果
    /// </summary>
    public class UserInfoResponset:WeChatResponse
    {
        /// <summary>
        /// 如果为false，则未关注，拉取不到其他信息
        /// </summary>
        public bool subscribe { get; internal set; }
        public string opendid { get; internal set; }
        /// <summary>
        /// 用户的昵称
        /// </summary>
        public string nickname { get; internal set; }
        /// <summary>
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        public int sex { get; internal set; }
        /// <summary>
        /// 用户所在城市
        /// </summary>
        public string city { get; internal set; }
        public string country { get; internal set; }
        public string province { get; internal set; }

        public string language { get; internal set; }
        /// <summary>
        /// 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空
        /// </summary>
        public string headimgurl { get; internal set; }
        public long subscribe_time { get; internal set; }
        /// <summary>
        /// 只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段。
        /// </summary>
        public string unionid { get; internal set; }
        public DateTime SubscribedAt
        {
            get
            {
                DateTime startTime = new DateTime(1970, 1, 1);
                DateTime followTime = startTime.AddSeconds(subscribe_time);
                return followTime;
            }
        }
    }
}
