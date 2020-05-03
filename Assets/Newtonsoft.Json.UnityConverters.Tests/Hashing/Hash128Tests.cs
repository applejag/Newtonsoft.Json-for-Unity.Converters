using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Hashing
{
    public class Hash128Tests : ValueTypeTester<Hash128>
    {
        public static readonly IReadOnlyCollection<(Hash128 deserialized, object anonymous)> representations = new (Hash128, object)[] {
            (new Hash128(1, 2, 3, 4), "01000000"+"02000000"+"03000000"+"04000000"),
            (new Hash128(0x00000002_00000001u, 0x00000004_00000003u), "01000000"+"02000000"+"03000000"+"04000000"),
            (new Hash128(), "00000000"+"00000000"+"00000000"+"00000000"),
        };

        public override void OkWithEmptyObject()
        {
            // Empty to disable the inherited test for this class.
        }
    }
}
