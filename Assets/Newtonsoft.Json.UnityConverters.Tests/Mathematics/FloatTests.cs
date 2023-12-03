using System.Collections.Generic;
using Unity.Mathematics;

namespace Newtonsoft.Json.UnityConverters.Tests.Mathematics
{
    #region Vector
    public class Float2Tests : ValueTypeTester<float2>
    {
        public static readonly IReadOnlyCollection<(float2 deserialized, object anonymous)> representations = new (float2, object)[] {
            (new float2(), new { x = 0f, y = 0f }),
            (new float2(1, 2), new { x = 1f, y = 2f }),
        };
    }

    public class Float3Tests : ValueTypeTester<float3>
    {
        public static readonly IReadOnlyCollection<(float3 deserialized, object anonymous)> representations = new (float3, object)[] {
            (new float3(), new { x = 0f, y = 0f, z = 0f }),
            (new float3(1, 2, 3), new { x = 1f, y = 2f, z = 3f }),
        };
    }

    public class Float4Tests : ValueTypeTester<float4>
    {
        public static readonly IReadOnlyCollection<(float4 deserialized, object anonymous)> representations = new (float4, object)[] {
            (new float4(), new { x = 0f, y = 0f, z = 0f, w = 0f }),
            (new float4(1, 2, 3, 4), new { x = 1f, y = 2f, z = 3f, w = 4f }),
        };
    }
    #endregion

    #region Matrix 2xN
    public class Float2x2Tests : ValueTypeTester<float2x2>
    {
        public static readonly IReadOnlyCollection<(float2x2 deserialized, object anonymous)> representations = new (float2x2, object)[] {
            (new float2x2(), new {
                c0 = new { x = 0f, y = 0f },
                c1 = new { x = 0f, y = 0f },
            }),
            (new float2x2(new float2(1, 2), new float2(3, 4)), new {
                c0 = new { x = 1f, y = 2f },
                c1 = new { x = 3f, y = 4f },
            }),
        };
    }

    public class Float2x3Tests : ValueTypeTester<float2x3>
    {
        public static readonly IReadOnlyCollection<(float2x3 deserialized, object anonymous)> representations = new (float2x3, object)[] {
            (new float2x3(), new {
                c0 = new { x = 0f, y = 0f },
                c1 = new { x = 0f, y = 0f },
                c2 = new { x = 0f, y = 0f },
            }),
            (new float2x3(
                new float2(1, 2),
                new float2(3, 4),
                new float2(5, 6)
            ), new {
                c0 = new { x = 1f, y = 2f },
                c1 = new { x = 3f, y = 4f },
                c2 = new { x = 5f, y = 6f },
            }),
        };
    }

