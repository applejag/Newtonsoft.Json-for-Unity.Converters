using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.UnityConverters.Helpers;
using Unity.Collections;

namespace Newtonsoft.Json.UnityConverters.NativeArray
{
    public class NativeArrayConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, [AllowNull] object value, JsonSerializer serializer)
        {
            if (value is null)
            {
                writer.WriteNull();
                return;
            }

            var enumerable = (IEnumerable)value;
            writer.WriteStartArray();
            foreach (object item in enumerable)
            {
                serializer.Serialize(writer, item);
            }
            writer.WriteEndArray();
        }

        [return: MaybeNull]
        public override object ReadJson(JsonReader reader, Type objectType, [AllowNull] object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            throw reader.CreateSerializationException(
                "Deserializing NativeArray<> and NativeSlice<> is disabled to not cause accidental memory leaks. Use regular List<> or array types instead in your JSON models. Due to technical limitations, we cannot even populate existing NativeArray<> or NativeSlice<> values. You simply have to use other collection types."
            );
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType.IsGenericType)
            {
                Type genericTypeDefinition = objectType.GetGenericTypeDefinition();
                return genericTypeDefinition == typeof(NativeArray<>)
                    || genericTypeDefinition == typeof(NativeSlice<>);
            }
            else
            {
                return false;
            }
        }
    }
}
