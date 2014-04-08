using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Results
{
    /// <summary>
    /// 上传多媒体文件返回值 
    /// </summary>
    public class UploadMediaResult:AbstractResult
    {
        public string type { get; set; }
        public string media_id { get; set; }
        public long created_at { get; set; }
        public DateTime CreatedAt{get { return new DateTime(1970, 1, 1).AddSeconds(created_at); }}
    }
}
