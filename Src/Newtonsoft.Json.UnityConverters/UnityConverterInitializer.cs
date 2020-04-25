#region License
// The MIT License (MIT)
//
// Copyright (c) 2018 Wanzyee Studio
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
using System.Linq;
using Newtonsoft.Json.Converters;
using UnityEngine;
using UnityEngine.Scripting;

namespace Newtonsoft.Json.UnityConverters
{
    internal static class UnityConverterInitializer
    {
        private static readonly JsonConverter[] _builtinConverters = {
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
            var customs = FindCustomConverters()
                .Concat(FindUnityConverters())
                .Select(type => CreateConverter(type))
                .WhereNotNull();

            return customs.Concat(_builtinConverters).ToList();

        }

        /// <summary>
        /// Find all the valid converter types outside of Newtonsoft.Json namespaces.
        /// </summary>
        /// <returns>The types.</returns>
        private static IEnumerable<Type> FindCustomConverters()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Select(dll => dll.GetTypes()
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
