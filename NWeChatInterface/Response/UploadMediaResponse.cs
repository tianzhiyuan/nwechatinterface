using System;

namespace NWeChatInterface.Response
{
    /// <summary>
    /// 上传多媒体文件返回值 
    /// </summary>
    public class UploadMediaResponse:WeChatResponse
    {
        public string type { get; set; }
        public string media_id { get; set; }
        public long created_at { get; set; }
        public DateTime CreatedAt{get { return Epoch.ConvertToLocalTime(this.created_at); }}
    }
}
