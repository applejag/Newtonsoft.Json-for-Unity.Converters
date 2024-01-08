using System;
using System.Globalization;
using Newtonsoft.Json.UnityConverters.Helpers;
using Unity.Mathematics;

namespace Newtonsoft.Json.UnityConverters.Mathematics
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity.Mathematics <see cref="half"/> type.
    /// </summary>
    public class HalfConverter : PartialConverter<half>
    {
        protected override void ReadValue(ref half value, string name, JsonReader reader, JsonSerializer serializer)
        {
            value = new half((double)reader.Value);
        }

        protected override void WriteJsonProperties(JsonWriter writer, half value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }

    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity.Mathematics <see cref="half2"/> type.
    /// </summary>
    public class Half2Converter : PartialConverter<half2>
    {
        protected override void ReadValue(ref half2 value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.x):
                    value.x = new half(reader.ReadAsFloat() ?? 0f);
                    break;
                case nameof(value.y):
                    value.y = new half(reader.ReadAsFloat() ?? 0f);
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, half2 value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.x));
            writer.WriteValue(value.x);
            writer.WritePropertyName(nameof(value.y));
            writer.WriteValue(value.y);
        }
    }

    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity.Mathematics <see cref="half3"/> type.
    /// </summary>
    public class Half3Converter : PartialConverter<half3>
    {
        protected override void ReadValue(ref half3 value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.x):
                    value.x = new half(reader.ReadAsFloat() ?? 0f);
                    break;
                case nameof(value.y):
                    value.y = new half(reader.ReadAsFloat() ?? 0f);
                    break;
                case nameof(value.z):
                    value.z = new half(reader.ReadAsFloat() ?? 0f);
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, half3 value, JsonSerializer serializer)
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
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity.Mathematics <see cref="half4"/> type.
    /// </summary>
    public class Half4Converter : PartialConverter<half4>
    {
        protected override void ReadValue(ref half4 value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.x):
                    value.x = new half(reader.ReadAsFloat() ?? 0f);
                    break;
                case nameof(value.y):
                    value.y = new half(reader.ReadAsFloat() ?? 0f);
                    break;
                case nameof(value.z):
                    value.z = new half(reader.ReadAsFloat() ?? 0f);
                    break;
                case nameof(value.w):
                    value.w = new half(reader.ReadAsFloat() ?? 0f);
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, half4 value, JsonSerializer serializer)
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
