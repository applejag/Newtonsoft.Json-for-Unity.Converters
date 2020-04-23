using System;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    public class ColorConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is Color col)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("r");
                writer.WriteValue(col.r);
                writer.WritePropertyName("g");
                writer.WriteValue(col.g);
                writer.WritePropertyName("b");
                writer.WriteValue(col.b);
                writer.WritePropertyName("a");
                writer.WriteValue(col.a);
                writer.WriteEndObject();
            }
            else if (value is Color32 col32)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("r");
                writer.WriteValue(col32.r);
                writer.WritePropertyName("g");
                writer.WriteValue(col32.g);
                writer.WritePropertyName("b");
                writer.WriteValue(col32.b);
                writer.WritePropertyName("a");
                writer.WriteValue(col32.a);
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteNull();
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Color) || objectType == typeof(Color32);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return new Color();
            }

            var obj = JObject.Load(reader);

            if (objectType == typeof(Color32))
            {
                return new Color32(
                    obj.Value<byte>("r"),
                    obj.Value<byte>("g"),
                    obj.Value<byte>("b"),
                    obj.Value<byte>("a")
                );
            }
            else
            {
                return new Color(
                obj.Value<float>("r"),
                obj.Value<float>("g"),
                obj.Value<float>("b"),
                obj.Value<float>("a")
            );
            }
        }

        public override bool CanRead => true;
    }
}
