using System;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Scripting;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Json Converter for Vector2, Vector3 and Vector4. Only serializes x, y, (z) and (w) properties.
    /// </summary>
    [Preserve]
    public class VectorConverter : JsonConverter
    {
        private static readonly Type V2 = typeof(Vector2);
        private static readonly Type V3 = typeof(Vector3);
        private static readonly Type V4 = typeof(Vector4);

        public bool EnableVector2 { get; set; }
        public bool EnableVector3 { get; set; }
        public bool EnableVector4 { get; set; }

        /// <summary>
        /// Default Constructor - All Vector types enabled by default
        /// </summary>
        public VectorConverter()
        {
            EnableVector2 = true;
            EnableVector3 = true;
            EnableVector4 = true;
        }

        /// <summary>
        /// Selectively enable Vector types
        /// </summary>
        /// <param name="enableVector2">Use for Vector2 objects</param>
        /// <param name="enableVector3">Use for Vector3 objects</param>
        /// <param name="enableVector4">Use for Vector4 objects</param>
        public VectorConverter(bool enableVector2, bool enableVector3, bool enableVector4): this()
        {
            EnableVector2 = enableVector2;
            EnableVector3 = enableVector3;
            EnableVector4 = enableVector4;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            Type targetType = value.GetType();

            if (targetType == V2)
            {
                var targetVal = (Vector2)value;
                WriteVector(writer, targetVal.x, targetVal.y, null, null);
            }
            else if (targetType == V3)
            {
                var targetVal = (Vector3) value;
                WriteVector(writer, targetVal.x, targetVal.y, targetVal.z, null);
            }
            else if (targetType == V4)
            {
                var targetVal = (Vector4)value;
                WriteVector(writer, targetVal.x, targetVal.y, targetVal.z, targetVal.w);
            }
            else
            {
                //Should never get here
                writer.WriteNull();
            }

        }

        private static void WriteVector(JsonWriter writer, float x, float y, float? z, float? w)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("x");
            writer.WriteValue(x);
            writer.WritePropertyName("y");
            writer.WriteValue(y);

            if (z.HasValue)
            {
                writer.WritePropertyName("z");
                writer.WriteValue(z.Value);

                if (w.HasValue)
                {
                    writer.WritePropertyName("w");
                    writer.WriteValue(w.Value);
                }
            }

            writer.WriteEndObject();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (objectType == V2)
                return PopulateVector2(reader);


            if (objectType == V3)
                return PopulateVector3(reader);

            return PopulateVector4(reader);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return (EnableVector2 && objectType == V2) || (EnableVector3 && objectType == V3) || (EnableVector4 && objectType == V4);
        }

        private static Vector2 PopulateVector2(JsonReader reader)
        {
            var result = new Vector2();

            if (reader.TokenType != JsonToken.Null)
            {
                var jo = JObject.Load(reader);
                result.x = jo.Value<float>("x");
                result.y = jo.Value<float>("y");
            }

            return result;
        }

        private static Vector3 PopulateVector3(JsonReader reader)
        {
            var result = new Vector3();

            if (reader.TokenType != JsonToken.Null)
            {
                var jo = JObject.Load(reader);
                result.x = jo.Value<float>("x");
                result.y = jo.Value<float>("y");
                result.z = jo.Value<float>("z");
            }

            return result;
        }

        private static Vector4 PopulateVector4(JsonReader reader)
        {
            var result = new Vector4();

            if (reader.TokenType != JsonToken.Null)
            {
                var jo = JObject.Load(reader);
                result.x = jo.Value<float>("x");
                result.y = jo.Value<float>("y");
                result.z = jo.Value<float>("z");
                result.w = jo.Value<float>("w");
            }

            return result;
        }
    }
}
