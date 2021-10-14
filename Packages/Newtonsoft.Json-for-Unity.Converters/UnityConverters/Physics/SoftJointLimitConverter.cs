#if HAVE_MODULE_PHYSICS || !UNITY_2019_1_OR_NEWER
using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Physics
{
    public class SoftJointLimitConverter : PartialConverter<SoftJointLimit>
    {
        protected override void ReadValue(ref SoftJointLimit value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.limit):
                    value.limit = reader.ReadAsFloat() ?? 0f;
                    break;
                case nameof(value.bounciness):
                    value.bounciness = reader.ReadAsFloat() ?? 0f;
                    break;
                case nameof(value.contactDistance):
                    value.contactDistance = reader.ReadAsFloat() ?? 0f;
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, SoftJointLimit value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.limit));
            writer.WriteValue(value.limit);
            writer.WritePropertyName(nameof(value.bounciness));
            writer.WriteValue(value.bounciness);
            writer.WritePropertyName(nameof(value.contactDistance));
            writer.WriteValue(value.contactDistance);
        }
    }
}
#endif
