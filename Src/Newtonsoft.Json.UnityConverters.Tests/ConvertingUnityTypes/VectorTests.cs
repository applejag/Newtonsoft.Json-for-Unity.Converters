using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class Vector2Tests : TypeTester<Vector2>
    {
        public static readonly IReadOnlyCollection<(Vector2 deserialized, string serialized)> representations = new[] {
            (new Vector2(1, 2), @"{""x"":1.0,""y"":2.0}")
        };
    }

    public class Vector2IntTests : TypeTester<Vector2Int>
    {
        public static readonly IReadOnlyCollection<(Vector2Int deserialized, string serialized)> representations = new[] {
            (new Vector2Int(1, 2), @"{""x"":1,""y"":2}")
        };
    }

    public class Vector3Tests : TypeTester<Vector3>
    {
        public static readonly IReadOnlyCollection<(Vector3 deserialized, string serialized)> representations = new[] {
            (new Vector3(1, 2, 3), @"{""x"":1.0,""y"":2.0,""z"":3.0}")
        };
    }

    public class Vector3IntTests : TypeTester<Vector3Int>
    {
        public static IReadOnlyCollection<(Vector3Int deserialized, string serialized)> representations = new[] {
            (new Vector3Int(1, 2, 3), @"{""x"":1,""y"":2,""z"":3}")
        };
    }

    public class Vector4Tests : TypeTester<Vector4>
    {
        public static readonly IReadOnlyCollection<(Vector4 deserialized, string serialized)> representations = new[] {
            (new Vector4(1, 2, 3, 4), @"{""x"":1.0,""y"":2.0,""z"":3.0,""w"":4.0}")
        };
    }
}
