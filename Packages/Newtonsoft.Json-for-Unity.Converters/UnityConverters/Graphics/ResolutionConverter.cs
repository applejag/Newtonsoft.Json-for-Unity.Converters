using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Graphics
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity Color type <see cref="Color"/>.
    /// </summary>
    public class ResolutionConverter : PartialConverter<Resolution>
    {
        protected override void ReadValue(ref Resolution value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.width):
                    value.width = reader.ReadAsInt32() ?? 0;
                    break;
                case nameof(value.height):
                    value.height = reader.ReadAsInt32() ?? 0;
                    break;
#pragma warning disable CS0618 // Type or member is obsolete
                case nameof(value.refreshRate):
                    value.refreshRate = reader.ReadAsInt32() ?? 0;
                    break;
#pragma warning restore CS0618 // Type or member is obsolete
#if UNITY_2022_2_OR_NEWER
                case nameof(value.refreshRateRatio):
                    value.refreshRateRatio = reader.ReadViaSerializer<RefreshRate>(serializer);
                    break;
#endif
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, Resolution value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.width));
            writer.WriteValue(value.width);
            writer.WritePropertyName(nameof(value.height));
            writer.WriteValue(value.height);
#pragma warning disable CS0618 // Type or member is obsolete
            writer.WritePropertyName(nameof(value.refreshRate));
#if UNITY_2022_2_OR_NEWER
            if (double.IsNaN(value.refreshRateRatio.value))
            {
                writer.WriteValue(0);
            }
            else
            {
                writer.WriteValue(value.refreshRate);
            }
#else
            writer.WriteValue(value.refreshRate);
#endif
#pragma warning restore CS0618 // Type or member is obsolete
#if UNITY_2022_2_OR_NEWER
            writer.WritePropertyName(nameof(value.refreshRateRatio));
            serializer.Serialize(writer, value.refreshRateRatio);
#endif
        }
    }
}
