using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Response
{
    /// <summary>
    /// 上传图文消息素材/上传视频素材返回值
    /// </summary>
    public class UploadResponse : AbstractResponse
    {
        public string type { get; set; }
        public string media_id { get; set; }
        public long created_at { get; set; }
        public DateTime CreatedAt { get { return Epoch.ConvertToLocalTime(this.created_at); } }
    }
}
