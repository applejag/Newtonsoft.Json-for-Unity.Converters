using System;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Scripting
{
    public class LayerMaskConverter : PartialIntConverter<LayerMask>
    {
        private static readonly string[] _memberNames = { "value" };

        public LayerMaskConverter()
            : base(_memberNames)
        {
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(LayerMask) || objectType == typeof(LayerMask?);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
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
                    value = reader.Value switch
                    {
                        int i => i,
                        uint ui => checked((int)ui),
                        long l => checked((int)l),
                        ulong ul => checked((int)ul),
                        _ => 0
                    }
                };
            }

            return base.ReadJson(reader, objectType, existingValue, serializer);
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
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

        protected override LayerMask CreateInstanceFromValues(ValuesArray<int> values)
        {
            return new LayerMask { value = values.GetAsTypeOrDefault<int>(0) };
        }

        protected override int[] ReadInstanceValues(LayerMask instance)
        {
            return new[] { instance.value };
        }
    }
}
