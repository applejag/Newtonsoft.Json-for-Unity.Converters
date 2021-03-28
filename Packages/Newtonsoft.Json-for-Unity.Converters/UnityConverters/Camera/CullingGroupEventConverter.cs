using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Camera
{
    public class CullingGroupEventConverter : PartialConverter<CullingGroupEvent>
    {
        private const byte DISTANCE_MASK = (1 << 7) - 1;

        [MaybeNull]
        private static readonly FieldInfo _indexField = typeof(CullingGroupEvent).GetFieldInfoOrThrow("m_Index");
        [MaybeNull]
        private static readonly FieldInfo _prevStateField = typeof(CullingGroupEvent).GetFieldInfoOrThrow("m_PrevState");
        [MaybeNull]
        private static readonly FieldInfo _thisStateField = typeof(CullingGroupEvent).GetFieldInfoOrThrow("m_ThisState");

        protected override void ReadValue(ref CullingGroupEvent value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.index):
                    _indexField.SetValueDirectRef(ref value, reader.ReadAsInt32() ?? 0);
                    break;
                case nameof(value.isVisible):
                    SetStateField(_thisStateField, ref value, value.currentDistance, reader.ReadAsBoolean() ?? false);
                    break;
                case nameof(value.wasVisible):
                    SetStateField(_prevStateField, ref value, value.previousDistance, reader.ReadAsBoolean() ?? false);
                    break;
                case nameof(value.currentDistance):
                    SetStateField(_thisStateField, ref value, reader.ReadAsInt32() ?? 0, value.isVisible);
                    break;
                case nameof(value.previousDistance):
                    SetStateField(_prevStateField, ref value, reader.ReadAsInt32() ?? 0, value.wasVisible);
                    break;
            }
        }

        private static void SetStateField(FieldInfo field, ref CullingGroupEvent value, int distance, bool isVisible)
        {
            byte isVisibleByte = isVisible ? (byte)0x80 : (byte)0;
            byte stateByte = (byte)(isVisibleByte | (distance & DISTANCE_MASK));
            field.SetValueDirectRef(ref value, stateByte);
        }

        protected override void WriteJsonProperties(JsonWriter writer, CullingGroupEvent value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.index));
            writer.WriteValue(value.index);
            writer.WritePropertyName(nameof(value.isVisible));
            writer.WriteValue(value.isVisible);
            writer.WritePropertyName(nameof(value.wasVisible));
            writer.WriteValue(value.wasVisible);
            writer.WritePropertyName(nameof(value.currentDistance));
            writer.WriteValue(value.currentDistance);
            writer.WritePropertyName(nameof(value.previousDistance));
            writer.WriteValue(value.previousDistance);
        }
    }
}
