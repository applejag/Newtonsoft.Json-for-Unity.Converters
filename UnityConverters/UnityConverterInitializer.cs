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
    public static class UnityConverterInitializer
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
        internal static List<JsonConverter> CreateConverters(UnityConvertersConfig config)
        {
            var converterTypes = new List<Type>();
            var grouping = FindGroupedConverters(config);
            converterTypes.AddRange(ApplyConfigFilter(grouping.outsideConverters, config.useAllOutsideConverters, config.outsideConverters));
            converterTypes.AddRange(ApplyConfigFilter(grouping.unityConverters, config.useAllUnityConverters, config.unityConverters));
            converterTypes.AddRange(ApplyConfigFilter(grouping.jsonNetConverters, config.useAllJsonNetConverters, config.jsonNetConverters));

            var result = new List<JsonConverter>();
            result.AddRange(converterTypes.Select(CreateConverter));
            return result;
        }

        internal static ConverterGrouping FindGroupedConverters(UnityConvertersConfig config)
        {
            if (config.autoSyncConverters)
            {
                return ConverterGrouping.Create(FindConverters());
            }

            return new ConverterGrouping {
                outsideConverters = config.outsideConverters.Select(x => GetTypeOrLog(x.converterName, x.converterAssembly)).WhereNotNullRef().ToList(),
                unityConverters = config.unityConverters.Select(x => GetTypeOrLog(x.converterName, x.converterAssembly)).WhereNotNullRef().ToList(),
                jsonNetConverters = config.jsonNetConverters.Select(x => GetTypeOrLog(x.converterName, x.converterAssembly)).WhereNotNullRef().ToList(),
            };
        }

        private static Type GetTypeOrLog(string name, string assemblyName)
        {
            var type = TypeCache.FindType(name, assemblyName);
            if (type == null)
            {
                Debug.LogWarning($"Failed to lookup JsonConverter type. Ignoring it. Type name: \"{name}\""+
                    "\nTo fix this warning by going to \"Edit > Json.NET converter settings...\", and then the editor will update your config for you.");
            }
            return type;
        }

        /// <summary>
        /// Finds all the valid converter types inside the <c>Newtonsoft.Json</c> assembly.
        /// </summary>
        /// <returns>The types.</returns>
        internal static IEnumerable<Type> FindConverters()
        {
#if UNITY_2019_2_OR_NEWER && UNITY_EDITOR
            var types = UnityEditor.TypeCache.GetTypesDerivedFrom<JsonConverter>();
#else
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(dll => dll.GetLoadableTypes());
#endif
            return FilterToJsonConvertersAndOrder(types);
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
                .Select(o => Utility.TypeCache.FindType(o.converterName, o.converterAssembly))
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
                return (JsonConverter)Activator.CreateInstance(jsonConverterType);
            }
            catch (Exception exception)
            {
                Debug.LogErrorFormat("Cannot create JsonConverter '{0}':\n{1}", jsonConverterType?.FullName, exception);
            }

            return null;
        }
    }
}
