using System.Collections.Generic;
using Unity.Mathematics;

namespace Newtonsoft.Json.UnityConverters.Tests.Mathematics
{
    public struct HalfWrapper
    {
        public half half;

        public HalfWrapper(half half)
        {
            this.half = half;
        }

        public override string ToString()
        {
            return half.ToString();
        }
    }

    #region Vector
    // Have to use a wrapper type, as Json.NET ignores the converters when
    // targeting a single scalar type.
    public class HalfTests : ValueTypeTester<HalfWrapper>
    {
        public static readonly IReadOnlyCollection<(HalfWrapper deserialized, object anonymous)> representations = new (HalfWrapper, object)[] {
            (new HalfWrapper(new half()), new {half = 0f}),
            (new HalfWrapper(new half(1)), new {half = 1f}),
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
    #endregion
}
