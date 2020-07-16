using System;
using System.Collections.Generic;
using System.Linq;

namespace Newtonsoft.Json.UnityConverters.Configuration
{
    [Serializable]
    public struct ConverterConfig
    {
        public bool enabled;

        public string converterName;

        public List<KeyedConfig> settings;

        public ConverterConfig(Type converter, IEnumerable<KeyedConfig> settings = null)
        {
            enabled = true;
            converterName = converter?.FullName;
            this.settings = settings?.ToList() ?? new List<KeyedConfig>();
        }

        public ConverterConfig(string converterName, IEnumerable<KeyedConfig> settings = null)
        {
            enabled = true;
            this.converterName = converterName;
            this.settings = settings?.ToList() ?? new List<KeyedConfig>();
        }
    }
}
