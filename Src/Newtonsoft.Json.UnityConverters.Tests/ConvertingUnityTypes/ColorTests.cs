using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class ColorTests : TypeTester<Color>
    {
        public static (Color deserialized, string serialized)[] Representations { get; } = new[] {
            (new Color(1, 2, 3, 4), @"{""r"":1.0,""g"":2.0,""b"":3.0,""a"":4.0}")
        };

        protected override void ConfigureSettings(JsonSerializerSettings settings)
        {
        }
    }
}
