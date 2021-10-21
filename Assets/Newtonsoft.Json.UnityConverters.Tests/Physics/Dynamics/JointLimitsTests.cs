#if HAVE_MODULE_PHYSICS || !UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Physics.Dynamics
{
    public class JointLimitsTests : ValueTypeTester<JointLimits>
    {
        public static readonly IReadOnlyCollection<(JointLimits deserialized, object anonymous)> representations = new (JointLimits, object)[] {
            (new JointLimits(), new {
                min = 0f,
                max = 0f,
                bounciness = 0f,
                bounceMinVelocity = 0f,
                contactDistance = 0f,
            }),
            (new JointLimits {
                min = 1f,
                max = 2f,
                bounciness = 3f,
                bounceMinVelocity = 4f,
                contactDistance = 5f,
            }, new {
                min = 1f,
                max = 2f,
                bounciness = 3f,
                bounceMinVelocity = 4f,
                contactDistance = 5f,
            }),
        };
    }
}
#endif
