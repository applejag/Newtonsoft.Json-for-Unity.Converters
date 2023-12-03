using Newtonsoft.Json.UnityConverters.Helpers;
using Unity.Mathematics;

namespace Newtonsoft.Json.UnityConverters.Mathematics
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity.Mathematics <see cref="float2"/> type.
    /// </summary>
    public class Float2Converter : PartialConverter<float2>
    {
        protected override void ReadValue(ref float2 value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.x):
                    value.x = reader.ReadAsFloat() ?? 0f;
                    break;
                case nameof(value.y):
                    value.y = reader.ReadAsFloat() ?? 0f;
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, float2 value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.x));
            writer.WriteValue(value.x);
            writer.WritePropertyName(nameof(value.y));
            writer.WriteValue(value.y);
        }
    }

    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity.Mathematics <see cref="float3"/> type.
    /// </summary>
    public class Float3Converter : PartialConverter<float3>
    {
        protected override void ReadValue(ref float3 value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.x):
                    value.x = reader.ReadAsFloat() ?? 0f;
                    break;
                case nameof(value.y):
                    value.y = reader.ReadAsFloat() ?? 0f;
                    break;
                case nameof(value.z):
                    value.z = reader.ReadAsFloat() ?? 0f;
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, float3 value, JsonSerializer serializer)
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
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity.Mathematics <see cref="float4"/> type.
    /// </summary>
    public class Float4Converter : PartialConverter<float4>
    {
        protected override void ReadValue(ref float4 value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.x):
                    value.x = reader.ReadAsFloat() ?? 0f;
                    break;
                case nameof(value.y):
                    value.y = reader.ReadAsFloat() ?? 0f;
                    break;
                case nameof(value.z):
                    value.z = reader.ReadAsFloat() ?? 0f;
                    break;
                case nameof(value.w):
                    value.w = reader.ReadAsFloat() ?? 0f;
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, float4 value, JsonSerializer serializer)
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
