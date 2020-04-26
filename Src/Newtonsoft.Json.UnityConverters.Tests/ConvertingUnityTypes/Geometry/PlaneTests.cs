using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes.Geometry
{
    public class PlaneTests : ValueTypeTester<Plane>
    {
        public static readonly IReadOnlyCollection<(Plane deserialized, object anonymous)> representations = new (Plane, object)[] {
            (new Plane(new Vector3(1, 0, 0), 4), new { normal = new { x = 1f, y = 0f, z = 0f }, distance = 4f }),
            (new Plane(new Vector3(0, 1, 0), 4), new { normal = new { x = 0f, y = 1f, z = 0f }, distance = 4f }),
            (new Plane(new Vector3(0, 0, 1), 4), new { normal = new { x = 0f, y = 0f, z = 1f }, distance = 4f }),
        };
    }

    public class FrustumPlaneTests : ValueTypeTester<FrustumPlanes>
    {
        public static readonly IReadOnlyCollection<(FrustumPlanes deserialized, object anonymous)> representations = new (FrustumPlanes, object)[] {
            (new FrustumPlanes {

                left = 1,
                right = 2,
                bottom = 3,
                top = 4,
                zNear = 5,
                zFar = 6,

            }, new {

                left = 1f,
                right = 2f,
                bottom = 3f,
                top = 4f,
                zNear = 5f,
                zFar = 6f,

            })
        };
    }
}
