using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Hashing
{
    public class Hash128Converter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Hash128) || objectType == typeof(Hash128?);
        }

        [return: MaybeNull]
        public override object ReadJson(JsonReader reader, Type objectType, [AllowNull] object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return objectType == typeof(Hash128?)
                    ? (Hash128?)null
                    : new Hash128();
            }

            if (reader.TokenType == JsonToken.String && reader.Value is string stringValue)
            {
                return Hash128.Parse(stringValue);
            }
            else
            {
                throw reader.CreateSerializationException($"Expected string when reading UnityEngine.Hash128 type, got '{reader.TokenType}' <{reader.Value}>.");
            }
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] object value, JsonSerializer serializer)
        {
            if (value is null)
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteValue(((Hash128)value).ToString());
            }
        }
    }
}
