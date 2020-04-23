using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class RectTests : TypeTester<Rect>
    {
        public static readonly IReadOnlyCollection<(Rect deserialized, object anonymous)> representations = new (Rect, object)[] {
            (new Rect(1, 2, 3, 4), new { x = 1.0, y = 2.0, width = 3.0, height = 4.0 })
        };
    }

    public class RectIntTests : TypeTester<RectInt>
    {
        public static readonly IReadOnlyCollection<(RectInt deserialized, object anonymous)> representations = new (RectInt, object)[] {
            (new RectInt(1, 2, 3, 4), new { x = 1, y = 2, width = 3, height = 4 })
        };
    }
}
