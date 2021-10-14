#if HAVE_MODULE_AI || !UNITY_2019_1_OR_NEWER
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using UnityEngine.AI;

namespace Newtonsoft.Json.UnityConverters.Tests.AI.NavMesh
{
    public class NavMeshQueryFilterTests : ValueTypeTester<NavMeshQueryFilter>
    {
        [MaybeNull]
        private static readonly PropertyInfo _costsProperty = typeof(NavMeshQueryFilter).GetProperty("costs", BindingFlags.NonPublic | BindingFlags.Instance);

        public static readonly IReadOnlyCollection<(NavMeshQueryFilter deserialized, object anonymous)> representations = new (NavMeshQueryFilter, object)[] {
            (new NavMeshQueryFilter(), new {
                costs = new [] {
                    // Defaults to 1
                    1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f,
                    1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f,
                    1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f,
                    1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f,
                },
                areaMask = 0,
                agentTypeId = 0,
            }),
            (CreateInstance(
                costs: new [] {
                    1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f,
                    9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                    17f, 18f, 19f, 20f, 21f, 22f, 23f, 24f,
                    25f, 26f, 27f, 28f, 29f, 30f, 31f, 32f,
                },
                areaMask: 33,
                agentTypeId: 34
            ), new {
                costs = new [] {
                    1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f,
                    9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                    17f, 18f, 19f, 20f, 21f, 22f, 23f, 24f,
                    25f, 26f, 27f, 28f, 29f, 30f, 31f, 32f,
                },
                areaMask = 33,
                agentTypeId = 34,
            }),
        };

        private static NavMeshQueryFilter CreateInstance(float[] costs, int areaMask, int agentTypeId)
        {
            if (_costsProperty == null)
            {
                throw new InvalidOperationException("Was unable to find 'costs' property from the UnityEngine.AI.NavMeshQueryFilter type.");
            }

            var instance = new NavMeshQueryFilter {
                areaMask = areaMask,
                agentTypeID = agentTypeId,
            };

            for (int i = 0; i < costs.Length; i++)
            {
                instance.SetAreaCost(i, costs[i]);
            }

            return instance;
        }

        protected override bool AreEqual(NavMeshQueryFilter a, NavMeshQueryFilter b)
        {
            if (a.agentTypeID != b.agentTypeID
                || a.areaMask != b.areaMask)
            {
                return false;
            }

            for (int i = 0; i < 32; i++)
            {
                if (a.GetAreaCost(i) != b.GetAreaCost(i))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
#endif
