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
                min = values[0],
                max = values[1],
                bounciness = values[2],
                bounceMinVelocity = values[3],
                contactDistance = values[4],
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
