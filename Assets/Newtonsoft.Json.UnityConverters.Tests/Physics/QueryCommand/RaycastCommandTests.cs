#if HAVE_MODULE_PHYSICS || !UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Physics.QueryCommand
{
    public class RaycastCommandTests : ValueTypeTester<RaycastCommand>
    {
        public static readonly IReadOnlyCollection<(RaycastCommand deserialized, object anonymous)> representations = new (RaycastCommand, object)[] {
            (new RaycastCommand(), new {
                from = new { x = 0f, y = 0f, z = 0f },
                direction = new { x = 0f, y = 0f, z = 0f },
                distance = 0f,
                layerMask = 0,
                maxHits = 0,
            }),
            (new RaycastCommand {
                from = new Vector3(1f, 2f, 3f),
                direction = new Vector3(4f, 5f, 6f),
                distance = 7f,
                layerMask = 8,
                maxHits = 9,
            }, new {
                from = new { x = 1f, y = 2f, z = 3f },
                direction = new { x = 4f, y = 5f, z = 6f },
                distance = 7f,
                layerMask = 8,
                maxHits = 9,
            }),
        };
    }
}
#endif
