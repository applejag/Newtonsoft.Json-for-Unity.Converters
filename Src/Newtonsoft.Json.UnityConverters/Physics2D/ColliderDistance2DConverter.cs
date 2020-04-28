using System;
using System.Reflection;
using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Physics2D
{
    public class ColliderDistance2DConverter : PartialConverter<ColliderDistance2D, object>
    {
        private static readonly FieldInfo _normalField = typeof(ColliderDistance2D).GetField("m_Normal", BindingFlags.NonPublic | BindingFlags.Instance);
        private static readonly string[] _memberNames = { "pointA", "pointB", "normal", "distance", "isValid" };

        public ColliderDistance2DConverter()
            : base(_memberNames)
        {
        }

        protected override ColliderDistance2D CreateInstanceFromValues(ValuesArray<object> values)
        {
            var instance = new ColliderDistance2D {
                pointA = values.GetAsTypeOrDefault<Vector2>(0),
                pointB = values.GetAsTypeOrDefault<Vector2>(1),
                distance = values.GetAsTypeOrDefault<float>(3),
                isValid = values.GetAsTypeOrDefault<bool>(4),
            };

            if (_normalField == null)
            {
                throw new JsonException("Failed to set value for 'm_Normal' field on UnityEngine.ColliderDistance2D type.");
            }

            TypedReference reference = __makeref(instance);
            Vector2 normal = values.GetAsTypeOrDefault<Vector2>(2);

            _normalField.SetValueDirect(reference, normal);

            return instance;
        }

        protected override object[] ReadInstanceValues(ColliderDistance2D instance)
        {
            return new object[] {
                instance.pointA,
                instance.pointB,
                instance.normal,
                instance.distance,
                instance.isValid,
            };
        }

        protected override object ReadValue(JsonReader reader, int index, JsonSerializer serializer)
        {
            return index switch
            {
                0 => reader.ReadViaSerializer<Vector2>(serializer),
                1 => reader.ReadViaSerializer<Vector2>(serializer),
                2 => reader.ReadViaSerializer<Vector2>(serializer),
                3 => (float)(reader.ReadAsDouble() ?? 0),
                4 => reader.ReadAsBoolean() ?? false,

                _ => throw new ArgumentOutOfRangeException(nameof(index), index, "Only accepts member index in range 0..4")
            };
        }

        protected override void WriteValue(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch (value)
            {
            case Vector2 vector2:
                serializer.Serialize(writer, vector2, typeof(Vector2));
                break;

            case float num:
                writer.WriteValue(num);
                break;

            case bool boolean:
                writer.WriteValue(boolean);
                break;

            default:
                throw writer.CreateWriterException($"Unexpected type '{value?.GetType().Name ?? "null"}' when serializing {typeof(ColliderDistance2D).FullName}.");
            }
        }
    }
}
