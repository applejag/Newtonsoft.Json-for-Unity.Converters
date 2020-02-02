using UnityEngine;
using Newtonsoft.Json.Unity.Converters;

namespace Newtonsoft.Json.Unity
{
    internal static class UnityTypeConverterInitializer
    {

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
#endif
#pragma warning disable IDE0051 // Remove unused private members
        internal static void Init()
#pragma warning restore IDE0051 // Remove unused private members
        {
            JsonConvert.DefaultSettings += GetUnityJsonSerializerSettings;
        }

        private static JsonSerializerSettings GetUnityJsonSerializerSettings()
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new UnityTypeConverter());
            return settings;
        }
    }
}
