using System.Collections.Generic;
using UnityEngine.SocialPlatforms;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes.GameCenter
{
    public class RangeTests : ValueTypeTester<Range>
    {
        public static readonly IReadOnlyCollection<(Range deserialized, object anonymous)> representations = new (Range, object)[] {
            (new Range(1, 2), new { from = 1, count = 2 })
        };
    }
}
