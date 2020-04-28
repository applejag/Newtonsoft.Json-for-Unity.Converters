using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Physics
{
    public class JointDriveConverter : PartialFloatConverter<JointDrive>
    {
        private static readonly string[] _memberNames = { "positionSpring", "positionDamper", "maximumForce" };

        public JointDriveConverter()
            : base(_memberNames)
        {
        }

        protected override JointDrive CreateInstanceFromValues(ValuesArray<float> values)
        {
            return new JointDrive {
                positionSpring = values.GetAsTypeOrDefault<float>(0),
                positionDamper = values.GetAsTypeOrDefault<float>(1),
                maximumForce = values.GetAsTypeOrDefault<float>(2),
            };
        }

        protected override float[] ReadInstanceValues(JointDrive instance)
        {
            return new[] {
                instance.positionSpring,
                instance.positionDamper,
                instance.maximumForce,
            };
        }
    }
}
