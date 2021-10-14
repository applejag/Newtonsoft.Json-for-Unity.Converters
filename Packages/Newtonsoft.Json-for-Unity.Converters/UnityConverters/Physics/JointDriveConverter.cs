#if HAVE_MODULE_PHYSICS || !UNITY_2019_1_OR_NEWER
using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Physics
{
    public class JointDriveConverter : PartialConverter<JointDrive>
    {
        protected override void ReadValue(ref JointDrive value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.positionSpring):
                    value.positionSpring = reader.ReadAsFloat() ?? 0f;
                    break;
                case nameof(value.positionDamper):
                    value.positionDamper = reader.ReadAsFloat() ?? 0f;
                    break;
                case nameof(value.maximumForce):
                    value.maximumForce = reader.ReadAsFloat() ?? 0f;
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, JointDrive value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.positionSpring));
            writer.WriteValue(value.positionSpring);
            writer.WritePropertyName(nameof(value.positionDamper));
            writer.WriteValue(value.positionDamper);
            writer.WritePropertyName(nameof(value.maximumForce));
            writer.WriteValue(value.maximumForce);
        }
    }
}
#endif
