using System.Collections.Generic;
using Unity.Mathematics;

namespace Newtonsoft.Json.UnityConverters.Tests.Mathematics
{
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

}
