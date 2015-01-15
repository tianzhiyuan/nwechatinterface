using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 上传多媒体文件
    /// 目前限制：
    /// 图片（image）: 1M，支持JPG格式
    /// 语音（voice）：2M，播放长度不超过60s，支持AMR\MP3格式
    /// 视频（video）：10MB，支持MP4格式
    /// 缩略图（thumb）：64KB，支持JPG格式
    /// 注意多媒体文件三天后会被删除
    /// </summary>
	[RequestPath("http://file.api.weixin.qq.com/cgi-bin/media/upload", IsFull = true)]
	[RequestMethod(RequestMethod.POST)]
	public class UploadMedia : AccessRequiredRequest<UploadResponse>
    {
        /// <summary>
        /// 多媒体文件类型 <see cref="WeChatMediaType"/>
        /// </summary>
        public string MediaType { get; private set; }

        public byte[] Content { get; private set; }
        /// <summary>
        /// 文件名 
        /// </summary>
        public string FileName { get; private set; }
        /// <summary>
        /// 多媒体文件大小
        /// 目前限制：
        /// 图片（image）: 1M，支持JPG格式
        /// 语音（voice）：2M，播放长度不超过60s，支持AMR\MP3格式
        /// 视频（video）：10MB，支持MP4格式
        /// 缩略图（thumb）：64KB，支持JPG格式
        /// 注意多媒体文件三天后会被删除
        /// </summary>
        public int ContentLength { get; private set; }
        public override string Param
        {
            get
            {
                return string.Format("http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}",
                                     this.AccessToken, this.MediaType);
            }
        }

        public UploadMedia(string accessToken, string mediaType, byte[] content, string fileName)
        {
            this.AccessToken = accessToken;
            this.MediaType = mediaType;
            this.Content = content;
            this.ContentLength = content.Length;
            this.FileName = fileName;
        }
        /// <summary>
        /// 可以根据该Url获取多媒体文件
        /// 视频文件不支持下载
        /// </summary>
        /// <param name="acccessToken"></param>
        /// <param name="mediaId"></param>
        /// <returns></returns>
        public static string GetMediaUrl(string acccessToken, string mediaId)
        {
            return string.Format("access_token={0}&media_id={1}",
                                 acccessToken, mediaId);
        }
    }
}
