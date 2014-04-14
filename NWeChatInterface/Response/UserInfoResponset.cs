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
        public string nickname { get; internal set; }
        public int sex { get; internal set; }
        public string city { get; internal set; }
        public string country { get; internal set; }
        public string province { get; internal set; }
        public string language { get; internal set; }
        public string headimgurl { get; internal set; }
        public long subscribe_time { get; internal set; }
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
