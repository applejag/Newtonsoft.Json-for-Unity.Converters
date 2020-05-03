using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Geometry
{
    public class PlaneTests : ValueTypeTester<Plane>
    {
        public static readonly IReadOnlyCollection<(Plane deserialized, object anonymous)> representations = new (Plane, object)[] {
            (new Plane(), new { normal = new { x = 0f, y = 0f, z = 0f }, distance = 0f }),
            (new Plane(new Vector3(1, 0, 0), 4), new { normal = new { x = 1f, y = 0f, z = 0f }, distance = 4f }),
            (new Plane(new Vector3(0, 1, 0), 4), new { normal = new { x = 0f, y = 1f, z = 0f }, distance = 4f }),
            (new Plane(new Vector3(0, 0, 1), 4), new { normal = new { x = 0f, y = 0f, z = 1f }, distance = 4f }),
        };
    }
}
