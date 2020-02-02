using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class RectTests : TypeTester<Rect>
    {
        public static (Rect deserialized, string serialized)[] Representations { get; } = new[] {
            (new Rect(1, 2, 3, 4), @"{""x"":1.0,""y"":2.0,""width"":3.0,""height"":4.0}")
        };

        protected override void ConfigureSettings(JsonSerializerSettings settings)
        {
        }
    }
}
