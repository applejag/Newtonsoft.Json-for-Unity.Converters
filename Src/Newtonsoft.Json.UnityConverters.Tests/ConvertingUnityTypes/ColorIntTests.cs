using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class Color32Tests : TypeTester<Color32>
    {
        public static (Color32 deserialized, string serialized)[] Representations { get; } = new[] {
            (new Color32(1, 2, 3, 4), @"{""r"":1,""g"":2,""b"":3,""a"":4}")
        };

        protected override void ConfigureSettings(JsonSerializerSettings settings)
        {
        }
    }
}
