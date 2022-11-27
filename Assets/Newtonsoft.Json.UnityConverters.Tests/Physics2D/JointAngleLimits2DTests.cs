#if HAVE_MODULE_PHYSICS2D || !UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Physics2D
{
    public class JointAngleLimits2DTests : ValueTypeTester<JointAngleLimits2D>
    {
        public static readonly IReadOnlyCollection<(JointAngleLimits2D deserialized, object anonymous)> representations = new (JointAngleLimits2D, object)[] {
            (new JointAngleLimits2D(), new { min = 0f, max = 0f }),
            (new JointAngleLimits2D { min = 1, max = 2 }, new { min = 1f, max = 2f }),
        };
    }
}
#endif
