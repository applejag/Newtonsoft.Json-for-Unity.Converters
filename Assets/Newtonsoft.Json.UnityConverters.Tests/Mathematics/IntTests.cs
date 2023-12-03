using System.Collections.Generic;
using Unity.Mathematics;

namespace Newtonsoft.Json.UnityConverters.Tests.Mathematics
{
    public class Int2Tests : ValueTypeTester<int2>
    {
        public static readonly IReadOnlyCollection<(int2 deserialized, object anonymous)> representations = new (int2, object)[] {
            (new int2(), new { x = 0, y = 0 }),
            (new int2(1, 2), new { x = 1, y = 2 }),
        };
    }

    public class Int3Tests : ValueTypeTester<int3>
    {
        public static readonly IReadOnlyCollection<(int3 deserialized, object anonymous)> representations = new (int3, object)[] {
            (new int3(), new { x = 0, y = 0, z = 0 }),
            (new int3(1, 2, 3), new { x = 1, y = 2, z = 3 }),
        };
    }

    public class Int4Tests : ValueTypeTester<int4>
    {
        public static readonly IReadOnlyCollection<(int4 deserialized, object anonymous)> representations = new (int4, object)[] {
            (new int4(), new { x = 0, y = 0, z = 0, w = 0 }),
            (new int4(1, 2, 3,4), new { x = 1, y = 2, z = 3, w = 4 }),
        };
    }
}
