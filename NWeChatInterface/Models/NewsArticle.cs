using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace NWeChatInterface.Models
{
    [JsonConverter(typeof(ArticlesJsonConverter))]
    public class Articles : List<item>
    {
        
    }
    public class item
    {
        [JsonProperty("title")]
        public CData Title { get; set; }
        [JsonProperty("description")]
        public CData Description { get; set; }
        [JsonProperty("url")]
        public CData Url { get; set; }
        [JsonProperty("picurl")]
        public CData PicUrl { get; set; }
    }
    public class NewsArticle
    {
        /// <summary>
        /// 图文消息缩略图的media_id，可以在基础支持-上传多媒体文件接口中获得
        /// </summary>
        public string thumb_media_id { get; set; }
        /// <summary>
        /// 图文消息的作者
        /// </summary>
        public string author { get; set; }
        /// <summary>
        /// 图文消息的标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 在图文消息页面点击“阅读原文”后的页面
        /// </summary>
        public string content_source_url { get; set; }
        /// <summary>
        /// 图文消息页面的内容，支持HTML标签
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 图文消息的描述
        /// </summary>
        public string digest { get; set; }
        /// <summary>
        /// 是否显示封面，1为显示，0为不显示
        /// </summary>
        public string show_cover_pic { get; set; }
    }

    public class ArticlesJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var article = value as Articles;
            writer.WriteStartObject();
            writer.WritePropertyName("articles");
            writer.WriteStartArray();
            foreach (var item in article)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("title");
                writer.WriteValue(item.Title ?? "");
                writer.WritePropertyName("description");
                writer.WriteValue(item.Description ?? "");
                writer.WritePropertyName("url");
                writer.WriteValue(item.Url ?? "");
                writer.WritePropertyName("picurl");
                writer.WriteValue(item.PicUrl ?? "");
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Articles).IsAssignableFrom(objectType);
        }
    }
}
