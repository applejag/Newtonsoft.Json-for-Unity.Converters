using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class ColorTests : ValueTypeTester<Color>
    {
        public static readonly IReadOnlyCollection<(Color deserialized, object anonymous)> representations = new (Color, object)[] {
            (new Color(1, 2, 3, 4), new { r = 1.0, g = 2.0, b = 3.0, a = 4.0 })
        };
    }

    public class Color32Tests : ValueTypeTester<Color32>
    {
        public static readonly IReadOnlyCollection<(Color32 deserialized, object anonymous)> representations = new (Color32, object)[] {
            (new Color32(1, 2, 3, 4), new { r = 1, g = 2, b = 3, a = 4 })
        };
    }
}
