using System.Collections.Generic;
using Unity.Mathematics;

namespace Newtonsoft.Json.UnityConverters.Tests.Mathematics
{
    public class Uint2Tests : ValueTypeTester<uint2>
    {
        public static readonly IReadOnlyCollection<(uint2 deserialized, object anonymous)> representations = new (uint2, object)[] {
            (new uint2(), new { x = 0, y = 0 }),
            (new uint2(1, 2), new { x = 1, y = 2 }),
        };
    }

    public class Uint3Tests : ValueTypeTester<uint3>
    {
        public static readonly IReadOnlyCollection<(uint3 deserialized, object anonymous)> representations = new (uint3, object)[] {
            (new uint3(), new { x = 0, y = 0, z = 0 }),
            (new uint3(1, 2, 3), new { x = 1, y = 2, z = 3 }),
        };
    }

    public class Uint4Tests : ValueTypeTester<uint4>
    {
        public static readonly IReadOnlyCollection<(uint4 deserialized, object anonymous)> representations = new (uint4, object)[] {
            (new uint4(), new { x = 0, y = 0, z = 0, w = 0 }),
            (new uint4(1, 2, 3,4), new { x = 1, y = 2, z = 3, w = 4 }),
        };
    }
}
