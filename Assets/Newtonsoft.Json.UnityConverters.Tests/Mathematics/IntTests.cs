using System.Collections.Generic;
using Unity.Mathematics;

namespace Newtonsoft.Json.UnityConverters.Tests.Mathematics
{
    #region Vector
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
    #endregion

    #region Matrix 2xN
    public class Int2x2Tests : ValueTypeTester<int2x2>
    {
        public static readonly IReadOnlyCollection<(int2x2 deserialized, object anonymous)> representations = new (int2x2, object)[] {
            (new int2x2(), new {
                c0 = new { x = 0, y = 0 },
                c1 = new { x = 0, y = 0 },
            }),
            (new int2x2(new int2(1, 2), new int2(3, 4)), new {
                c0 = new { x = 1, y = 2 },
                c1 = new { x = 3, y = 4 },
            }),
        };
    }

    public class Int2x3Tests : ValueTypeTester<int2x3>
    {
        public static readonly IReadOnlyCollection<(int2x3 deserialized, object anonymous)> representations = new (int2x3, object)[] {
            (new int2x3(), new {
                c0 = new { x = 0, y = 0 },
                c1 = new { x = 0, y = 0 },
                c2 = new { x = 0, y = 0 },
            }),
            (new int2x3(
                new int2(1, 2),
                new int2(3, 4),
                new int2(5, 6)
            ), new {
                c0 = new { x = 1, y = 2 },
                c1 = new { x = 3, y = 4 },
                c2 = new { x = 5, y = 6 },
            }),
        };
    }

    public class Int2x4Tests : ValueTypeTester<int2x4>
    {
        public static readonly IReadOnlyCollection<(int2x4 deserialized, object anonymous)> representations = new (int2x4, object)[] {
            (new int2x4(), new {
                c0 = new { x = 0, y = 0 },
                c1 = new { x = 0, y = 0 },
                c2 = new { x = 0, y = 0 },
                c3 = new { x = 0, y = 0 },
            }),
            (new int2x4(
                new int2(1, 2),
                new int2(3, 4),
                new int2(5, 6),
                new int2(7, 8)
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
    public class Int3x2Tests : ValueTypeTester<int3x2>
    {
        public static readonly IReadOnlyCollection<(int3x2 deserialized, object anonymous)> representations = new (int3x2, object)[] {
            (new int3x2(), new {
                c0 = new { x = 0, y = 0, z = 0 },
                c1 = new { x = 0, y = 0, z = 0 },
            }),
            (new int3x2(new int3(1, 2, 3), new int3(4, 5, 6)), new {
                c0 = new { x = 1, y = 2, z = 3 },
                c1 = new { x = 4, y = 5, z = 6 },
            }),
        };
    }

    public class Int3x3Tests : ValueTypeTester<int3x3>
    {
        public static readonly IReadOnlyCollection<(int3x3 deserialized, object anonymous)> representations = new (int3x3, object)[] {
            (new int3x3(), new {
                c0 = new { x = 0, y = 0, z = 0 },
                c1 = new { x = 0, y = 0, z = 0 },
                c2 = new { x = 0, y = 0, z = 0 },
            }),
            (new int3x3(
                new int3(1, 2, 3),
                new int3(4, 5, 6),
                new int3(7, 8, 9)
            ), new {
                c0 = new { x = 1, y = 2, z = 3 },
                c1 = new { x = 4, y = 5, z = 6 },
                c2 = new { x = 7, y = 8, z = 9 },
            }),
        };
    }

    public class Int3x4Tests : ValueTypeTester<int3x4>
    {
        public static readonly IReadOnlyCollection<(int3x4 deserialized, object anonymous)> representations = new (int3x4, object)[] {
            (new int3x4(), new {
                c0 = new { x = 0, y = 0, z = 0 },
                c1 = new { x = 0, y = 0, z = 0 },
                c2 = new { x = 0, y = 0, z = 0 },
                c3 = new { x = 0, y = 0, z = 0 },
            }),
            (new int3x4(
                new int3(1, 2, 3),
                new int3(4, 5, 6),
                new int3(7, 8, 9),
                new int3(10, 11, 12)
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
    public class Int4x2Tests : ValueTypeTester<int4x2>
    {
        public static readonly IReadOnlyCollection<(int4x2 deserialized, object anonymous)> representations = new (int4x2, object)[] {
            (new int4x2(), new {
                c0 = new { x = 0, y = 0, z = 0, w = 0 },
                c1 = new { x = 0, y = 0, z = 0, w = 0 },
            }),
            (new int4x2(
                new int4(1, 2, 3, 4),
                new int4(5, 6, 7, 8)
            ), new {
                c0 = new { x = 1, y = 2, z = 3, w = 4 },
                c1 = new { x = 5, y = 6, z = 7, w = 8 },
            }),
        };
    }

    public class Int4x3Tests : ValueTypeTester<int4x3>
    {
        public static readonly IReadOnlyCollection<(int4x3 deserialized, object anonymous)> representations = new (int4x3, object)[] {
            (new int4x3(), new {
                c0 = new { x = 0, y = 0, z = 0, w = 0 },
                c1 = new { x = 0, y = 0, z = 0, w = 0 },
                c2 = new { x = 0, y = 0, z = 0, w = 0 },
            }),
            (new int4x3(
                new int4(1, 2, 3, 4),
                new int4(5, 6, 7, 8),
                new int4(9, 10, 11, 12)
            ), new {
                c0 = new { x = 1, y = 2, z = 3, w = 4 },
                c1 = new { x = 5, y = 6, z = 7, w = 8 },
                c2 = new { x = 9, y = 10, z = 11, w = 12 },
            }),
        };
    }

    public class Int4x4Tests : ValueTypeTester<int4x4>
    {
        public static readonly IReadOnlyCollection<(int4x4 deserialized, object anonymous)> representations = new (int4x4, object)[] {
            (new int4x4(), new {
                c0 = new { x = 0, y = 0, z = 0, w = 0 },
                c1 = new { x = 0, y = 0, z = 0, w = 0 },
                c2 = new { x = 0, y = 0, z = 0, w = 0 },
                c3 = new { x = 0, y = 0, z = 0, w = 0 },
            }),
            (new int4x4(
                new int4(1, 2, 3, 4),
                new int4(5, 6, 7, 8),
                new int4(9, 10, 11, 12),
                new int4(13, 14, 15, 16)
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
