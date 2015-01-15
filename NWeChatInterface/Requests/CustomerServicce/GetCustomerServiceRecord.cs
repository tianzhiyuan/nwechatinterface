using System;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.CustomerServicce
{
    /// <summary>
    /// 获取客服聊天记录
    /// 在需要时，开发者可以通过获取客服聊天记录接口，获取多客服的会话记录，
    /// 包括客服和用户会话的所有消息记录和会话的创建、关闭等操作记录。
    /// 利用此接口可以开发如“消息记录”、“工作监控”、“客服绩效考核”等功能。
    /// </summary>
	[RequestPath("/cgi-bin/customservice/getrecord")]
	[RequestMethod(RequestMethod.POST)]
	public class GetCustomerServiceRecord : AccessRequiredRequest<GetCustomerServiceRecordResponse>
    {
        /// <summary>
        /// 查询开始时间
        /// </summary>
        public DateTime StartTime { get; private set; }
        /// <summary>
        /// 查询结束时间，每次查询不能跨日查询
        /// </summary>
        public DateTime EndTime { get; private set; }
        /// <summary>
        /// 普通用户的标识，对当前公众号唯一
        /// </summary>
        public string OpenId { get; private set; }
        /// <summary>
        /// 每页大小，每页最多拉取1000条
        /// </summary>
        public int PageSize { get; private set; }
        /// <summary>
        /// 查询第几页，从1开始
        /// </summary>
        public int PageIndex { get; private set; }
        public GetCustomerServiceRecord(string accessToken, DateTime start, DateTime end, int pageSize, int pageIndex, string openid = "")
        {
            this.AccessToken = accessToken;
            this.StartTime = start;
            this.EndTime = end;
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.OpenId = openid;
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException("pageIndex");
            }
            if (pageSize > 1000)
            {
                throw new ArgumentOutOfRangeException("pageSize");
            }
            if (start.Year != end.Year || start.Month != end.Month || start.Date != end.Date)
            {
                throw new Exception("不能跨日查询");
            }
        }
        
        public override string Data
        {
            get
            {
                return string.Format("{{'starttime':{0},'endtime':{1},'openid':'{2}','pagesize':{3},'pageindex':{4}}}",
                                     Epoch.ConvertToEpoch(this.StartTime),
                                     Epoch.ConvertToEpoch(this.EndTime),
                                     this.OpenId,
                                     this.PageSize,
                                     this.PageIndex)
                                     .Replace("'", "\"");
            }
        }
    }
}
