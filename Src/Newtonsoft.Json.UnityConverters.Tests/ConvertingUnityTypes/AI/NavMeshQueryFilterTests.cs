using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.AI;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes.AI
{
    public class NavMeshQueryFilterTests : ValueTypeTester<NavMeshQueryFilter>
    {
        private static readonly PropertyInfo _costsProperty = typeof(NavMeshQueryFilter).GetProperty("costs", BindingFlags.NonPublic | BindingFlags.Instance);

        public static readonly IReadOnlyCollection<(NavMeshQueryFilter deserialized, object anonymous)> representations = new (NavMeshQueryFilter, object)[] {
            (new NavMeshQueryFilter(), new {
                costs = new float[] {
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
                costs: new float [] {
                    1, 2, 3, 4, 5, 6, 7, 8,
                    9, 10, 11, 12, 13, 14, 15, 16,
                    17, 18, 19, 20, 21, 22, 23, 24,
                    25, 26, 27, 28, 29, 30, 31, 32,
                },
                areaMask: 33,
                agentTypeId: 34
            ), new {
                costs = new float[] {
                    1, 2, 3, 4, 5, 6, 7, 8,
                    9, 10, 11, 12, 13, 14, 15, 16,
                    17, 18, 19, 20, 21, 22, 23, 24,
                    25, 26, 27, 28, 29, 30, 31, 32,
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
