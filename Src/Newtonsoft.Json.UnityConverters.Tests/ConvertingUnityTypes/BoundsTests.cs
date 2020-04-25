﻿using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class BoundsTests : TypeTester<Bounds>
    {
        public static readonly IReadOnlyCollection<(Bounds deserialized, object anonymous)> representations = new (Bounds, object)[] {
            (new Bounds(
                center: new Vector3(1, 2, 3),
                size: new Vector3(4, 5, 6)
            ), new {
                center = new { x = 1f, y = 2f, z = 3f },
                size = new { x = 4f, y = 5f, z = 6f }
            })
        };
    }

    public class BoundsIntTests : TypeTester<BoundsInt>
    {
        public static readonly IReadOnlyCollection<(BoundsInt deserialized, object anonymous)> representations = new (BoundsInt, object)[] {
            (new BoundsInt(
                position: new Vector3Int(1, 2, 3),
                size: new Vector3Int(4, 5, 6)
            ),
            new {
                position = new { x = 1, y = 2, z = 3 },
                size = new { x = 4, y = 5, z = 6 }
            })
        };
    }
}
