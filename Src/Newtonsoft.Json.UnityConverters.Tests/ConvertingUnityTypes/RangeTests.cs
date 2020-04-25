using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class RangeTests : ValueTypeTester<Range>
    {
        public static readonly IReadOnlyCollection<(Range deserialized, object anonymous)> representations = new (Range, object)[] {
            (new Range(1, 2), new { from = 1, count = 2 })
        };
    }

    public class RangeIntTests : ValueTypeTester<RangeInt>
    {
        public static readonly IReadOnlyCollection<(RangeInt deserialized, object anonymous)> representations = new (RangeInt, object)[] {
            (new RangeInt(1, 2), new { start = 1, length = 2 })
        };
    }
}
