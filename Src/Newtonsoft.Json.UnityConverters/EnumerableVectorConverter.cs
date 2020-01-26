using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine;
#if (PORTABLE)
using System.Reflection;
#endif

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// 
    /// </summary>
    public class EnumerableVectorConverter<T>: JsonConverter
    {
        private static readonly VectorConverter VECTOR_CONVERTERS = new VectorConverter();

#if PORTABLE
        private static readonly TypeInfo V2TypeInfo = typeof(IEnumerable<Vector2>).GetTypeInfo();
        private static readonly TypeInfo V3TypeInfo = typeof(IEnumerable<Vector3>).GetTypeInfo();
        private static readonly TypeInfo V4TypeInfo = typeof(IEnumerable<Vector4>).GetTypeInfo();
#endif

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null)
                writer.WriteNull();

            T[]? src = (value as IEnumerable<T>)?.ToArray();

            if (src == null)
            {
                writer.WriteNull();
                return;
            }

            writer.WriteStartArray();

            for (int i = 0; i < src.Length; i++)
            {
                VECTOR_CONVERTERS.WriteJson(writer, src[i], serializer);
            }
            writer.WriteEndArray();
        }

        public override bool CanConvert(Type objectType)
        {
#if (PORTABLE40 || PORTABLE)
            var objTypeInfo = objectType.GetTypeInfo();

            return V2TypeInfo.IsAssignableFrom(objTypeInfo)
                   || V3TypeInfo.IsAssignableFrom(objTypeInfo)
                   || V4TypeInfo.IsAssignableFrom(objTypeInfo);
#else
            return typeof(IEnumerable<Vector2>).IsAssignableFrom(objectType)
                || typeof(IEnumerable<Vector3>).IsAssignableFrom(objectType)
                || typeof(IEnumerable<Vector4>).IsAssignableFrom(objectType);
#endif
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var result = new List<T>();

            var obj = JObject.Load(reader);

            foreach (object v in obj)
                result.Add(JsonConvert.DeserializeObject<T>(v.ToString()));

            return result;
        }

        public override bool CanRead
        {
            get { return true; }
        }
    }
}
