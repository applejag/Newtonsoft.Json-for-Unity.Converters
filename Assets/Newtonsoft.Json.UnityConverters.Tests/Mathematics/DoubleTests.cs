using System.Collections.Generic;
using Unity.Mathematics;

namespace Newtonsoft.Json.UnityConverters.Tests.Mathematics
{
    public class Double2Tests : ValueTypeTester<double2>
    {
        public static readonly IReadOnlyCollection<(double2 deserialized, object anonymous)> representations = new (double2, object)[] {
            (new double2(), new { x = 0f, y = 0f }),
            (new double2(1, 2), new { x = 1f, y = 2f }),
        };
    }

    public class Double3Tests : ValueTypeTester<double3>
    {
        public static readonly IReadOnlyCollection<(double3 deserialized, object anonymous)> representations = new (double3, object)[] {
            (new double3(), new { x = 0f, y = 0f, z = 0f }),
            (new double3(1, 2, 3), new { x = 1f, y = 2f, z = 3f }),
        };
    }

    public class Double4Tests : ValueTypeTester<double4>
    {
        public static readonly IReadOnlyCollection<(double4 deserialized, object anonymous)> representations = new (double4, object)[] {
            (new double4(), new { x = 0f, y = 0f, z = 0f, w = 0f }),
            (new double4(1, 2, 3, 4), new { x = 1f, y = 2f, z = 3f, w = 4f }),
        };
    }
}
