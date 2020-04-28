using System;
using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Physics2D
{
    public class ContactFilter2DConverter : PartialConverter<ContactFilter2D, object>
    {
        private static readonly string[] _memberNames = {
            "useTriggers",
            "useLayerMask",
            "useDepth",
            "useOutsideDepth",
            "useNormalAngle",
            "useOutsideNormalAngle",
            "layerMask",
            "minDepth",
            "maxDepth",
            "minNormalAngle",
            "maxNormalAngle"
        };

        public ContactFilter2DConverter()
            : base(_memberNames)
        {
        }

        protected override ContactFilter2D CreateInstanceFromValues(ValuesArray<object> values)
        {
            return new ContactFilter2D {
                useTriggers = values.GetAsTypeOrDefault<bool>(0),
                useLayerMask = values.GetAsTypeOrDefault<bool>(1),
                useDepth = values.GetAsTypeOrDefault<bool>(2),
                useOutsideDepth = values.GetAsTypeOrDefault<bool>(3),
                useNormalAngle = values.GetAsTypeOrDefault<bool>(4),
                useOutsideNormalAngle = values.GetAsTypeOrDefault<bool>(5),

                layerMask = values.GetAsTypeOrDefault<LayerMask>(6),

                minDepth = values.GetAsTypeOrDefault<float>(7),
                maxDepth = values.GetAsTypeOrDefault<float>(8),
                minNormalAngle = values.GetAsTypeOrDefault<float>(9),
                maxNormalAngle = values.GetAsTypeOrDefault<float>(10),
            };
        }

        protected override object[] ReadInstanceValues(ContactFilter2D instance)
        {
            return new object[] {
                instance.useTriggers,
                instance.useLayerMask,
                instance.useDepth,
                instance.useOutsideDepth,
                instance.useNormalAngle,
                instance.useOutsideNormalAngle,
                instance.layerMask,
                instance.minDepth,
                instance.maxDepth,
                instance.minNormalAngle,
                instance.maxNormalAngle,
            };
        }

        protected override object ReadValue(JsonReader reader, int index, JsonSerializer serializer)
        {
            switch (index)
            {
            case 0: // useTriggers
            case 1: // useLayerMask
            case 2: // useDepth
            case 3: // useOutsideDepth
            case 4: // useNormalAngle
            case 5: // useOutsideNormalAngle
                return reader.ReadAsBoolean() ?? false;

            case 6: // layerMask
                return reader.ReadViaSerializer<LayerMask>(serializer);

            case 7: // minDepth
            case 8: // maxDepth
            case 9: // minNormalAngle
            case 10: // maxNormalAngle
                return (float)(reader.ReadAsDouble() ?? 0);

            default:
                throw new ArgumentOutOfRangeException(nameof(index), index, "Only accepts member index in range 0..4");
            }
        }

        protected override void WriteValue(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch (value)
            {
            case LayerMask _:
                serializer.Serialize(writer, value, typeof(LayerMask));
                break;

            case float num:
                writer.WriteValue(num);
                break;

            case bool boolean:
                writer.WriteValue(boolean);
                break;

            default:
                throw writer.CreateWriterException($"Unexpected type '{value?.GetType().Name ?? "null"}' when serializing {typeof(ContactFilter2D).FullName}.");
            }
        }
    }
}
