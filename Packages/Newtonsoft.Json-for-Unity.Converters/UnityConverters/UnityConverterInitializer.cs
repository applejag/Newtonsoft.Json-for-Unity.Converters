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
using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    internal static class UnityConverterInitializer
    {
        private static readonly JsonConverter[] _builtinConverters = {
            new StringEnumConverter(),
            new VersionConverter()
        };

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
        public static JsonSerializerSettings DefaultUnityConvertersSettings { get; set; } = new JsonSerializerSettings {
            Converters = CreateConverters()
        };

        /// <summary>
        /// If set to <c>false</c> then will not try to inject converters on init via
        /// the default settings property on JsonConvert
        /// <see cref="JsonConvert.DefaultSettings"/>.
        /// Default is <c>true</c>.
        /// </summary>
        public static bool ShouldAddConvertsToDefaultSettings
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
        internal static void Init()
#pragma warning restore IDE0051 // Remove unused private members
        {
            UpdateDefaultSettings();
        }

        private static void UpdateDefaultSettings()
        {
            if (ShouldAddConvertsToDefaultSettings)
            {
                if (JsonConvert.DefaultSettings == null)
                {
                    JsonConvert.DefaultSettings = GetDefaultUnitySettings;
                }
            }
            else
            {
                if (JsonConvert.DefaultSettings == GetDefaultUnitySettings)
                {
                    JsonConvert.DefaultSettings = null;
                }
            }
        }

        internal static JsonSerializerSettings GetDefaultUnitySettings()
        {
            return DefaultUnityConvertersSettings;
        }

        /// <summary>
        /// Create the converter instances.
        /// </summary>
        /// <returns>The converters.</returns>
        private static List<JsonConverter> CreateConverters()
        {
            var customs = FindCustomConverters()
                .Concat(FindUnityConverters())
                .Select(type => CreateConverter(type))
                .WhereNotNullRef();

            JsonConverter[] array = customs.Concat(_builtinConverters).ToArray();
            return new List<JsonConverter>(array);
        }

        /// <summary>
        /// Find all the valid converter types outside of Newtonsoft.Json namespaces.
        /// </summary>
        /// <returns>The types.</returns>
        private static IEnumerable<Type> FindCustomConverters()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Select(dll => dll.GetLoadableTypes()
                    .Where(type
                        => typeof(JsonConverter).IsAssignableFrom(type)

                        && !type.IsAbstract && !type.IsGenericTypeDefinition
                        && type.GetConstructor(Array.Empty<Type>()) != null
                        && type.Namespace?.StartsWith("Newtonsoft.Json") != true
                    )
                    .OrderBy(type => type.Name)
                )
                .SelectMany(types => types);
        }

        /// <summary>
        /// Find all the valid converter types inside this assembly, <c>Newtonsoft.Json.UnityConverters</c>
        /// </summary>
        /// <returns>The types.</returns>
        private static IEnumerable<Type> FindUnityConverters()
        {
            return typeof(UnityConverterInitializer).Assembly.GetTypes()
                .Where(type
                    => typeof(JsonConverter).IsAssignableFrom(type)

                    && !type.IsAbstract && !type.IsGenericTypeDefinition
                    && type.GetConstructor(Array.Empty<Type>()) != null
                )
                .OrderBy(type => type.Name);
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
