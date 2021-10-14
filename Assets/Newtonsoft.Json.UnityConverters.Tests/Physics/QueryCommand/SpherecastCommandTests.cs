#if HAVE_MODULE_PHYSICS || !UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Physics.QueryCommand
{
    public class SpherecastCommandTests : ValueTypeTester<SpherecastCommand>
    {
        public static readonly IReadOnlyCollection<(SpherecastCommand deserialized, object anonymous)> representations = new (SpherecastCommand, object)[] {
            (new SpherecastCommand(), new {
                origin = new { x = 0f, y = 0f, z = 0f },
                radius = 0f,
                direction = new { x = 0f, y = 0f, z = 0f },
                distance = 0f,
                layerMask = 0,
            }),
            (new SpherecastCommand {
                origin = new Vector3(1f, 2f, 3f),
                radius = 4,
                direction = new Vector3(5f, 6f, 7f),
                distance = 7f,
                layerMask = 8,
            }, new {
                origin = new { x = 1f, y = 2f, z = 3f },
                radius = 4f,
                direction = new { x = 5f, y = 6f, z = 7f },
                distance = 7f,
                layerMask = 8,
            }),
        };
    }
}
#endif
