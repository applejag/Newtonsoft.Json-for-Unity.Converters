using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.UnityConverters.Tests;
using UnityEngine.AddressableAssets;

namespace Assets.Newtonsoft.Json.UnityConverters.Tests.Addressables
{
    public class AssetReferenceTests : TypeTester<AssetReference>
    {
        public static readonly IReadOnlyCollection<(AssetReference deserialized, object anonymous)> representations = new (AssetReference, object)[] {
            (new AssetReference("65ee4890b3c2b0f4db332c8305ce62bd"), "65ee4890b3c2b0f4db332c8305ce62bd"),
            (new AssetReference("31d1857eb02457d4d84fd43e6f32c401"), "31d1857eb02457d4d84fd43e6f32c401"),
            (new AssetReference("7446d4e9bc40aca48a68dc00da43f835"), "7446d4e9bc40aca48a68dc00da43f835"),
        };

        protected override bool AreEqual([AllowNull] AssetReference a, [AllowNull] AssetReference b)
        {
            return a.AssetGUID == b.AssetGUID;
        }
    }
}
