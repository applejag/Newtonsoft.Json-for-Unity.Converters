#if HAVE_MODULE_PHYSICS2D || !UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Physics2D
{
    public class JointTranslationLimits2DTests : ValueTypeTester<JointTranslationLimits2D>
    {
        public static readonly IReadOnlyCollection<(JointTranslationLimits2D deserialized, object anonymous)> representations = new (JointTranslationLimits2D, object)[] {
            (new JointTranslationLimits2D(), new { min = 0f, max = 0f }),
            (new JointTranslationLimits2D { min = 1, max = 2 }, new { min = 1f, max = 2f }),
        };
    }
}
#endif
