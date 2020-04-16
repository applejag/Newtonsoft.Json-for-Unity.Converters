﻿using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class ColorTests : TypeTester<Color>
    {
        public static readonly IReadOnlyCollection<(Color deserialized, string serialized)> representations = new[] {
            (new Color(1, 2, 3, 4), @"{""r"":1.0,""g"":2.0,""b"":3.0,""a"":4.0}")
        };
    }

    public class Color32Tests : TypeTester<Color32>
    {
        public static readonly IReadOnlyCollection<(Color32 deserialized, string serialized)> representations = new[] {
            (new Color32(1, 2, 3, 4), @"{""r"":1,""g"":2,""b"":3,""a"":4}")
        };
    }
}
