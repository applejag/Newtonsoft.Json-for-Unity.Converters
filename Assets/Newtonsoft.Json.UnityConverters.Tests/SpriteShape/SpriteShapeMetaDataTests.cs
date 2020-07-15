using System.Collections.Generic;
#if UNITY_2019_3_OR_NEWER
using UnityEngine.U2D;
#else
using UnityEngine.Experimental.U2D;
#endif

namespace Newtonsoft.Json.UnityConverters.Tests.SpriteShape
{
    public class SpriteShapeMetaDataTests : ValueTypeTester<SpriteShapeMetaData>
    {
        public static readonly IReadOnlyCollection<(SpriteShapeMetaData deserialized, object anonymous)> representations = new (SpriteShapeMetaData, object)[] {
            (new SpriteShapeMetaData(), new {
                height = 0f,
                bevelCutoff = 0f,
                bevelSize = 0f,
                spriteIndex = 0u,
                corner = false,
            }),

            (new SpriteShapeMetaData {
                height = 1f,
                bevelCutoff = 2f,
                bevelSize = 3f,
                spriteIndex = 4u,
                corner = true,
            }, new {
                height = 1f,
                bevelCutoff = 2f,
                bevelSize = 3f,
                spriteIndex = 4u,
                corner = true,
            }),
        };
    }
}
