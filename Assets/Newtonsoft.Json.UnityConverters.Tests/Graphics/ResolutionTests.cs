using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Math
{
    public class ResolutionTests : ValueTypeTester<Resolution>
    {
        public static readonly IReadOnlyCollection<(Resolution deserialized, object anonymous)> representations = new (Resolution, object)[] {
            (new Resolution(), new {
                width = 0,
                height = 0,
                refreshRate = 0,
            }),
            (new Resolution {
                width = 1,
                height = 2,
                refreshRate = 3,
            }, new {
                width = 1,
                height = 2,
                refreshRate = 3,
            }),
        };
    }
}
