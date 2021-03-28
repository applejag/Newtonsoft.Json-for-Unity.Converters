using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Scripting
{
    public class LayerMaskTests : TypeTester<LayerMask>
    {
        public static readonly IReadOnlyCollection<(LayerMask deserialized, object anonymous)> representations = new (LayerMask, object)[] {
            (new LayerMask(), 0),
            (new LayerMask { value = 123 }, 123),
            (new LayerMask { value = -123 }, -123),
        };
    }
}
