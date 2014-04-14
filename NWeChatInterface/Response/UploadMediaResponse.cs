using System;

namespace NWeChatInterface.Response
{
    /// <summary>
    /// 上传多媒体文件返回值 
    /// </summary>
    public class UploadMediaResponse:WeChatResponse
    {
        public string type { get; internal set; }
        public string media_id { get; internal set; }
        public long created_at { get; internal set; }
        public DateTime CreatedAt{get { return new DateTime(1970, 1, 1).AddSeconds(created_at); }}
    }
}
