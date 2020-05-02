using System;
using System.Diagnostics.CodeAnalysis;
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

            return base.ReadJson(reader, objectType, existingValue, serializer);
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

        protected override LayerMask CreateInstanceFromValues(ValuesArray<int> values)
        {
            return new LayerMask { value = values[0] };
        }

        protected override int[] ReadInstanceValues(LayerMask instance)
        {
            return new[] { instance.value };
        }
    }
}
