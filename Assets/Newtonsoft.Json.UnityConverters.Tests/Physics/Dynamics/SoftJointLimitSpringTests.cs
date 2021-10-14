#if HAVE_MODULE_PHYSICS || !UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Physics.Dynamics
{
    public class SoftJointLimitSpringTests : ValueTypeTester<SoftJointLimitSpring>
    {
        public static readonly IReadOnlyCollection<(SoftJointLimitSpring deserialized, object anonymous)> representations = new (SoftJointLimitSpring, object)[] {
            (new SoftJointLimitSpring(), new {
                spring = 0f,
                damper = 0f,
            }),
            (new SoftJointLimitSpring {
                spring = 1f,
                damper = 2f,
            }, new {
                spring = 1f,
                damper = 2f,
            }),
        };
    }
}
#endif
