#if HAVE_MODULE_PHYSICS || !UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Physics.QueryCommand
{
    public class CapsulecastCommandTests : ValueTypeTester<CapsulecastCommand>
    {
        public static readonly IReadOnlyCollection<(CapsulecastCommand deserialized, object anonymous)> representations = new (CapsulecastCommand, object)[] {
            (new CapsulecastCommand(), new {
                point1= new { x = 0f, y = 0f, z = 0f },
                point2 = new { x = 0f, y = 0f, z = 0f },
                radius = 0f,
                direction = new { x = 0f, y = 0f, z = 0f },
                distance = 0f,
                layerMask = 0,
            }),
            (new CapsulecastCommand {
                point1 = new Vector3(1f, 2f, 3f),
                point2 = new Vector3(4f, 5f, 6f),
                radius = 7f,
                direction = new Vector3(8f, 9f, 10f),
                distance = 11f,
                layerMask = 12,
            }, new {
                point1 = new { x = 1f, y = 2f, z = 3f },
                point2 = new { x = 4f, y = 5f, z = 6f },
                radius = 7f,
                direction = new { x = 8f, y = 9f, z = 10f },
                distance = 11f,
                layerMask = 12,
            }),
        };
    }
}
#endif
