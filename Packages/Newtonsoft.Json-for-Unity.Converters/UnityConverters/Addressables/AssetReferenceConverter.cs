using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Newtonsoft.Json.UnityConverters.Addressables
{
    public class AssetReferenceConverter : PartialConverter<AssetReference>
    {
        protected override void ReadValue(ref AssetReference value, string name, JsonReader reader, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }

        protected override void WriteJsonProperties(JsonWriter writer, AssetReference value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }
    }
}
