using System.Collections.Generic;
using Unity.Mathematics;

namespace Newtonsoft.Json.UnityConverters.Tests.Mathematics
{
    public class HalfTests : ValueTypeTester<half>
    {
        public static readonly IReadOnlyCollection<(half deserialized, object anonymous)> representations = new (half, object)[] {
            (new half(), 0f),
            (new half(1), 1),
        };
    }

    public class Half2Tests : ValueTypeTester<half2>
    {
        public static readonly IReadOnlyCollection<(half2 deserialized, object anonymous)> representations = new (half2, object)[] {
            (new half2(), new { x = 0f, y = 0f }),
            (new half2(new half(1), new half(2)), new { x = 1f, y = 2f }),
        };
    }

    public class Half3Tests : ValueTypeTester<half3>
    {
        public static readonly IReadOnlyCollection<(half3 deserialized, object anonymous)> representations = new (half3, object)[] {
            (new half3(), new { x = 0f, y = 0f, z = 0f }),
            (new half3(new half(1), new half(2), new half(3)), new { x = 1f, y = 2f, z = 3f }),
        };
    }

    public class Half4Tests : ValueTypeTester<half4>
    {
        public static readonly IReadOnlyCollection<(half4 deserialized, object anonymous)> representations = new (half4, object)[] {
            (new half4(), new { x = 0f, y = 0f, z = 0f, w = 0f }),
            (new half4(new half(1), new half(2), new half(3), new half(4)), new { x = 1f, y = 2f, z = 3f, w = 4f }),
        };
    }
}
