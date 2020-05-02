#if UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace Newtonsoft.Json.UnityConverters.Tests.RenderPipeline
{
    public class RenderQueueRangeTests : ValueTypeTester<RenderQueueRange>
    {
        public static readonly IReadOnlyCollection<(RenderQueueRange deserialized, object anonymous)> representations = new (RenderQueueRange, object)[] {
            (new RenderQueueRange(), new { lowerBound = 0, upperBound = 0 }),
            (new RenderQueueRange(1, 2), new { lowerBound = 1, upperBound = 2 }),
        };
    }
}
#endif
