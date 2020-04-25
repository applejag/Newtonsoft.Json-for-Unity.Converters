﻿using System;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    public class Hash128Converter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Hash128) || objectType == typeof(Hash128?);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
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

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
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
