using System.Collections.Generic;
using Unity.Mathematics;

namespace Newtonsoft.Json.UnityConverters.Tests.Mathematics
{
    #region Vector
    public class Bool2Tests : ValueTypeTester<bool2>
    {
        public static readonly IReadOnlyCollection<(bool2 deserialized, object anonymous)> representations = new (bool2, object)[] {
            (new bool2(), new { x = false, y = false }),
            (new bool2(true, false), new { x = true, y = false }),
        };
    }

    public class Bool3Tests : ValueTypeTester<bool3>
    {
        public static readonly IReadOnlyCollection<(bool3 deserialized, object anonymous)> representations = new (bool3, object)[] {
            (new bool3(), new { x = false, y = false, z = false }),
            (new bool3(true, false, true), new { x = true, y = false, z = true }),
        };
    }

    public class Bool4Tests : ValueTypeTester<bool4>
    {
        public static readonly IReadOnlyCollection<(bool4 deserialized, object anonymous)> representations = new (bool4, object)[] {
            (new bool4(), new { x = false, y = false, z = false, w = false }),
            (new bool4(true, false, true, false), new { x = true, y = false, z = true, w = false }),
        };
    }
    #endregion

    #region Matrix 2xN
    public class Bool2x2Tests : ValueTypeTester<bool2x2>
    {
        public static readonly IReadOnlyCollection<(bool2x2 deserialized, object anonymous)> representations = new (bool2x2, object)[] {
            (new bool2x2(), new {
                c0 = new { x = false, y = false },
                c1 = new { x = false, y = false },
            }),
            (new bool2x2(new bool2(true, false), new bool2(true, false)), new {
                c0 = new { x = true, y = false },
                c1 = new { x = true, y = false },
            }),
        };
    }

    public class Bool2x3Tests : ValueTypeTester<bool2x3>
    {
        public static readonly IReadOnlyCollection<(bool2x3 deserialized, object anonymous)> representations = new (bool2x3, object)[] {
            (new bool2x3(), new {
                c0 = new { x = false, y = false },
                c1 = new { x = false, y = false },
                c2 = new { x = false, y = false },
            }),
            (new bool2x3(
                new bool2(true, false),
                new bool2(true, false),
                new bool2(true, false)
            ), new {
                c0 = new { x = true, y = false },
                c1 = new { x = true, y = false },
                c2 = new { x = true, y = false },
            }),
        };
    }

    public class Bool2x4Tests : ValueTypeTester<bool2x4>
    {
        public static readonly IReadOnlyCollection<(bool2x4 deserialized, object anonymous)> representations = new (bool2x4, object)[] {
            (new bool2x4(), new {
                c0 = new { x = false, y = false },
                c1 = new { x = false, y = false },
                c2 = new { x = false, y = false },
                c3 = new { x = false, y = false },
            }),
            (new bool2x4(
                new bool2(true, false),
                new bool2(true, false),
                new bool2(true, false),
                new bool2(true, false)
            ), new {
                c0 = new { x = true, y = false },
                c1 = new { x = true, y = false },
                c2 = new { x = true, y = false },
                c3 = new { x = true, y = false },
            }),
        };
    }
    #endregion

    #region Matrix 3xN
    public class Bool3x2Tests : ValueTypeTester<bool3x2>
    {
        public static readonly IReadOnlyCollection<(bool3x2 deserialized, object anonymous)> representations = new (bool3x2, object)[] {
            (new bool3x2(), new {
                c0 = new { x = false, y = false, z = false },
                c1 = new { x = false, y = false, z = false },
            }),
            (new bool3x2(new bool3(true, false, true), new bool3(false, true, false)), new {
                c0 = new { x = true, y = false, z = true },
                c1 = new { x = false, y = true, z = false },
            }),
        };
    }

