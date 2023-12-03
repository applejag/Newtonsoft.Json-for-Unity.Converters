using Unity.Mathematics;

namespace Newtonsoft.Json.UnityConverters.Mathematics
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity.Mathematics <see cref="uint2"/> type.
    /// </summary>
    public class Uint2Converter : PartialConverter<uint2>
    {
        protected override void ReadValue(ref uint2 value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.x):
                    value.x = (uint)(reader.ReadAsInt32() ?? 0);
                    break;
                case nameof(value.y):
                    value.y = (uint)(reader.ReadAsInt32() ?? 0);
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, uint2 value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.x));
            writer.WriteValue(value.x);
            writer.WritePropertyName(nameof(value.y));
            writer.WriteValue(value.y);
        }
    }

    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity.Mathematics <see cref="uint3"/> type.
    /// </summary>
    public class Uint3Converter : PartialConverter<uint3>
    {
        protected override void ReadValue(ref uint3 value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.x):
                    value.x = (uint)(reader.ReadAsInt32() ?? 0);
                    break;
                case nameof(value.y):
                    value.y = (uint)(reader.ReadAsInt32() ?? 0);
                    break;
                case nameof(value.z):
                    value.z = (uint)(reader.ReadAsInt32() ?? 0);
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, uint3 value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.x));
            writer.WriteValue(value.x);
            writer.WritePropertyName(nameof(value.y));
            writer.WriteValue(value.y);
            writer.WritePropertyName(nameof(value.z));
            writer.WriteValue(value.z);
        }
    }

    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity.Mathematics <see cref="uint4"/> type.
    /// </summary>
    public class Uint4Converter : PartialConverter<uint4>
    {
        protected override void ReadValue(ref uint4 value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.x):
                    value.x = (uint)(reader.ReadAsInt32() ?? 0);
                    break;
                case nameof(value.y):
                    value.y = (uint)(reader.ReadAsInt32() ?? 0);
                    break;
                case nameof(value.z):
                    value.z = (uint)(reader.ReadAsInt32() ?? 0);
                    break;
                case nameof(value.w):
                    value.w = (uint)(reader.ReadAsInt32() ?? 0);
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, uint4 value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.x));
            writer.WriteValue(value.x);
            writer.WritePropertyName(nameof(value.y));
            writer.WriteValue(value.y);
            writer.WritePropertyName(nameof(value.z));
            writer.WriteValue(value.z);
            writer.WritePropertyName(nameof(value.w));
            writer.WriteValue(value.w);
        }
    }
}
