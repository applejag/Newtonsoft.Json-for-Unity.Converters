using System;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Configuration
{
#pragma warning disable CA2235 // Mark all non-serializable fields
    [Serializable]
    public sealed class UnityConvertersConfig : ScriptableObject
    {
        internal const string PATH = "Assets/Resources/Newtonsoft.Json-for-Unity.Converters.asset";
        internal const string PATH_FOR_RESOURCES_LOAD = "Newtonsoft.Json-for-Unity.Converters";

        public bool useUnityContractResolver { get; set; } = true;

        public bool useAllOutsideConverters { get; set; } = true;

        public List<ConverterConfig> outsideConverters { get; set; } = new List<ConverterConfig>();

        public bool useAllUnityConverters { get; set; } = true;

        public List<ConverterConfig> unityConverters { get; set; } = new List<ConverterConfig>();

        public bool useAllJsonNetConverters { get; set; } = false;

        public List<ConverterConfig> jsonNetConverters { get; set; } = new List<ConverterConfig> {
            new ConverterConfig { converterName = typeof(StringEnumConverter).AssemblyQualifiedName },
            new ConverterConfig { converterName = typeof(VersionConverter).AssemblyQualifiedName },
        };
    }
#pragma warning restore CA2235 // Mark all non-serializable fields
}
