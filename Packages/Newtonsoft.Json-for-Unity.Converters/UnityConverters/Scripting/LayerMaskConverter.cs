using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.UnityConverters.Helpers;
using Unity.Collections;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Scripting
{
    public class LayerMaskConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(LayerMask) || objectType == typeof(LayerMask?);
        }

        [return: MaybeNull]
        public override object ReadJson(JsonReader reader, Type objectType, [AllowNull] object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return objectType == typeof(LayerMask?)
                    ? (LayerMask?)null
                    : new LayerMask();
            }

            if (reader.TokenType == JsonToken.Integer)
            {
                return new LayerMask {
                    value = GetInt(reader.Value)
                };
            }

            throw reader.CreateSerializationException($"Unexpected token when reading LayerMask. Expected 'null' or 'integer', got '{reader.TokenType}'.");
        }

        private static int GetInt(object value)
        {
            switch (value)
            {
            case int i: return i;
            case uint ui: return checked((int)ui);
            case long l: return checked((int)l);
            case ulong ul: return checked((int)ul);
            default: return 0;
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
                var layerMask = (LayerMask)value;
                writer.WriteValue(layerMask.value);
            }
        }
    }
}
