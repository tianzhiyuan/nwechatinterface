using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KITH.Interface.WeChat.Requests
{
    /// <summary>
    /// 上传多媒体文件
    /// </summary>
    public class UploadMedia:IWeChatRequest
    {
        public string AccessToken { get; private set; }
        /// <summary>
        /// 多媒体文件类型 <see cref="WeChatMediaType"/>
        /// </summary>
        public string MediaType { get; private set; }

        public byte[] Content { get; private set; }
        public string FileName { get; private set; }
        public int ContentLength { get; private set; }
        public string RequestUrl
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
    }
}
