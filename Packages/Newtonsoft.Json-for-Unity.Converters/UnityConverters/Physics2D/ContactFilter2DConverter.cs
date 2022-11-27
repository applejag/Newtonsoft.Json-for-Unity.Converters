#if HAVE_MODULE_PHYSICS2D || !UNITY_2019_1_OR_NEWER
using System;
using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Physics2D
{
    public class ContactFilter2DConverter : PartialConverter<ContactFilter2D>
    {
        protected override void ReadValue(ref ContactFilter2D value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
            case nameof(value.useTriggers):
                value.useTriggers = reader.ReadAsBoolean() ?? false;
                break;
            case nameof(value.useLayerMask):
                value.useLayerMask = reader.ReadAsBoolean() ?? false;
                break;
            case nameof(value.useDepth):
                value.useDepth = reader.ReadAsBoolean() ?? false;
                break;
            case nameof(value.useOutsideDepth):
                value.useOutsideDepth = reader.ReadAsBoolean() ?? false;
                break;
            case nameof(value.useNormalAngle):
                value.useNormalAngle = reader.ReadAsBoolean() ?? false;
                break;
            case nameof(value.useOutsideNormalAngle):
                value.useOutsideNormalAngle = reader.ReadAsBoolean() ?? false;
                break;

            case nameof(value.layerMask):
                value.layerMask = reader.ReadViaSerializer<LayerMask>(serializer);
                break;

            case nameof(value.minDepth):
                value.minDepth = reader.ReadAsFloat() ?? 0f;
                break;
            case nameof(value.maxDepth):
                value.maxDepth = reader.ReadAsFloat() ?? 0f;
                break;
            case nameof(value.minNormalAngle):
                value.minNormalAngle = reader.ReadAsFloat() ?? 0f;
                break;
            case nameof(value.maxNormalAngle):
                value.maxNormalAngle = reader.ReadAsFloat() ?? 0f;
                break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, ContactFilter2D value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.useTriggers));
            writer.WriteValue(value.useTriggers);
            writer.WritePropertyName(nameof(value.useLayerMask));
            writer.WriteValue(value.useLayerMask);
            writer.WritePropertyName(nameof(value.useDepth));
            writer.WriteValue(value.useDepth);
            writer.WritePropertyName(nameof(value.useOutsideDepth));
            writer.WriteValue(value.useOutsideDepth);
            writer.WritePropertyName(nameof(value.useNormalAngle));
            writer.WriteValue(value.useNormalAngle);
            writer.WritePropertyName(nameof(value.useOutsideNormalAngle));
            writer.WriteValue(value.useOutsideNormalAngle);
            writer.WritePropertyName(nameof(value.layerMask));
            serializer.Serialize(writer, value.layerMask, typeof(LayerMask));
            writer.WritePropertyName(nameof(value.minDepth));
            writer.WriteValue(value.minDepth);
            writer.WritePropertyName(nameof(value.maxDepth));
            writer.WriteValue(value.maxDepth);
            writer.WritePropertyName(nameof(value.minNormalAngle));
            writer.WriteValue(value.minNormalAngle);
            writer.WritePropertyName(nameof(value.maxNormalAngle));
            writer.WriteValue(value.maxNormalAngle);
        }
    }
}
#endif
