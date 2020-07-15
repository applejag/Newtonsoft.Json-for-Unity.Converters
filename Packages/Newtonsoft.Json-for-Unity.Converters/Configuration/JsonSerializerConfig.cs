using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Configuration
{
    [CreateAssetMenu(fileName = "JsonSerializerConfig.asset", menuName = "Newtonsoft.Json Converters config")]
    public sealed class JsonSerializerConfig : ScriptableObject
    {
        public bool useUnityContractResolver = true;

        public bool useAllOutsideConverters = true;

        public List<ConverterConfig> outsideConverters = new List<ConverterConfig>();

        public bool useAllUnityConverters = true;

        public List<ConverterConfig> unityConverters = new List<ConverterConfig>();

        public bool useAllJsonNetConverters = false;

        public List<ConverterConfig> jsonNetConverters = new List<ConverterConfig> {
            new ConverterConfig(typeof(StringEnumConverter)),
            new ConverterConfig(typeof(VersionConverter)),
        };
    }
}
