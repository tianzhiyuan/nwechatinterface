using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 如果想群发视频消息，必须先调用此接口获取media_id
    /// 注意接口中的media_id需通过基础支持中的上传下载多媒体文件来得到<see cref="UploadMedia"/>
    /// </summary>
    [RequestMethod(RequestMethod.POST)]
	[RequestPath("https://file.api.weixin.qq.com/cgi-bin/media/uploadvideo", IsFull = true)]
	public class UploadVideo : AccessRequiredRequest<UploadResponse>
    {
        public string MediaId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public UploadVideo(string accessToken, string mediaId, string title, string desc)
        {
            this.AccessToken = accessToken;
            this.MediaId = mediaId;
            this.Title = title;
            this.Description = desc;
        }
        

        public override string Data
        {
            get
            {
                return string.Format("{0}{2},{3},{4}{1}", JsonHelper.WriteStart(), JsonHelper.WriteEnd(),
                                     JsonHelper.WriteObject("media_id", this.MediaId),
                                     JsonHelper.WriteObject("title", this.Title),
                                     JsonHelper.WriteObject("description", this.Description));
            }
        }
    }
}
