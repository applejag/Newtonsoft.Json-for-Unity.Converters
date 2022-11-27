#if HAVE_MODULE_PHYSICS || !UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Physics.QueryCommand
{
    public class BoxcastCommandTests : ValueTypeTester<BoxcastCommand>
    {
        public static readonly IReadOnlyCollection<(BoxcastCommand deserialized, object anonymous)> representations = new (BoxcastCommand, object)[] {
            (new BoxcastCommand(), new {
                center = new { x = 0f, y = 0f, z = 0f },
                halfExtents = new { x = 0f, y = 0f, z = 0f },
                orientation = new { x = 0f, y = 0f, z = 0f, w = 0f },
                direction = new { x = 0f, y = 0f, z = 0f },
                distance = 0f,
                layerMask = 0
            }),
            (new BoxcastCommand {
                center = new Vector3(1f, 2f, 3f),
                halfExtents = new Vector3(4f, 5f, 6f),
                orientation = new Quaternion(7f, 8f, 9f, 10f),
                direction = new Vector3(11f, 12f, 13f),
                distance = 14f,
                layerMask = 15
            }, new {
                center = new { x = 1f, y = 2f, z = 3f },
                halfExtents = new { x = 4f, y = 5f, z = 6f },
                orientation = new { x = 7f, y = 8f, z = 9f, w = 10f },
                direction = new { x = 11f, y = 12f, z = 13f },
                distance = 14f,
                layerMask = 15
            }),
        };
    }
}
#endif
