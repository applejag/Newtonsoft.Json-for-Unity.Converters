#if UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace Newtonsoft.Json.UnityConverters.Tests.RenderPipeline
{
    public class FilteringSettingsTests : ValueTypeTester<FilteringSettings>
    {
        public static readonly IReadOnlyCollection<(FilteringSettings deserialized, object anonymous)> representations = new (FilteringSettings, object)[] {
            (new FilteringSettings(), new {
                renderQueueRange = new { lowerBound = 0, upperBound = 0 },
                layerMask = 0,
                renderingLayerMask = 0u,
                excludeMotionVectorObjects = false,
                sortingLayerRange = new { lowerBound = (short)0, upperBound = (short)0 },
            }),

            (new FilteringSettings {
                renderQueueRange = new RenderQueueRange(1, 2),
                layerMask = 3,
                renderingLayerMask = 4,
                excludeMotionVectorObjects = true,
                sortingLayerRange = new SortingLayerRange(6, 7),
            }, new {
                renderQueueRange = new { lowerBound = 1, upperBound = 2 },
                layerMask = 3,
                renderingLayerMask = 4u,
                excludeMotionVectorObjects = true,
                sortingLayerRange = new { lowerBound = (short)6, upperBound = (short)7 },
            }),
        };
    }
}
#endif
