using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Math
{
    public class QuaternionTests : ValueTypeTester<Quaternion>
    {
        public static readonly IReadOnlyCollection<(Quaternion deserialized, object anonymous)> representations = new (Quaternion, object)[] {
            (new Quaternion(), new { x = 0f, y = 0f, z = 0f, w = 0f }),
            (new Quaternion(1, 2, 3, 4), new { x = 1f, y = 2f, z = 3f, w = 4f }),
        };
    }
}
