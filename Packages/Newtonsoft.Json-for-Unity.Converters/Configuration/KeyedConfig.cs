using System;
using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Configuration
{
#pragma warning disable CA2235 // Mark all non-serializable fields
    [Serializable]
    public struct KeyedConfig : IEquatable<KeyedConfig>
    {
        public string key;

        public ConfigType type;

        public bool boolean;

        public int integer;

        public float number;

        public string text;

        public override bool Equals(object obj)
        {
            return obj is KeyedConfig config && Equals(config);
        }

        public bool Equals(KeyedConfig other)
        {
            if (type != other.type)
            {
                return false;
            }

            switch (type)
            {
            case ConfigType.Boolean:
                return boolean == other.boolean;
            case ConfigType.Integer:
                return integer == other.integer;
            case ConfigType.Number:
                return Mathf.Approximately(number, other.number);
            case ConfigType.Text:
                return text == other.text;

            default:
                return false;
            }
        }

#pragma warning disable S2328 // "GetHashCode" should not reference mutable fields
        public override int GetHashCode()
#pragma warning restore S2328 // "GetHashCode" should not reference mutable fields
        {
            int hashCode = 910641971;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(key);
            hashCode = hashCode * -1521134295 + type.GetHashCode();
            hashCode = hashCode * -1521134295 + boolean.GetHashCode();
            hashCode = hashCode * -1521134295 + integer.GetHashCode();
            hashCode = hashCode * -1521134295 + number.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(text);
            return hashCode;
        }

        public static bool operator ==(KeyedConfig left, KeyedConfig right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(KeyedConfig left, KeyedConfig right)
        {
            return !(left == right);
        }
    }
#pragma warning restore CA2235 // Mark all non-serializable fields
}
