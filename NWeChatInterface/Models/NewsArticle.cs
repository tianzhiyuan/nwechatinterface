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
        public string thumb_media_id { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string content_source_url { get; set; }
        public string content { get; set; }
        public string digest { get; set; }
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
