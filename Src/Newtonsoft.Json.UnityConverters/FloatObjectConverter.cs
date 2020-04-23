﻿using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity Vector2 type <see cref="Vector2"/>.
    /// </summary>
    public abstract class FloatObjectConverter<T> : PartialConverter<T, float>
    {
        protected FloatObjectConverter(string[] propertyNames)
            : base(propertyNames)
        {
        }

        protected override float ReadValue(JsonReader reader, JsonSerializer serializer)
        {
            return (float)(reader.ReadAsDouble() ?? 0f);
        }

        protected override void WriteValue(JsonWriter writer, float value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}
