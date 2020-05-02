using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Scripting
{
    public class RangeIntTests : ValueTypeTester<RangeInt>
    {
        public static readonly IReadOnlyCollection<(RangeInt deserialized, object anonymous)> representations = new (RangeInt, object)[] {
            (new RangeInt(1, 2), new { start = 1, length = 2 })
        };
    }
}