    public class Float2x4Tests : ValueTypeTester<float2x4>
    {
        public static readonly IReadOnlyCollection<(float2x4 deserialized, object anonymous)> representations = new (float2x4, object)[] {
            (new float2x4(), new {
                c0 = new { x = 0f, y = 0f },
                c1 = new { x = 0f, y = 0f },
                c2 = new { x = 0f, y = 0f },
                c3 = new { x = 0f, y = 0f },
            }),
            (new float2x4(
                new float2(1, 2),
                new float2(3, 4),
                new float2(5, 6),
                new float2(7, 8)
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
    public class Float3x2Tests : ValueTypeTester<float3x2>
    {
        public static readonly IReadOnlyCollection<(float3x2 deserialized, object anonymous)> representations = new (float3x2, object)[] {
            (new float3x2(), new {
                c0 = new { x = 0f, y = 0f, z = 0f },
                c1 = new { x = 0f, y = 0f, z = 0f },
            }),
            (new float3x2(new float3(1, 2, 3), new float3(4, 5, 6)), new {
                c0 = new { x = 1f, y = 2f, z = 3f },
                c1 = new { x = 4f, y = 5f, z = 6f },
            }),
        };
    }

    public class Float3x3Tests : ValueTypeTester<float3x3>
    {
        public static readonly IReadOnlyCollection<(float3x3 deserialized, object anonymous)> representations = new (float3x3, object)[] {
            (new float3x3(), new {
                c0 = new { x = 0f, y = 0f, z = 0f },
                c1 = new { x = 0f, y = 0f, z = 0f },
                c2 = new { x = 0f, y = 0f, z = 0f },
            }),
            (new float3x3(
                new float3(1, 2, 3),
                new float3(4, 5, 6),
                new float3(7, 8, 9)
            ), new {
                c0 = new { x = 1f, y = 2f, z = 3f },
                c1 = new { x = 4f, y = 5f, z = 6f },
                c2 = new { x = 7f, y = 8f, z = 9f },
            }),
        };
    }

    public class Float3x4Tests : ValueTypeTester<float3x4>
    {
        public static readonly IReadOnlyCollection<(float3x4 deserialized, object anonymous)> representations = new (float3x4, object)[] {
            (new float3x4(), new {
                c0 = new { x = 0f, y = 0f, z = 0f },
                c1 = new { x = 0f, y = 0f, z = 0f },
                c2 = new { x = 0f, y = 0f, z = 0f },
                c3 = new { x = 0f, y = 0f, z = 0f },
            }),
            (new float3x4(
                new float3(1, 2, 3),
                new float3(4, 5, 6),
                new float3(7, 8, 9),
                new float3(10, 11, 12)
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
    public class Float4x2Tests : ValueTypeTester<float4x2>
    {
        public static readonly IReadOnlyCollection<(float4x2 deserialized, object anonymous)> representations = new (float4x2, object)[] {
            (new float4x2(), new {
                c0 = new { x = 0f, y = 0f, z = 0f, w = 0f },
                c1 = new { x = 0f, y = 0f, z = 0f, w = 0f },
            }),
            (new float4x2(
                new float4(1, 2, 3, 4),
                new float4(5, 6, 7, 8)
            ), new {
                c0 = new { x = 1f, y = 2f, z = 3f, w = 4f },
                c1 = new { x = 5f, y = 6f, z = 7f, w = 8f },
            }),
        };
    }

    public class Float4x3Tests : ValueTypeTester<float4x3>
    {
        public static readonly IReadOnlyCollection<(float4x3 deserialized, object anonymous)> representations = new (float4x3, object)[] {
            (new float4x3(), new {
                c0 = new { x = 0f, y = 0f, z = 0f, w = 0f },
                c1 = new { x = 0f, y = 0f, z = 0f, w = 0f },
                c2 = new { x = 0f, y = 0f, z = 0f, w = 0f },
            }),
            (new float4x3(
                new float4(1, 2, 3, 4),
                new float4(5, 6, 7, 8),
                new float4(9, 10, 11, 12)
            ), new {
                c0 = new { x = 1f, y = 2f, z = 3f, w = 4f },
                c1 = new { x = 5f, y = 6f, z = 7f, w = 8f },
                c2 = new { x = 9f, y = 10f, z = 11f, w = 12f },
            }),
        };
    }

    public class Float4x4Tests : ValueTypeTester<float4x4>
    {
        public static readonly IReadOnlyCollection<(float4x4 deserialized, object anonymous)> representations = new (float4x4, object)[] {
            (new float4x4(), new {
                c0 = new { x = 0f, y = 0f, z = 0f, w = 0f },
                c1 = new { x = 0f, y = 0f, z = 0f, w = 0f },
                c2 = new { x = 0f, y = 0f, z = 0f, w = 0f },
                c3 = new { x = 0f, y = 0f, z = 0f, w = 0f },
            }),
            (new float4x4(
                new float4(1, 2, 3, 4),
                new float4(5, 6, 7, 8),
                new float4(9, 10, 11, 12),
                new float4(13, 14, 15, 16)
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
