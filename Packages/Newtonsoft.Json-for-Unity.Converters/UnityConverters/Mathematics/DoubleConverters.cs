using Newtonsoft.Json.UnityConverters.Helpers;
using Unity.Mathematics;

namespace Newtonsoft.Json.UnityConverters.Mathematics
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity.Mathematics <see cref="double2"/> type.
    /// </summary>
    public class Double2Converter : PartialConverter<double2>
    {
        protected override void ReadValue(ref double2 value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.x):
                    value.x = reader.ReadAsDouble() ?? 0f;
                    break;
                case nameof(value.y):
                    value.y = reader.ReadAsDouble() ?? 0f;
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, double2 value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.x));
            writer.WriteValue(value.x);
            writer.WritePropertyName(nameof(value.y));
            writer.WriteValue(value.y);
        }
    }

    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity.Mathematics <see cref="double3"/> type.
    /// </summary>
    public class Double3Converter : PartialConverter<double3>
    {
        protected override void ReadValue(ref double3 value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.x):
                    value.x = reader.ReadAsDouble() ?? 0f;
                    break;
                case nameof(value.y):
                    value.y = reader.ReadAsDouble() ?? 0f;
                    break;
                case nameof(value.z):
                    value.z = reader.ReadAsDouble() ?? 0f;
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, double3 value, JsonSerializer serializer)
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
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity.Mathematics <see cref="double4"/> type.
    /// </summary>
    public class Double4Converter : PartialConverter<double4>
    {
        protected override void ReadValue(ref double4 value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.x):
                    value.x = reader.ReadAsDouble() ?? 0f;
                    break;
                case nameof(value.y):
                    value.y = reader.ReadAsDouble() ?? 0f;
                    break;
                case nameof(value.z):
                    value.z = reader.ReadAsDouble() ?? 0f;
                    break;
                case nameof(value.w):
                    value.w = reader.ReadAsDouble() ?? 0f;
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, double4 value, JsonSerializer serializer)
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
