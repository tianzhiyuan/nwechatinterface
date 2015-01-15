using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Models;
using NWeChatInterface.Response;
using Newtonsoft.Json;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 上传图文消息素材
    /// </summary>
	[RequestPath("/cgi-bin/media/uploadnews")]
	[RequestMethod(RequestMethod.POST)]
	public class UploadNews : AccessRequiredRequest<UploadResponse>
    {
        public NewsArticle[] Articles { get; set; }
        
        public override string Data { get { return JsonConvert.SerializeObject(new { articles = Articles }); } }
    }
}
