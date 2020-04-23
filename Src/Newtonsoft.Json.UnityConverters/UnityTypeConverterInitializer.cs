using Newtonsoft.Json.UnityConverters.Converters;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    internal static class UnityTypeConverterInitializer
    {

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
#pragma warning disable IDE0051 // Remove unused private members
        internal static void Init()
#pragma warning restore IDE0051 // Remove unused private members
        {
            JsonConvert.DefaultSettings += GetUnityJsonSerializerSettings;
        }

        internal static JsonSerializerSettings GetUnityJsonSerializerSettings()
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new ColorConverter());
            settings.Converters.Add(new Matrix4x4Converter());
            settings.Converters.Add(new QuaternionConverter());
            settings.Converters.Add(new VectorConverter());
            settings.Converters.Add(new UnityTypeConverter());
            return settings;
        }
    }
}
