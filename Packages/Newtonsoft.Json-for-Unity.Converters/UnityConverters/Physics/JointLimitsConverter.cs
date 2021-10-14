#if HAVE_MODULE_PHYSICS || !UNITY_2019_1_OR_NEWER
using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Physics
{
    public class JointLimitsConverter : PartialConverter<JointLimits>
    {
        protected override void ReadValue(ref JointLimits value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.min):
                    value.min = reader.ReadAsFloat() ?? 0f;
                    break;
                case nameof(value.max):
                    value.max = reader.ReadAsFloat() ?? 0f;
                    break;
                case nameof(value.bounciness):
                    value.bounciness = reader.ReadAsFloat() ?? 0f;
                    break;
                case nameof(value.bounceMinVelocity):
                    value.bounceMinVelocity = reader.ReadAsFloat() ?? 0f;
                    break;
                case nameof(value.contactDistance):
                    value.contactDistance = reader.ReadAsFloat() ?? 0f;
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, JointLimits value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.min));
            writer.WriteValue(value.min);
            writer.WritePropertyName(nameof(value.max));
            writer.WriteValue(value.max);
            writer.WritePropertyName(nameof(value.bounciness));
            writer.WriteValue(value.bounciness);
            writer.WritePropertyName(nameof(value.bounceMinVelocity));
            writer.WriteValue(value.bounceMinVelocity);
            writer.WritePropertyName(nameof(value.contactDistance));
            writer.WriteValue(value.contactDistance);
        }
    }
}
#endif
