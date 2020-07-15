using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Geometry
{
    public class RectTests : ValueTypeTester<Rect>
    {
        public static readonly IReadOnlyCollection<(Rect deserialized, object anonymous)> representations = new (Rect, object)[] {
            (new Rect(), new { x = 0f, y = 0f, width = 0f, height = 0f }),
            (new Rect(1, 2, 3, 4), new { x = 1f, y = 2f, width = 3f, height = 4f }),
        };
    }

    public class RectIntTests : ValueTypeTester<RectInt>
    {
        public static readonly IReadOnlyCollection<(RectInt deserialized, object anonymous)> representations = new (RectInt, object)[] {
            (new RectInt(), new { x = 0, y = 0, width = 0, height = 0 }),
            (new RectInt(1, 2, 3, 4), new { x = 1, y = 2, width = 3, height = 4 }),
        };
    }

    public class RectOffsetTests : TypeTester<RectOffset>
    {
        public static readonly IReadOnlyCollection<(RectOffset deserialized, object anonymous)> representations = new (RectOffset, object)[] {
            (new RectOffset(), new { left = 0, right = 0, top = 0, bottom = 0 }),
            (new RectOffset(1, 2, 3, 4), new { left = 1, right = 2, top = 3, bottom = 4 }),
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
