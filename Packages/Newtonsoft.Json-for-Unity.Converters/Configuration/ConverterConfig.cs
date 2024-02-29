using System;
using System.Collections.Generic;

namespace Newtonsoft.Json.UnityConverters.Configuration
{
#pragma warning disable CA2235 // Mark all non-serializable fields
    [Serializable]
    [System.Diagnostics.DebuggerDisplay("{converterName}, enabled={enabled}")]
    public struct ConverterConfig : IEquatable<ConverterConfig>
    {
        public bool enabled;

        public string converterName;

        public string converterAssembly;

        public List<KeyedConfig> settings;

        public override string ToString()
        {
            return $"{{enabled={enabled}, converterName={converterName}, assembly={converterAssembly}, settings=[{settings?.Count ?? 0}]}}";
        }

        public override bool Equals(object obj)
        {
            return obj is ConverterConfig config && Equals(config);
        }

        public bool Equals(ConverterConfig other)
        {
            return enabled == other.enabled &&
                   converterName == other.converterName &&
                   converterAssembly == other.converterAssembly &&
                   EqualityComparer<List<KeyedConfig>>.Default.Equals(settings, other.settings);
        }

#pragma warning disable S2328 // "GetHashCode" should not reference mutable fields
        public override int GetHashCode()
#pragma warning restore S2328 // "GetHashCode" should not reference mutable fields
        {
            int hashCode = 913629501;
            hashCode = hashCode * -1521134295 + enabled.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(converterName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(converterAssembly);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<KeyedConfig>>.Default.GetHashCode(settings);
            return hashCode;
        }

        public static bool operator ==(ConverterConfig left, ConverterConfig right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ConverterConfig left, ConverterConfig right)
        {
            return !(left == right);
        }
    }
#pragma warning restore CA2235 // Mark all non-serializable fields
}
