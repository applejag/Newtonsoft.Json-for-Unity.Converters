using System.Collections.Generic;
using Unity.Mathematics;

namespace Newtonsoft.Json.UnityConverters.Tests.Mathematics
{
    #region Vector
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
    #endregion

    #region Matrix 2xN
    public class Uint2x2Tests : ValueTypeTester<uint2x2>
    {
        public static readonly IReadOnlyCollection<(uint2x2 deserialized, object anonymous)> representations = new (uint2x2, object)[] {
            (new uint2x2(), new {
                c0 = new { x = 0, y = 0 },
                c1 = new { x = 0, y = 0 },
            }),
            (new uint2x2(new uint2(1, 2), new uint2(3, 4)), new {
                c0 = new { x = 1, y = 2 },
                c1 = new { x = 3, y = 4 },
            }),
        };
    }

    public class Uint2x3Tests : ValueTypeTester<uint2x3>
    {
        public static readonly IReadOnlyCollection<(uint2x3 deserialized, object anonymous)> representations = new (uint2x3, object)[] {
            (new uint2x3(), new {
                c0 = new { x = 0, y = 0 },
                c1 = new { x = 0, y = 0 },
                c2 = new { x = 0, y = 0 },
            }),
            (new uint2x3(
                new uint2(1, 2),
                new uint2(3, 4),
                new uint2(5, 6)
            ), new {
                c0 = new { x = 1, y = 2 },
                c1 = new { x = 3, y = 4 },
                c2 = new { x = 5, y = 6 },
            }),
        };
    }

    public class Uint2x4Tests : ValueTypeTester<uint2x4>
    {
        public static readonly IReadOnlyCollection<(uint2x4 deserialized, object anonymous)> representations = new (uint2x4, object)[] {
            (new uint2x4(), new {
                c0 = new { x = 0, y = 0 },
                c1 = new { x = 0, y = 0 },
                c2 = new { x = 0, y = 0 },
                c3 = new { x = 0, y = 0 },
            }),
            (new uint2x4(
                new uint2(1, 2),
                new uint2(3, 4),
                new uint2(5, 6),
                new uint2(7, 8)
            ), new {
                c0 = new { x = 1, y = 2 },
                c1 = new { x = 3, y = 4 },
                c2 = new { x = 5, y = 6 },
                c3 = new { x = 7, y = 8 },
            }),
        };
    }
    #endregion

    #region Matrix 3xN
    public class Uint3x2Tests : ValueTypeTester<uint3x2>
    {
        public static readonly IReadOnlyCollection<(uint3x2 deserialized, object anonymous)> representations = new (uint3x2, object)[] {
            (new uint3x2(), new {
                c0 = new { x = 0, y = 0, z = 0 },
                c1 = new { x = 0, y = 0, z = 0 },
            }),
            (new uint3x2(new uint3(1, 2, 3), new uint3(4, 5, 6)), new {
                c0 = new { x = 1, y = 2, z = 3 },
                c1 = new { x = 4, y = 5, z = 6 },
            }),
        };
    }

    public class Uint3x3Tests : ValueTypeTester<uint3x3>
    {
        public static readonly IReadOnlyCollection<(uint3x3 deserialized, object anonymous)> representations = new (uint3x3, object)[] {
            (new uint3x3(), new {
                c0 = new { x = 0, y = 0, z = 0 },
                c1 = new { x = 0, y = 0, z = 0 },
                c2 = new { x = 0, y = 0, z = 0 },
            }),
            (new uint3x3(
                new uint3(1, 2, 3),
                new uint3(4, 5, 6),
                new uint3(7, 8, 9)
            ), new {
                c0 = new { x = 1, y = 2, z = 3 },
                c1 = new { x = 4, y = 5, z = 6 },
                c2 = new { x = 7, y = 8, z = 9 },
            }),
        };
    }

    public class Uint3x4Tests : ValueTypeTester<uint3x4>
    {
        public static readonly IReadOnlyCollection<(uint3x4 deserialized, object anonymous)> representations = new (uint3x4, object)[] {
            (new uint3x4(), new {
                c0 = new { x = 0, y = 0, z = 0 },
                c1 = new { x = 0, y = 0, z = 0 },
                c2 = new { x = 0, y = 0, z = 0 },
                c3 = new { x = 0, y = 0, z = 0 },
            }),
            (new uint3x4(
                new uint3(1, 2, 3),
                new uint3(4, 5, 6),
                new uint3(7, 8, 9),
                new uint3(10, 11, 12)
            ), new {
                c0 = new { x = 1, y = 2, z = 3 },
                c1 = new { x = 4, y = 5, z = 6 },
                c2 = new { x = 7, y = 8, z = 9 },
                c3 = new { x = 10, y = 11, z = 12 },
            }),
        };
    }
    #endregion

    #region Matrix 4xN
    public class Uint4x2Tests : ValueTypeTester<uint4x2>
    {
        public static readonly IReadOnlyCollection<(uint4x2 deserialized, object anonymous)> representations = new (uint4x2, object)[] {
            (new uint4x2(), new {
                c0 = new { x = 0, y = 0, z = 0, w = 0 },
                c1 = new { x = 0, y = 0, z = 0, w = 0 },
            }),
            (new uint4x2(
                new uint4(1, 2, 3, 4),
                new uint4(5, 6, 7, 8)
            ), new {
                c0 = new { x = 1, y = 2, z = 3, w = 4 },
                c1 = new { x = 5, y = 6, z = 7, w = 8 },
            }),
        };
    }

    public class Uint4x3Tests : ValueTypeTester<uint4x3>
    {
        public static readonly IReadOnlyCollection<(uint4x3 deserialized, object anonymous)> representations = new (uint4x3, object)[] {
            (new uint4x3(), new {
                c0 = new { x = 0, y = 0, z = 0, w = 0 },
                c1 = new { x = 0, y = 0, z = 0, w = 0 },
                c2 = new { x = 0, y = 0, z = 0, w = 0 },
            }),
            (new uint4x3(
                new uint4(1, 2, 3, 4),
                new uint4(5, 6, 7, 8),
                new uint4(9, 10, 11, 12)
            ), new {
                c0 = new { x = 1, y = 2, z = 3, w = 4 },
                c1 = new { x = 5, y = 6, z = 7, w = 8 },
                c2 = new { x = 9, y = 10, z = 11, w = 12 },
            }),
        };
    }

    public class Uint4x4Tests : ValueTypeTester<uint4x4>
    {
        public static readonly IReadOnlyCollection<(uint4x4 deserialized, object anonymous)> representations = new (uint4x4, object)[] {
            (new uint4x4(), new {
                c0 = new { x = 0, y = 0, z = 0, w = 0 },
                c1 = new { x = 0, y = 0, z = 0, w = 0 },
                c2 = new { x = 0, y = 0, z = 0, w = 0 },
                c3 = new { x = 0, y = 0, z = 0, w = 0 },
            }),
            (new uint4x4(
                new uint4(1, 2, 3, 4),
                new uint4(5, 6, 7, 8),
                new uint4(9, 10, 11, 12),
                new uint4(13, 14, 15, 16)
            ), new {
                c0 = new { x = 1, y = 2, z = 3, w = 4 },
                c1 = new { x = 5, y = 6, z = 7, w = 8 },
                c2 = new { x = 9, y = 10, z = 11, w = 12 },
                c3 = new { x = 13, y = 14, z = 15, w = 16 },
            }),
        };
    }
    #endregion
}
