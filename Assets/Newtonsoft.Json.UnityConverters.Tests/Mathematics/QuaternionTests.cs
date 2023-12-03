using System.Collections.Generic;
using Unity.Mathematics;

namespace Newtonsoft.Json.UnityConverters.Tests.Mathematics
{
    public class QuaternionTests : ValueTypeTester<quaternion>
    {
        public static readonly IReadOnlyCollection<(quaternion deserialized, object anonymous)> representations = new (quaternion, object)[] {
            (new quaternion(), new { x = 0f, y = 0f, z = 0f, w = 0f }),
            (new quaternion(1, 2, 3, 4), new { x = 1f, y = 2f, z = 3f, w = 4f }),
        };
    }
}
