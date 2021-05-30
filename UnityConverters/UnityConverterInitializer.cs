#region License
// The MIT License (MIT)
//
// Copyright (c) 2020 Wanzyee Studio
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.UnityConverters.Configuration;
using Newtonsoft.Json.UnityConverters.Helpers;
using Newtonsoft.Json.UnityConverters.Utility;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    internal static class UnityConverterInitializer
    {
        private static bool _shouldAddConvertsToDefaultSettings = true;

        /// <summary>
        /// The default <see cref="JsonSerializerSettings"/> given by <c>Newtonsoft.Json-for-Unity.Converters</c>
        /// </summary>
        /// 
        /// <remarks>
        /// All its properties stay default, but the <c>Converters</c> includes below:
        /// 	1. Any custom <see cref="JsonConverter"/> has constructor without parameters.
        /// 	2. Any <c>Newtonsoft.Json.JsonConverter</c> from <c>Newtonsoft.Json.UnityConverters</c>.
        /// 	3. <see cref="StringEnumConverter"/>.
        /// 	4. <see cref="VersionConverter"/>.
        /// </remarks>
        public static JsonSerializerSettings defaultUnityConvertersSettings { get; set; }
            = CreateJsonSettingsWithFreslyLoadedConfig();

        /// <summary>
        /// If set to <c>false</c> then will not try to inject converters on init via
        /// the default settings property on JsonConvert
        /// <see cref="JsonConvert.DefaultSettings"/>.
        /// Default is <c>true</c>.
        /// </summary>
        public static bool shouldAddConvertsToDefaultSettings
        {
            get => _shouldAddConvertsToDefaultSettings;
            set
            {
                _shouldAddConvertsToDefaultSettings = value;
                UpdateDefaultSettings();
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
#pragma warning disable IDE0051 // Remove unused private members
#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#endif
        internal static void Init()
#pragma warning restore IDE0051 // Remove unused private members
        {
            UpdateDefaultSettings();
        }

        private static void UpdateDefaultSettings()
        {
            if (shouldAddConvertsToDefaultSettings)
            {
                if (JsonConvert.DefaultSettings == null)
                {
                    JsonConvert.DefaultSettings = GetExistingDefaultUnitySettings;
                }
            }
            else
            {
                if (JsonConvert.DefaultSettings == GetExistingDefaultUnitySettings)
                {
                    JsonConvert.DefaultSettings = null;
                }
            }
        }

        /// <summary>
        /// Refreshes the settings that are found in the Resources folder
        /// (specified in <see cref="UnityConvertersConfig.PATH_FOR_RESOURCES_LOAD"/>);
        /// </summary>
        public static void RefreshSettingsFromConfig()
        {
            defaultUnityConvertersSettings = CreateJsonSettingsWithFreslyLoadedConfig();
        }

        internal static JsonSerializerSettings GetExistingDefaultUnitySettings()
        {
            return defaultUnityConvertersSettings;
        }

        private static JsonSerializerSettings CreateJsonSettingsWithFreslyLoadedConfig()
        {
            var config = Resources.Load<UnityConvertersConfig>(UnityConvertersConfig.PATH_FOR_RESOURCES_LOAD);

            if (!config)
            {
                config = ScriptableObject.CreateInstance<UnityConvertersConfig>();
            }

            var settings = new JsonSerializerSettings {
                Converters = CreateConverters(config),
            };

            if (config.useUnityContractResolver)
            {
                settings.ContractResolver = new UnityTypeContractResolver();
            }

            return settings;
        }

        /// <summary>
        /// Create the converter instances.
        /// </summary>
        /// <returns>The converters.</returns>
        private static List<JsonConverter> CreateConverters(UnityConvertersConfig config)
        {
            var customs = FindFilteredCustomConverters(config)
                .Concat(FindFilteredUnityConverters(config))
                .Concat(FindFilteredJsonNetConverters(config))
                .Select(type => CreateConverter(type))
                .Where(o => o != null);

            return new List<JsonConverter>(customs);
        }

        private static IEnumerable<Type> FindFilteredCustomConverters(UnityConvertersConfig config)
        {
            return ApplyConfigFilter(FindCustomConverters(), config.useAllOutsideConverters, config.outsideConverters);
        }

        /// <summary>
        /// Find all the valid converter types outside of Newtonsoft.Json namespaces.
        /// </summary>
        /// <returns>The types.</returns>
        internal static IEnumerable<Type> FindCustomConverters()
        {
            var typesFromOtherDomains = AppDomain.CurrentDomain.GetAssemblies()
                .Select(dll => dll.GetLoadableTypes()
                    .Where(type => type.Namespace?.StartsWith("Newtonsoft.Json") != true)
                )
                .SelectMany(types => types);

            return FilterToJsonConvertersAndOrder(typesFromOtherDomains);
        }

        private static IEnumerable<Type> FindFilteredUnityConverters(UnityConvertersConfig config)
        {
            return ApplyConfigFilter(FindUnityConverters(), config.useAllUnityConverters, config.unityConverters);
        }

        /// <summary>
        /// Find all the valid converter types inside this assembly, <c>Newtonsoft.Json.UnityConverters</c>
        /// </summary>
        /// <returns>The types.</returns>
        internal static IEnumerable<Type> FindUnityConverters()
        {
            return FilterToJsonConvertersAndOrder(typeof(UnityConverterInitializer).Assembly.GetTypes());
        }

        private static IEnumerable<Type> FindFilteredJsonNetConverters(UnityConvertersConfig config)
        {
            return ApplyConfigFilter(FindJsonNetConverters(), config.useAllJsonNetConverters, config.jsonNetConverters);
        }

        /// <summary>
        /// Finds all the valid converter types inside the <c>Newtonsoft.Json</c> assembly.
        /// </summary>
        /// <returns>The types.</returns>
        internal static IEnumerable<Type> FindJsonNetConverters()
        {
            return FilterToJsonConvertersAndOrder(typeof(JsonConverter).Assembly.GetTypes());
        }

        private static IEnumerable<Type> FilterToJsonConvertersAndOrder(IEnumerable<Type> types)
        {
            return types
                .Where(type
                    => typeof(JsonConverter).IsAssignableFrom(type)
                    && !type.IsAbstract && !type.IsGenericTypeDefinition
                    && type.GetConstructor(Array.Empty<Type>()) != null
                )
                .OrderBy(type => type.FullName);
        }

        /// <summary>
        /// Meant to be coupled to the configs from <see cref="UnityConvertersConfig"/>.
        /// When the use all argument <paramref name="useAll"/> is <c>false</c>, the intersection between
        /// the types given from the first argument <paramref name="types"/> and the enumeration of
        /// converter configs <paramref name="configs"/> are returned.
        /// </summary>
        private static IEnumerable<Type> ApplyConfigFilter(IEnumerable<Type> types, bool useAll, IEnumerable<ConverterConfig> configs)
        {
            if (useAll)
            {
                return types;
            }

            var typesOfEnabledThroughConfig = configs
                .Where(o => o.enabled)
                .Select(o => TypeCache.FindType(o.converterName))
                .Where(o => o != null);

            var hashMap = new HashSet<Type>(typesOfEnabledThroughConfig);

            return types.Intersect(hashMap);
        }

        /// <summary>
        /// Try to create the converter of specified type.
        /// </summary>
        /// <returns>The converter.</returns>
        /// <param name="jsonConverterType">Type.</param>
        [return: MaybeNull]
        private static JsonConverter CreateConverter(Type jsonConverterType)
        {
            try
            {
                var jsonConverter = (JsonConverter)Activator.CreateInstance(jsonConverterType);
                return jsonConverter;
            }
            catch (Exception exception)
            {
                Debug.LogErrorFormat("Cannot create JsonConverter '{0}':\n{1}", jsonConverterType.FullName, exception);
            }

            return null;
        }
    }
}
