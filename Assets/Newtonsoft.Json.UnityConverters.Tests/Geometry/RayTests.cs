using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Geometry
{
    public class RayTests : TypeTester<Ray>
    {
        public static readonly IReadOnlyCollection<(Ray deserialized, object anonymous)> representations = new (Ray, object)[] {
            (new Ray(), new { origin = new { x=0f, y=0f, z=0f }, direction = new { x=0f, y=0f, z=0f } }),
            (new Ray(new Vector3(1, 2, 3), new Vector3(1, 0, 0)), new { origin = new { x=1f, y=2f, z=3f }, direction = new { x=1f, y=0f, z=0f } }),
        };
    }

    public class Ray2DTests : TypeTester<Ray2D>
    {
        public static readonly IReadOnlyCollection<(Ray2D deserialized, object anonymous)> representations = new (Ray2D, object)[] {
            (new Ray2D(), new { origin = new { x=0f, y=0f }, direction = new { x=0f, y=0f } }),
            (new Ray2D(new Vector2(1, 2), new Vector2(1, 0)), new { origin = new { x=1f, y=2f }, direction = new { x=1f, y=0f } }),
        };
    }
}
