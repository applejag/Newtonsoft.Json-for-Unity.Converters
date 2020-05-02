using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Math
{
    public class ColorTests : ValueTypeTester<Color>
    {
        public static readonly IReadOnlyCollection<(Color deserialized, object anonymous)> representations = new (Color, object)[] {
            (new Color(), new { r = 0f, g = 0f, b = 0f, a = 0f }),
            (new Color(1, 2, 3, 4), new { r = 1f, g = 2f, b = 3f, a = 4f }),
        };
    }

    public class Color32Tests : ValueTypeTester<Color32>
    {
        public static readonly IReadOnlyCollection<(Color32 deserialized, object anonymous)> representations = new (Color32, object)[] {
            (new Color32(), new { r = 0, g = 0, b = 0, a = 0 }),
            (new Color32(1, 2, 3, 4), new { r = 1, g = 2, b = 3, a = 4 }),
        };
    }
}
