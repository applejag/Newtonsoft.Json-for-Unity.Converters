using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class RectTests : ValueTypeTester<Rect>
    {
        public static readonly IReadOnlyCollection<(Rect deserialized, object anonymous)> representations = new (Rect, object)[] {
            (new Rect(1, 2, 3, 4), new { x = 1.0, y = 2.0, width = 3.0, height = 4.0 })
        };
    }

    public class RectIntTests : ValueTypeTester<RectInt>
    {
        public static readonly IReadOnlyCollection<(RectInt deserialized, object anonymous)> representations = new (RectInt, object)[] {
            (new RectInt(1, 2, 3, 4), new { x = 1, y = 2, width = 3, height = 4 })
        };
    }

    public class RectOffsetTests : TypeTester<RectOffset>
    {
        public static readonly IReadOnlyCollection<(RectOffset deserialized, object anonymous)> representations = new (RectOffset, object)[] {
            (new RectOffset(1, 2, 3, 4), new { left = 1, right = 2, top = 3, bottom = 4 })
        };

        protected override bool AreEqual(RectOffset a, RectOffset b)
        {
            return a.left == b.left
                && a.right == b.right
                && a.top == b.top
                && a.bottom == b.bottom;
        }
    }
}
