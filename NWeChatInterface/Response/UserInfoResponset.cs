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
        public bool subscribe { get; set; }
        public string opendid { get; set; }
        public string nickname { get; set; }
        public int sex { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string province { get; set; }
        public string language { get; set; }
        public string headimgurl { get; set; }
        public long subscribe_time { get; set; }
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
