using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity Vector2 type <see cref="Vector2"/>.
    /// </summary>
    public abstract class PartialIntConverter<T> : PartialConverter<T, int>
    {
        protected PartialIntConverter(string[] propertyNames)
            : base(propertyNames)
        {
        }

        protected override int ReadValue(JsonReader reader, int index, JsonSerializer serializer)
        {
            return reader.ReadAsInt32() ?? 0;
        }

        protected override void WriteValue(JsonWriter writer, int value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}
