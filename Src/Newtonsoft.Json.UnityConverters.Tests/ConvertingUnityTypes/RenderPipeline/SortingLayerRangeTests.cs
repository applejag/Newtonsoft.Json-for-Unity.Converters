﻿using System.Collections.Generic;
using UnityEngine.Rendering;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes.RenderPipeline
{
    public class SortingLayerRangeTests : ValueTypeTester<SortingLayerRange>
    {
        public static readonly IReadOnlyCollection<(SortingLayerRange deserialized, object anonymous)> representations = new (SortingLayerRange, object)[] {
            (new SortingLayerRange(), new { lowerBound = 0, upperBound = 0 }),
            (new SortingLayerRange(1, 2), new { lowerBound = (short)1, upperBound = (short)2 }),
        };
    }
}
