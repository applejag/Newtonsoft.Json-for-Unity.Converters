using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Physics
{
    public class SoftJointLimitConverter : PartialFloatConverter<SoftJointLimit>
    {
        private static readonly string[] _memberNames = { "limit", "bounciness", "contactDistance" };

        public SoftJointLimitConverter()
            : base(_memberNames)
        {
        }

        protected override SoftJointLimit CreateInstanceFromValues(ValuesArray<float> values)
        {
            return new SoftJointLimit {
                limit = values[0],
                bounciness = values[1],
                contactDistance = values[2],
            };
        }

        protected override float[] ReadInstanceValues(SoftJointLimit instance)
        {
            return new[] {
                instance.limit,
                instance.bounciness,
                instance.contactDistance,
            };
        }
    }
}
