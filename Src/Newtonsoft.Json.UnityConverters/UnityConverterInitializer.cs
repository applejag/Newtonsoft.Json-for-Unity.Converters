﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Converters;
using UnityEngine;
using UnityEngine.Scripting;

namespace Newtonsoft.Json.UnityConverters
{
    internal static class UnityConverterInitializer
    {
        private static readonly JsonConverter[] BUILTIN_CONVERTERS = {
            new StringEnumConverter(),
            new VersionConverter()
        };

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        [Preserve]
#pragma warning disable IDE0051 // Remove unused private members
        internal static void Init()
#pragma warning restore IDE0051 // Remove unused private members
        {
            if (JsonConvert.DefaultSettings == null)
            {
                JsonConvert.DefaultSettings = GetDefaultUnitySettings;
            }
        }

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
        public static JsonSerializerSettings DefaultUnitySettings { get; set; } = new JsonSerializerSettings {
            Converters = CreateConverters()
        };

        internal static JsonSerializerSettings GetDefaultUnitySettings()
        {
            return DefaultUnitySettings;
        }

        /// <summary>
        /// Create the converter instances.
        /// </summary>
        /// <returns>The converters.</returns>
        private static List<JsonConverter> CreateConverters()
        {
            var customs = FindConverterTypes()
                .Select(type => CreateConverter(type))
                .WhereNotNull();

            return customs.Concat(BUILTIN_CONVERTERS).ToList();

        }

        /// <summary>
        /// Find all the valid converter types.
        /// </summary>
        /// <returns>The types.</returns>
        private static Type[] FindConverterTypes()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Select(dll => dll.GetTypes()
                    .Where(type
                        => typeof(JsonConverter).IsAssignableFrom(type)

                        && !type.IsAbstract && !type.IsGenericTypeDefinition
                        && type.GetConstructor(Array.Empty<Type>()) != null
                        && type.Namespace?.StartsWith("Newtonsoft.Json") != true
                    )
                )
                .SelectMany(types => types)
                .ToArray();
        }

        /// <summary>
        /// Try to create the converter of specified type.
        /// </summary>
        /// <returns>The converter.</returns>
        /// <param name="jsonConverterType">Type.</param>
        private static JsonConverter? CreateConverter(Type jsonConverterType)
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

        private static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> values)
            where T : class
        {
            foreach (T? item in values)
            {
                if (item != null)
                {
                    yield return item;
                }
            }
        }
    }
}
