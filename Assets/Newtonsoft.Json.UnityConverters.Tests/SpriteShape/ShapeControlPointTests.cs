using System.Collections.Generic;
using UnityEngine;
#if UNITY_2019_3_OR_NEWER
using UnityEngine.U2D;
#else
using UnityEngine.Experimental.U2D;
#endif

namespace Newtonsoft.Json.UnityConverters.Tests.SpriteShape
{
    public class ShapeControlPointTests : ValueTypeTester<ShapeControlPoint>
    {
        public static readonly IReadOnlyCollection<(ShapeControlPoint deserialized, object anonymous)> representations = new (ShapeControlPoint, object)[] {
            (new ShapeControlPoint(), new {
                position = new { x = 0f, y = 0f, z = 0f },
                leftTangent = new { x = 0f, y = 0f, z = 0f },
                rightTangent = new { x = 0f, y = 0f, z = 0f },
                mode = 0
            }),

            (new ShapeControlPoint {
                position = new Vector3(1f, 2f, 3f),
                leftTangent = new Vector3(4f, 5f, 6f),
                rightTangent = new Vector3(7f, 8f, 9f),
                mode = 10
            }, new {
                position = new { x = 1f, y = 2f, z = 3f },
                leftTangent = new { x = 4f, y = 5f, z = 6f },
                rightTangent = new { x = 7f, y = 8f, z = 9f },
                mode = 10
            }),
        };
    }
}
