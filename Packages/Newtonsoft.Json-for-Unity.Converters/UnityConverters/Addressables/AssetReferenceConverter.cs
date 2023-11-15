using System;
using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine.AddressableAssets;
using UnityEngine.Scripting;

[assembly: Preserve]

namespace Newtonsoft.Json.UnityConverters.Addressables
{
    public class AssetReferenceConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AssetReference) || (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(AssetReferenceT<>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonToken.String && reader.Value is string stringValue)
            {
                if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(AssetReferenceT<>))
                {
                    return Activator.CreateInstance(objectType, stringValue);
                } else
                {
                    return new AssetReference(stringValue);
                }
            }
            else
            {
                throw reader.CreateSerializationException($"Expected string when reading UnityEngine.Addressables.AssetReference type, got '{reader.TokenType}' <{reader.Value}>.");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is null || string.IsNullOrEmpty(((AssetReference)value).AssetGUID))
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteValue(((AssetReference)value).AssetGUID);
            }
        }
    }
}