    public class Bool3x3Tests : ValueTypeTester<bool3x3>
    {
        public static readonly IReadOnlyCollection<(bool3x3 deserialized, object anonymous)> representations = new (bool3x3, object)[] {
            (new bool3x3(), new {
                c0 = new { x = false, y = false, z = false },
                c1 = new { x = false, y = false, z = false },
                c2 = new { x = false, y = false, z = false },
            }),
            (new bool3x3(
                new bool3(true, false, true),
                new bool3(false, true, false),
                new bool3(true, false, true)
            ), new {
                c0 = new { x = true, y = false, z = true },
                c1 = new { x = false, y = true, z = false },
                c2 = new { x = true, y = false, z = true },
            }),
        };
    }

    public class Bool3x4Tests : ValueTypeTester<bool3x4>
    {
        public static readonly IReadOnlyCollection<(bool3x4 deserialized, object anonymous)> representations = new (bool3x4, object)[] {
            (new bool3x4(), new {
                c0 = new { x = false, y = false, z = false },
                c1 = new { x = false, y = false, z = false },
                c2 = new { x = false, y = false, z = false },
                c3 = new { x = false, y = false, z = false },
            }),
            (new bool3x4(
                new bool3(true, false, true),
                new bool3(false, true, false),
                new bool3(true, false, true),
                new bool3(false, true, false)
            ), new {
                c0 = new { x = true, y = false, z = true },
                c1 = new { x = false, y = true, z = false },
                c2 = new { x = true, y = false, z = true },
                c3 = new { x = false, y = true, z = false },
            }),
        };
    }
    #endregion

    #region Matrix 4xN
    public class Bool4x2Tests : ValueTypeTester<bool4x2>
    {
        public static readonly IReadOnlyCollection<(bool4x2 deserialized, object anonymous)> representations = new (bool4x2, object)[] {
            (new bool4x2(), new {
                c0 = new { x = false, y = false, z = false, w = false },
                c1 = new { x = false, y = false, z = false, w = false },
            }),
            (new bool4x2(
                new bool4(true, false, true, false),
                new bool4(true, false, true, false)
            ), new {
                c0 = new { x = true, y = false, z = true, w = false },
                c1 = new { x = true, y = false, z = true, w = false },
            }),
        };
    }

    public class Bool4x3Tests : ValueTypeTester<bool4x3>
    {
        public static readonly IReadOnlyCollection<(bool4x3 deserialized, object anonymous)> representations = new (bool4x3, object)[] {
            (new bool4x3(), new {
                c0 = new { x = false, y = false, z = false, w = false },
                c1 = new { x = false, y = false, z = false, w = false },
                c2 = new { x = false, y = false, z = false, w = false },
            }),
            (new bool4x3(
                new bool4(true, false, true, false),
                new bool4(true, false, true, false),
                new bool4(true, false, true, false)
            ), new {
                c0 = new { x = true, y = false, z = true, w = false },
                c1 = new { x = true, y = false, z = true, w = false },
                c2 = new { x = true, y = false, z = true, w = false },
            }),
        };
    }

    public class Bool4x4Tests : ValueTypeTester<bool4x4>
    {
        public static readonly IReadOnlyCollection<(bool4x4 deserialized, object anonymous)> representations = new (bool4x4, object)[] {
            (new bool4x4(), new {
                c0 = new { x = false, y = false, z = false, w = false },
                c1 = new { x = false, y = false, z = false, w = false },
                c2 = new { x = false, y = false, z = false, w = false },
                c3 = new { x = false, y = false, z = false, w = false },
            }),
            (new bool4x4(
                new bool4(true, false, true, false),
                new bool4(true, false, true, false),
                new bool4(true, false, true, false),
                new bool4(true, false, true, false)
            ), new {
                c0 = new { x = true, y = false, z = true, w = false },
                c1 = new { x = true, y = false, z = true, w = false },
                c2 = new { x = true, y = false, z = true, w = false },
                c3 = new { x = true, y = false, z = true, w = false },
            }),
        };
    }
    #endregion
}
