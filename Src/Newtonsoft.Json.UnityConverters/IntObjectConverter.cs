using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity Vector2 type <see cref="Vector2"/>.
    /// </summary>
    public abstract class IntObjectConverter<T> : PartialConverter<T, int>
    {
        protected IntObjectConverter(string[] propertyNames)
            : base(propertyNames)
        {
        }

        protected override int ReadValue(JsonReader reader, JsonSerializer serializer)
        {
            return reader.ReadAsInt32() ?? 0;
        }

        protected override void WriteValue(JsonWriter writer, int value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}
