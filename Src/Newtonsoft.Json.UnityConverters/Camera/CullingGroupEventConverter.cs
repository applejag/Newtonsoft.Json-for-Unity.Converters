using System;
using System.Reflection;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Camera
{
    public class CullingGroupEventConverter : PartialConverter<CullingGroupEvent, object>
    {
        private const byte DISTANCE_MASK = (1 << 7) - 1;

        private static readonly FieldInfo? _indexField = typeof(CullingGroupEvent).GetField("m_Index", BindingFlags.NonPublic | BindingFlags.Instance);
        private static readonly FieldInfo? _prevStateField = typeof(CullingGroupEvent).GetField("m_PrevState", BindingFlags.NonPublic | BindingFlags.Instance);
        private static readonly FieldInfo? _thisStateField = typeof(CullingGroupEvent).GetField("m_ThisState", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly string[] _memberNames = { "index", "isVisible", "wasVisible", "currentDistance", "previousDistance" };

        public CullingGroupEventConverter() : base(_memberNames)
        {
        }

        protected override CullingGroupEvent CreateInstanceFromValues(ValuesArray<object> values)
        {
            if (_indexField is null)
            {
                throw new InvalidOperationException($"Was unable to find index field from the {typeof(CullingGroupEvent).FullName} type.");
            }

            if (_prevStateField is null)
            {
                throw new InvalidOperationException($"Was unable to find prevState field from the {typeof(CullingGroupEvent).FullName} type.");
            }

            if (_thisStateField is null)
            {
                throw new InvalidOperationException($"Was unable to find thisState field from the {typeof(CullingGroupEvent).FullName} type.");
            }

            int index = values.GetAsTypeOrDefault<int>(0);
            byte isVisibleByte = values.GetAsTypeOrDefault<bool>(1) ? (byte)0x80 : (byte)0;
            byte wasVisibleByte = values.GetAsTypeOrDefault<bool>(2) ? (byte)0x80 : (byte)0;
            byte currentDistance = values.GetAsTypeOrDefault<byte>(3);
            byte previousDistance = values.GetAsTypeOrDefault<byte>(4);

            int thisStateByte = (byte)(isVisibleByte | (currentDistance & DISTANCE_MASK));
            int prevStateByte = (byte)(wasVisibleByte | (previousDistance & DISTANCE_MASK));

            var instance = new CullingGroupEvent();
            TypedReference reference = __makeref(instance);

            _indexField.SetValueDirect(reference, index);
            _prevStateField.SetValueDirect(reference, prevStateByte);
            _thisStateField.SetValueDirect(reference, thisStateByte);

            return instance;
        }

        protected override object[] ReadInstanceValues(CullingGroupEvent instance)
        {
            return new object[] {
                instance.index,
                instance.isVisible,
                instance.wasVisible,
                instance.currentDistance,
                instance.previousDistance,
            };
        }

        protected override object ReadValue(JsonReader reader, int index, JsonSerializer serializer)
        {
            return index switch
            {
                0 => reader.ReadAsInt32() ?? 0,
                1 => reader.ReadAsBoolean() ?? false,
                2 => reader.ReadAsBoolean() ?? false,
                3 => ReadDistance(reader),
                4 => ReadDistance(reader),

                _ => throw new ArgumentOutOfRangeException(nameof(index), index, "Only accepts member index in range 0..4")
            };

            static byte ReadDistance(JsonReader reader)
            {
                int value = reader.ReadAsInt32() ?? 0;
                if (value >= 0x80 || value < 0)
                {
                    throw reader.CreateSerializationException($"Overflow in {typeof(CullingGroupEvent).FullName} distance value. Distance must be between 0..127 (inclusive), got {value}");
                }
                return (byte)value;
            }
        }

        protected override void WriteValue(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch (value)
            {
            case null:
                writer.WriteNull();
                break;

            case byte distance:
                writer.WriteValue(distance);
                break;

            case int index:
                writer.WriteValue(index);
                break;

            case bool isVisible:
                writer.WriteValue(isVisible);
                break;

            default:
                throw writer.CreateWriterException($"Unexpected type '{value.GetType().Name}' when serializing {typeof(CullingGroupEvent).FullName}");
            }
        }

        private static byte AsVisibility(bool isVisible)
        {
            return isVisible ? (byte)0x80 : (byte)0;
        }

        private static byte AsDistance(byte distance)
        {
            return (byte)(distance & DISTANCE_MASK);
        }
    }
}
