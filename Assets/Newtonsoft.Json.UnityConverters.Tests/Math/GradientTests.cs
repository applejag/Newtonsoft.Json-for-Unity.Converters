using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Math
{
    public class GradientTests : TypeTester<Gradient>
    {
        public static readonly IReadOnlyCollection<(Gradient deserialized, object anonymous)> representations = new (Gradient, object)[] {
            (new Gradient(), new {
                colorKeys = new[] {
                    new { color = new { r = 1f, g = 1f, b = 1f, a = 1f }, time = 0f },
                    new { color = new { r = 1f, g = 1f, b = 1f, a = 1f }, time = 1f },
                },
                alphaKeys = new [] {
                    new { alpha = 1f, time = 0f },
                    new { alpha = 1f, time = 1f },
                },
                mode = GradientMode.Blend
            }),
            (new Gradient{
                colorKeys = new[] {
                    // Note 1: The Color alpha channel is reset to 1
                    //         by an internal GradientColorKey.Init call
                    //         as alpha is controlled by the Gradient.alphaKeys
                    //
                    // Note 2: The time is is clamped between 0-1, which
                    //         is also done by GradientColorKey.Init.
                    new GradientColorKey(new Color(5, 6, 7, 1), .2f),
                    new GradientColorKey(new Color(10, 11, 12, 1), .4f),
                },
                alphaKeys = new [] {
                    // Note 3: Same as Note 2. The time is is clamped between
                    //         0-1 here as well, which is also done by
                    //         GradientColorKey.Init.
                    new GradientAlphaKey(1, .6f),
                    new GradientAlphaKey(3, .8f),
                },
                mode = GradientMode.Blend
            }, new {
                colorKeys = new[] {
                    new { color = new { r = 5f, g = 6f, b = 7f, a = 1f }, time = .2f },
                    new { color = new { r = 10f, g = 11f, b = 12f, a = 1f }, time = .4f },
                },
                alphaKeys = new [] {
                    new { alpha = 1f, time = .6f },
                    new { alpha = 3f, time = .8f },
                },
                mode = GradientMode.Blend
            }),
        };

        protected override bool AreEqual(Gradient a, Gradient b)
        {
            return a.alphaKeys.SequenceEqual(b.alphaKeys)
                && a.colorKeys.SequenceEqual(b.colorKeys)
                && a.mode == b.mode;
        }
    }

    public class GradientAlphaKeyTests : ValueTypeTester<GradientAlphaKey>
    {
        public static readonly IReadOnlyCollection<(GradientAlphaKey deserialized, object anonymous)> representations = new (GradientAlphaKey, object)[] {
            (new GradientAlphaKey(1, 2), new { alpha = 1f, time = 2f })
        };
    }

    public class GradientColorKeyTests : ValueTypeTester<GradientColorKey>
    {
        public static readonly IReadOnlyCollection<(GradientColorKey deserialized, object anonymous)> representations = new (GradientColorKey, object)[] {
            (new GradientColorKey(new Color(1,2,3,.5f), 5), new { color = new Color(1,2,3,.5f), time = 5f })
        };
    }
}
