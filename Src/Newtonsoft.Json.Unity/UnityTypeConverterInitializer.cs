using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

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
        private static void Init()
#pragma warning restore IDE0051 // Remove unused private members
        {
            JsonConvert.DefaultSettings += GetJsonSerializerSettings;
        }

        private static JsonSerializerSettings GetJsonSerializerSettings()
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new UnityTypeConverter());
            return settings;
        }

        private class UnityTypeConverter : JsonConverter
        {
            private static readonly HashSet<Type> UnityEngineTypes = new HashSet<Type>(typeof(UnityEngine.Object).Assembly.GetTypes());

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteRawValue(JsonUtility.ToJson(value));
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                return JsonUtility.FromJson(JObject.Load(reader).ToString(), objectType);
            }

            public override bool CanConvert(Type objectType)
            {
                return IsUnityEngineType(objectType);
            }

            private static bool IsUnityEngineType(Type objectType)
            {
                return UnityEngineTypes.Contains(objectType);
            }
        }
    }
}