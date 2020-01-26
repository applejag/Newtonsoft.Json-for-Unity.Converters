using System;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    public class Matrix4x4Converter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            var m = (Matrix4x4)value;

            writer.WriteStartObject();

            writer.WritePropertyName("m00");
            writer.WriteValue(m.m00);

            writer.WritePropertyName("m01");
            writer.WriteValue(m.m01);

            writer.WritePropertyName("m02");
            writer.WriteValue(m.m02);

            writer.WritePropertyName("m03");
            writer.WriteValue(m.m03);

            writer.WritePropertyName("m10");
            writer.WriteValue(m.m10);

            writer.WritePropertyName("m11");
            writer.WriteValue(m.m11);

            writer.WritePropertyName("m12");
            writer.WriteValue(m.m12);

            writer.WritePropertyName("m13");
            writer.WriteValue(m.m13);

            writer.WritePropertyName("m20");
            writer.WriteValue(m.m20);

            writer.WritePropertyName("m21");
            writer.WriteValue(m.m21);

            writer.WritePropertyName("m22");
            writer.WriteValue(m.m22);

            writer.WritePropertyName("m23");
            writer.WriteValue(m.m23);

            writer.WritePropertyName("m30");
            writer.WriteValue(m.m30);

            writer.WritePropertyName("m31");
            writer.WriteValue(m.m31);

            writer.WritePropertyName("m32");
            writer.WriteValue(m.m32);

            writer.WritePropertyName("m33");
            writer.WriteValue(m.m33);

            writer.WriteEnd();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return new Matrix4x4();

            var obj = JObject.Load(reader);
            return new Matrix4x4 {
                m00 = ReadFloat("m00"),
                m01 = ReadFloat("m01"),
                m02 = ReadFloat("m02"),
                m03 = ReadFloat("m03"),
                m20 = ReadFloat("m20"),
                m21 = ReadFloat("m21"),
                m22 = ReadFloat("m22"),
                m23 = ReadFloat("m23"),
                m30 = ReadFloat("m30"),
                m31 = ReadFloat("m31"),
                m32 = ReadFloat("m32"),
                m33 = ReadFloat("m33")
            };

            float ReadFloat(string name)
            {
                if (!obj.TryGetValue(name, out JToken? value))
                {
                    return 0;
                }
                else
                {
                    return value.Value<float>();
                }
            }
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Matrix4x4);
        }
    }
}
