using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    [CreateAssetMenu(fileName = "JsonSerializerConfig.asset", menuName = "Newtonsoft.Json Converters config")]
    public class JsonSerializerConfig : ScriptableObject
    {
        public bool someBool1;
        public bool someBool2;
    }
}
