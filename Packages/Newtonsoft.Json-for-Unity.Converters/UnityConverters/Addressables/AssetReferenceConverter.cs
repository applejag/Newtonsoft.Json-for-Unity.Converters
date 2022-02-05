using System;
using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine.AddressableAssets;

namespace Newtonsoft.Json.UnityConverters.Addressables
{
    public class AssetReferenceConverter : JsonConverter<AssetReference>
    {
        public override AssetReference ReadJson(JsonReader reader, Type objectType, AssetReference existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonToken.String && reader.Value is string stringValue)
            {
                return new AssetReference(stringValue);
            }
            else
            {
                throw reader.CreateSerializationException($"Expected string when reading UnityEngine.Addressables.AssetReference type, got '{reader.TokenType}' <{reader.Value}>.");
            }
        }

        public override void WriteJson(JsonWriter writer, AssetReference value, JsonSerializer serializer)
        {
            if (value is null)
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteValue(value.AssetGUID);
            }
        }
    }
}
