#if HAVE_MODULE_AI || !UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Newtonsoft.Json.UnityConverters.Tests.AI.NavMesh
{
    public class NavMeshLinkDataTests : ValueTypeTester<NavMeshLinkData>
    {
        public static readonly IReadOnlyCollection<(NavMeshLinkData deserialized, object anonymous)> representations = new (NavMeshLinkData, object)[] {
            (new NavMeshLinkData(), new {
                startPosition = new { x = 0f, y = 0f, z = 0f },
                endPosition = new { x = 0f, y = 0f, z = 0f },
                costModifier = 0f,
                bidirectional = false,
                width = 0f,
                area = 0,
                agentTypeID = 0,
            }),
            (new NavMeshLinkData{
                startPosition = new Vector3(1, 2, 3),
                endPosition = new Vector3(4, 5, 6),
                costModifier = 7,
                bidirectional = true,
                width = 8,
                area = 9,
                agentTypeID = 10,
            }, new {
                startPosition = new { x = 1f, y = 2f, z = 3f },
                endPosition = new { x = 4f, y = 5f, z = 6f },
                costModifier = 7f,
                bidirectional = true,
                width = 8f,
                area = 9,
                agentTypeID = 10,
            }),
        };
    }
}
#endif
