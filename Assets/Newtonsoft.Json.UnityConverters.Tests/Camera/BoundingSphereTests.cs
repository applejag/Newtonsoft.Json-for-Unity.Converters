using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Camera
{
    public class BoundingSphereTests : ValueTypeTester<BoundingSphere>
    {
        public static readonly IReadOnlyCollection<(BoundingSphere deserialized, object anonymous)> representations = new (BoundingSphere, object)[] {
            (new BoundingSphere(), new {
                position = new { x = 0f, y = 0f, z = 0f },
                radius = 0f,
            }),
            (new BoundingSphere {
                position = new Vector3(1f, 2f, 3f),
                radius = 4f,
            }, new {
                position = new { x = 1f, y = 2f, z = 3f },
                radius = 4f,
            }),
        };
    }
}
