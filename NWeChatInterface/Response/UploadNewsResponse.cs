using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Response
{
    public class UploadNewsResponse:AbstractResponse
    {
        public string type { get; set; }
        public string media_id { get; set; }
        public long created_at { get; set; }
        public DateTime CreatedAt { get { return Epoch.ConvertToLocalTime(this.created_at); } }
    }
}

