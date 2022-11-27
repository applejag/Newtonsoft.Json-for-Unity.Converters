#if HAVE_MODULE_PHYSICS2D || !UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Physics2D
{
    public class JointSuspension2DTests : ValueTypeTester<JointSuspension2D>
    {
        public static readonly IReadOnlyCollection<(JointSuspension2D deserialized, object anonymous)> representations = new (JointSuspension2D, object)[] {
            (new JointSuspension2D(), new {
                dampingRatio = 0f, frequency = 0f, angle = 0f
            }),
            (new JointSuspension2D {
                dampingRatio = 1, frequency = 2, angle = 3
            }, new {
                dampingRatio = 1f, frequency = 2f, angle = 3f
            }),
        };
    }
}
#endif
