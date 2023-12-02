using System.Collections.Generic;
using UnityEngine.SocialPlatforms;

namespace Newtonsoft.Json.UnityConverters.Tests.GameCenter
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class RangeTests : ValueTypeTester<Range>
    {
        public static readonly IReadOnlyCollection<(Range deserialized, object anonymous)> representations = new (Range, object)[] {
            (new Range(), new { from = 0, count = 0 }),
            (new Range(1, 2), new { from = 1, count = 2 }),
        };
    }
#pragma warning restore CS0618 // Type or member is obsolete
}
