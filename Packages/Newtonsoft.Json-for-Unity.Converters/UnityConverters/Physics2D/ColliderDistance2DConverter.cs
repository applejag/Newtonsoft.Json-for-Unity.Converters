using System;
using System.Reflection;
using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Physics2D
{
    public class ColliderDistance2DConverter : PartialConverter<ColliderDistance2D, object>
    {
        // If field does not exist it should invalidate the converter for
        // the entirety of the programs lifetime. Which is fine in this case.
        private static readonly FieldInfo _normalField = GetFieldInfoOrThrow("m_Normal");
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

            Vector2 normal = values.GetAsTypeOrDefault<Vector2>(2);

#if ENABLE_IL2CPP
            object boxed = instance;

            _normalField.SetValue(boxed, normal);

            return (ColliderDistance2D)boxed;
#else
            TypedReference reference = __makeref(instance);

            _normalField.SetValueDirect(reference, normal);

            return instance;
#endif
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
            switch (index)
            {
            case 0:
            case 1:
            case 2:
                return reader.ReadViaSerializer<Vector2>(serializer);

            case 3:
                return (float)(reader.ReadAsDouble() ?? 0);

            case 4:
                return reader.ReadAsBoolean() ?? false;

            default:
                throw new ArgumentOutOfRangeException(nameof(index), index, "Only accepts member index in range 0..4");
            }
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
