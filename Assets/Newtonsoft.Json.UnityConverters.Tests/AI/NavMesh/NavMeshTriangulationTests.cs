#if HAVE_MODULE_AI || !UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Newtonsoft.Json.UnityConverters.Tests.AI.NavMesh
{
    public class NavMeshTriangulationTests : ValueTypeTester<NavMeshTriangulation>
    {
        public static readonly IReadOnlyCollection<(NavMeshTriangulation deserialized, object anonymous)> representations = new (NavMeshTriangulation, object)[] {
            (new NavMeshTriangulation(), new {
                vertices = null as object[],
                indices = null as int[],
                areas = null as int[],
            }),
            (new NavMeshTriangulation{
                vertices = new [] {
                    new Vector3(1, 2, 3),
                    new Vector3(4, 5, 6),
                },
                indices = new [] { 7, 8 },
                areas = new [] { 9, 10 },
            }, new {
                vertices = new [] {
                    new { x = 1f, y = 2f, z = 3f },
                    new { x = 4f, y = 5f, z = 6f },
                },
                indices = new [] { 7, 8 },
                areas = new [] { 9, 10 },
            }),
            (new NavMeshTriangulation{
                vertices = new [] {
                    new Vector3(1, 2, 3),
                    new Vector3(4, 5, 6),
                },
                areas = new [] { 9, 10 },
            }, new {
                vertices = new [] {
                    new { x = 1f, y = 2f, z = 3f },
                    new { x = 4f, y = 5f, z = 6f },
                },
                indices = null as int[],
                areas = new [] { 9, 10 },
            }),
        };

        protected override bool AreEqual(NavMeshTriangulation a, NavMeshTriangulation b)
        {
            return NullsafeSequenceEquals(a.vertices, b.vertices)
                && NullsafeSequenceEquals(a.indices, b.indices)
                && NullsafeSequenceEquals(a.areas, b.areas);

        }

        private static bool NullsafeSequenceEquals<T>([AllowNull] T[] first, [AllowNull] T[] second)
        {
            if (first == null && second == null)
            {
                return true;
            }
            else if (first == null || second == null)
            {
                return false;
            }
            else
            {
                return first.SequenceEqual(second);
            }
        }
    }
}
#endif
