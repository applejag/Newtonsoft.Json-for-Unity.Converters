using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class Vector2IntTests : TypeTester<Vector2Int>
    {
        public static (Vector2Int deserialized, string serialized)[] Representations { get; } = new[] {
            (new Vector2Int(1, 2), @"{""x"":1,""y"":2}")
        };

        protected override void ConfigureSettings(JsonSerializerSettings settings)
        {
        }
    }

    public class Vector3IntTests : TypeTester<Vector3Int>
    {
        public static (Vector3Int deserialized, string serialized)[] Representations { get; } = new[] {
            (new Vector3Int(1, 2, 3), @"{""x"":1,""y"":2,""z"":3}")
        };

        protected override void ConfigureSettings(JsonSerializerSettings settings)
        {
        }
    }
}
