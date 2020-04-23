using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class Vector2Tests : TypeTester<Vector2>
    {
        public static readonly IReadOnlyCollection<(Vector2 deserialized, object anonymous)> representations = new (Vector2, object)[] {
            (new Vector2(1, 2), new { x = 1.0, y = 2.0 })
        };
    }

    public class Vector2IntTests : TypeTester<Vector2Int>
    {
        public static readonly IReadOnlyCollection<(Vector2Int deserialized, object anonymous)> representations = new (Vector2Int, object)[] {
            (new Vector2Int(1, 2), new { x = 1, y = 2 })
        };
    }

    public class Vector3Tests : TypeTester<Vector3>
    {
        public static readonly IReadOnlyCollection<(Vector3 deserialized, object anonymous)> representations = new (Vector3, object)[] {
            (new Vector3(1, 2, 3), new { x = 1.0, y = 2.0, z = 3.0 })
        };
    }

    public class Vector3IntTests : TypeTester<Vector3Int>
    {
        public static readonly IReadOnlyCollection<(Vector3Int deserialized, object anonymous)> representations = new (Vector3Int, object)[] {
            (new Vector3Int(1, 2, 3), new { x = 1, y = 2, z = 3 })
        };
    }

    public class Vector4Tests : TypeTester<Vector4>
    {
        public static readonly IReadOnlyCollection<(Vector4 deserialized, object anonymous)> representations = new (Vector4, object)[] {
            (new Vector4(1, 2, 3, 4), new { x = 1.0, y = 2.0, z = 3.0, w = 4.0 })
        };
    }
}
