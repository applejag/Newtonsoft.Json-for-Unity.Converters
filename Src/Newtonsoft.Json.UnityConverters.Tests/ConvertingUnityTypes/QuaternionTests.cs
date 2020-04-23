using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class QuaternionTests : TypeTester<Quaternion>
    {
        public static readonly IReadOnlyCollection<(Quaternion deserialized, object anonymous)> representations = new (Quaternion, object)[] {
            (new Quaternion(1, 2, 3, 4), new { x = 1.0, y = 2.0, z = 3.0, w = 4.0 })
        };
    }
}
