using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity Vector2 type <see cref="Vector2"/>.
    /// </summary>
    public abstract class PartialByteConverter<T> : PartialConverter<T, byte>
    {
        protected PartialByteConverter(string[] propertyNames)
            : base(propertyNames)
        {
        }

        protected override byte ReadValue(JsonReader reader, int index, JsonSerializer serializer)
        {
            return checked((byte)(reader.ReadAsInt32() ?? 0));
        }

        protected override void WriteValue(JsonWriter writer, byte value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}
