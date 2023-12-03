using Unity.Mathematics;

namespace Newtonsoft.Json.UnityConverters.Mathematics
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity.Mathematics <see cref="int2"/> type.
    /// </summary>
    public class Int2Converter : PartialConverter<int2>
    {
        protected override void ReadValue(ref int2 value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.x):
                    value.x = reader.ReadAsInt32() ?? 0;
                    break;
                case nameof(value.y):
                    value.y = reader.ReadAsInt32() ?? 0;
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, int2 value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.x));
            writer.WriteValue(value.x);
            writer.WritePropertyName(nameof(value.y));
            writer.WriteValue(value.y);
        }
    }

    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity.Mathematics <see cref="int3"/> type.
    /// </summary>
    public class Int3Converter : PartialConverter<int3>
    {
        protected override void ReadValue(ref int3 value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.x):
                    value.x = reader.ReadAsInt32() ?? 0;
                    break;
                case nameof(value.y):
                    value.y = reader.ReadAsInt32() ?? 0;
                    break;
                case nameof(value.z):
                    value.z = reader.ReadAsInt32() ?? 0;
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, int3 value, JsonSerializer serializer)
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
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity.Mathematics <see cref="int4"/> type.
    /// </summary>
    public class Int4Converter : PartialConverter<int4>
    {
        protected override void ReadValue(ref int4 value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.x):
                    value.x = reader.ReadAsInt32() ?? 0;
                    break;
                case nameof(value.y):
                    value.y = reader.ReadAsInt32() ?? 0;
                    break;
                case nameof(value.z):
                    value.z = reader.ReadAsInt32() ?? 0;
                    break;
                case nameof(value.w):
                    value.w = reader.ReadAsInt32() ?? 0;
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, int4 value, JsonSerializer serializer)
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
