using System.Collections.Generic;
using Unity.Mathematics;

namespace Newtonsoft.Json.UnityConverters.Tests.Mathematics
{
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
}
