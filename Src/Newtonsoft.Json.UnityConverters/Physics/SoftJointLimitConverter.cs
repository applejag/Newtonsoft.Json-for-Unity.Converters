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
                limit = values.GetAsTypeOrDefault<float>(0),
                bounciness = values.GetAsTypeOrDefault<float>(1),
                contactDistance = values.GetAsTypeOrDefault<float>(2),
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
