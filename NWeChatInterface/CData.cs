using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NWeChatInterface
{
    /// <summary>
    /// XML中CDATA封装
    /// </summary>
    [JsonConverter(typeof(CDataJsonConverter))]
    public sealed class CData : IXmlSerializable
    {
        string _value;

        /// <summary>
        /// Allow direct assignment from string:
        /// CData cdata = "abc";
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator CData(string value)
        {
            return new CData(value);
        }

        /// <summary>
        /// Allow direct assigment to string
        /// string str = cdata;
        /// </summary>
        /// <param name="cdata"></param>
        /// <returns></returns>
        public static implicit operator string(CData cdata)
        {
            return cdata._value;
        }

        public CData()
            : this(string.Empty)
        {
        }

        public CData(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            _value = reader.ReadElementString();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteCData(_value);
        }
    }

    public class CDataJsonConverter:JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var cdata = value as CData;
            writer.WriteValue(cdata.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var data = (string)reader.Value;
            return new CData(data);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof (CData).IsAssignableFrom(objectType);
        }
    }
}
