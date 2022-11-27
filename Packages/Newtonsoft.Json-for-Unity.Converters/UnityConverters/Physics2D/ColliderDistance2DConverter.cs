#if HAVE_MODULE_PHYSICS2D || !UNITY_2019_1_OR_NEWER
using System;
using System.Reflection;
using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Physics2D
{
    public class ColliderDistance2DConverter : PartialConverter<ColliderDistance2D>
    {
        private static readonly FieldInfo _normalField = typeof(ColliderDistance2D).GetFieldInfoOrThrow("m_Normal");

        protected override void ReadValue(ref ColliderDistance2D value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch(name)
            {
                case nameof(value.pointA):
                    value.pointA = reader.ReadViaSerializer<Vector2>(serializer);
                    break;
                case nameof(value.pointB):
                    value.pointB = reader.ReadViaSerializer<Vector2>(serializer);
                    break;
                case nameof(value.normal):
                    _normalField.SetValueDirectRef(ref value, reader.ReadViaSerializer<Vector2>(serializer));
                    break;
                case nameof(value.distance):
                    value.distance = reader.ReadAsFloat() ?? 0;
                    break;
                case nameof(value.isValid):
                    value.isValid = reader.ReadAsBoolean() ?? false;
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, ColliderDistance2D value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.pointA));
            serializer.Serialize(writer, value.pointA, typeof(Vector2));
            writer.WritePropertyName(nameof(value.pointB));
            serializer.Serialize(writer, value.pointB, typeof(Vector2));
            writer.WritePropertyName(nameof(value.normal));
            serializer.Serialize(writer, value.normal, typeof(Vector2));
            writer.WritePropertyName(nameof(value.distance));
            writer.WriteValue(value.distance);
            writer.WritePropertyName(nameof(value.isValid));
            writer.WriteValue(value.isValid);
        }
    }
}
#endif
