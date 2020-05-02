using System.Collections.Generic;
using System.Linq;
#if UNITY_2019_3_OR_NEWER
using UnityEngine.U2D;
#else
using UnityEngine.Experimental.U2D;
#endif

namespace Newtonsoft.Json.UnityConverters.Tests.SpriteShape
{
    public class AngleRangeInfoTests : ValueTypeTester<AngleRangeInfo>
    {
        public static readonly IReadOnlyCollection<(AngleRangeInfo deserialized, object anonymous)> representations = new (AngleRangeInfo, object)[] {
            (new AngleRangeInfo(), new {
                start = 0f,
                end = 0f,
                order = 0u,
                sprites = null as int[],
            }),

            (new AngleRangeInfo {
                start = 1f,
                end = 2f,
                order = 3u,
                sprites = new [] { 4, 5, 6 },
            }, new {
                start = 1f,
                end = 2f,
                order = 3u,
                sprites = new [] { 4, 5, 6 },
            }),
        };

        protected override bool AreEqual(AngleRangeInfo a, AngleRangeInfo b)
        {
            if (a.start != b.start
                || a.end != b.end
                || a.order != b.order)
            {
                return false;
            }

            if (a.sprites == null && b.sprites == null)
            {
                return true;
            }
            else if (a.sprites == null || b.sprites == null)
            {
                return false;
            }

            return a.sprites.SequenceEqual(b.sprites);
        }
    }
}
