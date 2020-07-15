using System;

namespace Newtonsoft.Json.UnityConverters.Configuration
{
    [Serializable]
    public struct KeyedConfig
    {
        public string key;

        public ConfigType type;

        public bool boolean;

        public int integer;

        public float number;

        public string text;
    }
}
