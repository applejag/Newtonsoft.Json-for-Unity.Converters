using System;
using System.Collections.Generic;
using System.Linq;

namespace Newtonsoft.Json.UnityConverters.Configuration
{
    [Serializable]
    public struct ConverterConfig
    {
        public string converter;

        public List<KeyedConfig> settings;

        public ConverterConfig(Type converter, IEnumerable<KeyedConfig> settings = null)
        {
            this.converter = GetTypeNameWithAssembly(converter);
            this.settings = settings?.ToList() ?? new List<KeyedConfig>();
        }

        public ConverterConfig(string converter, IEnumerable<KeyedConfig> settings = null)
        {
            this.converter = converter;
            this.settings = settings?.ToList() ?? new List<KeyedConfig>();
        }

        private static string GetTypeNameWithAssembly(Type type)
        {
            string assemblyName = type.Assembly.FullName;
            int assemblyNameSeparator = assemblyName.IndexOf(',');
            if (assemblyNameSeparator != -1)
            {
                assemblyName = assemblyName.Substring(0, assemblyNameSeparator);
            }


            return $"{type.FullName}, {assemblyName}";
        }
    }
}
