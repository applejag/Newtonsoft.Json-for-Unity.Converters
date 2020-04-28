using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Physics
{
    public class JointLimitsConverter : PartialFloatConverter<JointLimits>
    {
        private static readonly string[] _memberNames = { "min", "max", "bounciness", "bounceMinVelocity", "contactDistance" };

        public JointLimitsConverter()
            : base(_memberNames)
        {
        }

        protected override JointLimits CreateInstanceFromValues(ValuesArray<float> values)
        {
            return new JointLimits {
                min = values.GetAsTypeOrDefault<float>(0),
                max = values.GetAsTypeOrDefault<float>(1),
                bounciness = values.GetAsTypeOrDefault<float>(2),
                bounceMinVelocity = values.GetAsTypeOrDefault<float>(3),
                contactDistance = values.GetAsTypeOrDefault<float>(4),
            };
        }

        protected override float[] ReadInstanceValues(JointLimits instance)
        {
            return new[] {
                instance.min,
                instance.max,
                instance.bounciness,
                instance.bounceMinVelocity,
                instance.contactDistance,
            };
        }
    }
}
