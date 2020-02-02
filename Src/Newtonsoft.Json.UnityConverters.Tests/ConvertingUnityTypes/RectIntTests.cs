using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class RectIntTests : TypeTester<RectInt>
    {
        public static (RectInt deserialized, string serialized)[] Representations { get; } = new[] {
            (new RectInt(1, 2, 3, 4), @"{""x"":1,""y"":2,""width"":3,""height"":4}")
        };

        protected override void ConfigureSettings(JsonSerializerSettings settings)
        {
        }
    }
}
