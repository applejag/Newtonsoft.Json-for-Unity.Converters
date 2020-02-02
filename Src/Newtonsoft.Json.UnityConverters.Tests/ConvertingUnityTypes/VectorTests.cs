using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class Vector2Tests : TypeTester<Vector2>
    {
        public static (Vector2 deserialized, string serialized)[] Representations { get; } = new[] {
            (new Vector2(1, 2), @"{""x"":1.0,""y"":2.0}")
        };

        protected override void ConfigureSettings(JsonSerializerSettings settings)
        {
        }
    }

    public class Vector2IntTests : TypeTester<Vector2Int>
    {
        public static (Vector2Int deserialized, string serialized)[] Representations { get; } = new[] {
            (new Vector2Int(1, 2), @"{""x"":1,""y"":2}")
        };

        protected override void ConfigureSettings(JsonSerializerSettings settings)
        {
        }
    }

    public class Vector3Tests : TypeTester<Vector3>
    {
        public static (Vector3 deserialized, string serialized)[] Representations { get; } = new[] {
            (new Vector3(1, 2, 3), @"{""x"":1.0,""y"":2.0,""z"":3.0}")
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

    public class Vector4Tests : TypeTester<Vector4>
    {
        public static (Vector4 deserialized, string serialized)[] Representations { get; } = new[] {
            (new Vector4(1, 2, 3, 4), @"{""x"":1.0,""y"":2.0,""z"":3.0,""w"":4.0}")
        };

        protected override void ConfigureSettings(JsonSerializerSettings settings)
        {
        }
    }
}
