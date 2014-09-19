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
    public class UploadNews : IPostRequest<UploadResponse>
    {
        public UploadNews(string accessToken, NewsArticle[] articles)
        {
            this.Articles = articles;
            this.AccessToken = accessToken;
        }
        public NewsArticle[] Articles { get; private set; }
        public string AccessToken { get; private set; }
        public string RequestUrl
        {
            get
            {
                return string.Format("https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token={0}",
                                     this.AccessToken);
            }
        }
        public string Data { get { return JsonConvert.SerializeObject(new { articles = Articles }); } }
    }
}
