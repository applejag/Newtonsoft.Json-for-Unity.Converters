#if HAVE_MODULE_PHYSICS || !UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Physics.Dynamics
{
    public class JointSpringTests : ValueTypeTester<JointSpring>
    {
        public static readonly IReadOnlyCollection<(JointSpring deserialized, object anonymous)> representations = new (JointSpring, object)[] {
            (new JointSpring(), new {
                spring = 0f,
                damper = 0f,
                targetPosition = 0f,
            }),
            (new JointSpring {
                spring = 1f,
                damper = 2f,
                targetPosition = 3f,
            }, new {
                spring = 1f,
                damper = 2f,
                targetPosition = 3f,
            }),
        };
    }
}
#endif
