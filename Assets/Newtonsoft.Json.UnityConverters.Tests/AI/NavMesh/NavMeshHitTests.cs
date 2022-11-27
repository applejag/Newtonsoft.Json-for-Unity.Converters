#if HAVE_MODULE_AI || !UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Newtonsoft.Json.UnityConverters.Tests.AI.NavMesh
{
    public class NavMeshHitTests : ValueTypeTester<NavMeshHit>
    {
        public static readonly IReadOnlyCollection<(NavMeshHit deserialized, object anonymous)> representations = new (NavMeshHit, object)[] {
            (new NavMeshHit(), new {
                position = new { x = 0f, y = 0f, z = 0f },
                normal = new { x = 0f, y = 0f, z = 0f },
                distance = 0f,
                mask = 0,
                hit = false
            }),
            (new NavMeshHit{
                position = new Vector3(1, 2, 3),
                normal = new Vector3(1, 0, 0),
                distance = 4,
                mask = 5,
                hit = true,
            }, new {
                position = new { x = 1f, y = 2f, z = 3f },
                normal = new { x = 1f, y = 0f, z = 0f },
                distance = 4f,
                mask = 5,
                hit = true,
            }),
        };
    }
}
#endif
