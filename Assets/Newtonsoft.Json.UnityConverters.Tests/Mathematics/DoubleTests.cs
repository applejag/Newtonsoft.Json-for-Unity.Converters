using System.Collections.Generic;
using Unity.Mathematics;

namespace Newtonsoft.Json.UnityConverters.Tests.Mathematics
{
    #region Vector
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
    #endregion

    #region Matrix 2xN
    public class Double2x2Tests : ValueTypeTester<double2x2>
    {
        public static readonly IReadOnlyCollection<(double2x2 deserialized, object anonymous)> representations = new (double2x2, object)[] {
            (new double2x2(), new {
                c0 = new { x = 0f, y = 0f },
                c1 = new { x = 0f, y = 0f },
            }),
            (new double2x2(new double2(1, 2), new double2(3, 4)), new {
                c0 = new { x = 1f, y = 2f },
                c1 = new { x = 3f, y = 4f },
            }),
        };
    }

    public class Double2x3Tests : ValueTypeTester<double2x3>
    {
        public static readonly IReadOnlyCollection<(double2x3 deserialized, object anonymous)> representations = new (double2x3, object)[] {
            (new double2x3(), new {
                c0 = new { x = 0f, y = 0f },
                c1 = new { x = 0f, y = 0f },
                c2 = new { x = 0f, y = 0f },
            }),
            (new double2x3(
                new double2(1, 2),
                new double2(3, 4),
                new double2(5, 6)
            ), new {
                c0 = new { x = 1f, y = 2f },
                c1 = new { x = 3f, y = 4f },
                c2 = new { x = 5f, y = 6f },
            }),
        };
    }

    public class Double2x4Tests : ValueTypeTester<double2x4>
    {
        public static readonly IReadOnlyCollection<(double2x4 deserialized, object anonymous)> representations = new (double2x4, object)[] {
            (new double2x4(), new {
                c0 = new { x = 0f, y = 0f },
                c1 = new { x = 0f, y = 0f },
                c2 = new { x = 0f, y = 0f },
                c3 = new { x = 0f, y = 0f },
            }),
            (new double2x4(
                new double2(1, 2),
                new double2(3, 4),
                new double2(5, 6),
                new double2(7, 8)
            ), new {
                c0 = new { x = 1f, y = 2f },
                c1 = new { x = 3f, y = 4f },
                c2 = new { x = 5f, y = 6f },
                c3 = new { x = 7f, y = 8f },
            }),
        };
    }
    #endregion

    #region Matrix 3xN
    public class Double3x2Tests : ValueTypeTester<double3x2>
    {
        public static readonly IReadOnlyCollection<(double3x2 deserialized, object anonymous)> representations = new (double3x2, object)[] {
            (new double3x2(), new {
                c0 = new { x = 0f, y = 0f, z = 0f },
                c1 = new { x = 0f, y = 0f, z = 0f },
            }),
            (new double3x2(new double3(1, 2, 3), new double3(4, 5, 6)), new {
                c0 = new { x = 1f, y = 2f, z = 3f },
                c1 = new { x = 4f, y = 5f, z = 6f },
            }),
        };
    }

    public class Double3x3Tests : ValueTypeTester<double3x3>
    {
        public static readonly IReadOnlyCollection<(double3x3 deserialized, object anonymous)> representations = new (double3x3, object)[] {
            (new double3x3(), new {
                c0 = new { x = 0f, y = 0f, z = 0f },
                c1 = new { x = 0f, y = 0f, z = 0f },
                c2 = new { x = 0f, y = 0f, z = 0f },
            }),
            (new double3x3(
                new double3(1, 2, 3),
                new double3(4, 5, 6),
                new double3(7, 8, 9)
            ), new {
                c0 = new { x = 1f, y = 2f, z = 3f },
                c1 = new { x = 4f, y = 5f, z = 6f },
                c2 = new { x = 7f, y = 8f, z = 9f },
            }),
        };
    }

    public class Double3x4Tests : ValueTypeTester<double3x4>
    {
        public static readonly IReadOnlyCollection<(double3x4 deserialized, object anonymous)> representations = new (double3x4, object)[] {
            (new double3x4(), new {
                c0 = new { x = 0f, y = 0f, z = 0f },
                c1 = new { x = 0f, y = 0f, z = 0f },
                c2 = new { x = 0f, y = 0f, z = 0f },
                c3 = new { x = 0f, y = 0f, z = 0f },
            }),
            (new double3x4(
                new double3(1, 2, 3),
                new double3(4, 5, 6),
                new double3(7, 8, 9),
                new double3(10, 11, 12)
            ), new {
                c0 = new { x = 1f, y = 2f, z = 3f },
                c1 = new { x = 4f, y = 5f, z = 6f },
                c2 = new { x = 7f, y = 8f, z = 9f },
                c3 = new { x = 10f, y = 11f, z = 12f },
            }),
        };
    }
    #endregion

    #region Matrix 4xN
    public class Double4x2Tests : ValueTypeTester<double4x2>
    {
        public static readonly IReadOnlyCollection<(double4x2 deserialized, object anonymous)> representations = new (double4x2, object)[] {
            (new double4x2(), new {
                c0 = new { x = 0f, y = 0f, z = 0f, w = 0f },
                c1 = new { x = 0f, y = 0f, z = 0f, w = 0f },
            }),
            (new double4x2(
                new double4(1, 2, 3, 4),
                new double4(5, 6, 7, 8)
            ), new {
                c0 = new { x = 1f, y = 2f, z = 3f, w = 4f },
                c1 = new { x = 5f, y = 6f, z = 7f, w = 8f },
            }),
        };
    }

    public class Double4x3Tests : ValueTypeTester<double4x3>
    {
        public static readonly IReadOnlyCollection<(double4x3 deserialized, object anonymous)> representations = new (double4x3, object)[] {
            (new double4x3(), new {
                c0 = new { x = 0f, y = 0f, z = 0f, w = 0f },
                c1 = new { x = 0f, y = 0f, z = 0f, w = 0f },
                c2 = new { x = 0f, y = 0f, z = 0f, w = 0f },
            }),
            (new double4x3(
                new double4(1, 2, 3, 4),
                new double4(5, 6, 7, 8),
                new double4(9, 10, 11, 12)
            ), new {
                c0 = new { x = 1f, y = 2f, z = 3f, w = 4f },
                c1 = new { x = 5f, y = 6f, z = 7f, w = 8f },
                c2 = new { x = 9f, y = 10f, z = 11f, w = 12f },
            }),
        };
    }

    public class Double4x4Tests : ValueTypeTester<double4x4>
    {
        public static readonly IReadOnlyCollection<(double4x4 deserialized, object anonymous)> representations = new (double4x4, object)[] {
            (new double4x4(), new {
                c0 = new { x = 0f, y = 0f, z = 0f, w = 0f },
                c1 = new { x = 0f, y = 0f, z = 0f, w = 0f },
                c2 = new { x = 0f, y = 0f, z = 0f, w = 0f },
                c3 = new { x = 0f, y = 0f, z = 0f, w = 0f },
            }),
            (new double4x4(
                new double4(1, 2, 3, 4),
                new double4(5, 6, 7, 8),
                new double4(9, 10, 11, 12),
                new double4(13, 14, 15, 16)
            ), new {
                c0 = new { x = 1f, y = 2f, z = 3f, w = 4f },
                c1 = new { x = 5f, y = 6f, z = 7f, w = 8f },
                c2 = new { x = 9f, y = 10f, z = 11f, w = 12f },
                c3 = new { x = 13f, y = 14f, z = 15f, w = 16f },
            }),
        };
    }
    #endregion
}
