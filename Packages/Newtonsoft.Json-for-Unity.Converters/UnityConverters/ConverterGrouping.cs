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
using System.Linq;
#if UNITY_EDITOR
#endif

namespace Newtonsoft.Json.UnityConverters
{
    internal class ConverterGrouping
    {
        public List<Type> outsideConverters { get; set; }
        public List<Type> unityConverters { get; set; }
        public List<Type> jsonNetConverters { get; set; }

        /// <summary>
        /// List of converter types that should be excluded from automatic registration
        /// to prevent circular references or stack overflows.
        /// </summary>
        private static readonly HashSet<string> ExcludedConverterTypes = new HashSet<string>
        {
            "Unity.ProjectAuditor.Editor.Core.DescriptorJsonConverter"
        };

        /// <summary>
        /// List of namespace patterns that should be excluded from automatic registration
        /// to prevent circular references or stack overflows.
        /// </summary>
        private static readonly HashSet<string> ExcludedNamespacePatterns = new HashSet<string>
        {
            "Unity.ProjectAuditor"
        };

        public static ConverterGrouping Create(IEnumerable<Type> types)
        {
            var grouping = new ConverterGrouping {
                outsideConverters = new List<Type>(),
                unityConverters = new List<Type>(),
                jsonNetConverters = new List<Type>(),
            };

            foreach (var converter in types)
            {
                // Skip excluded converter types to prevent circular references
                if (IsExcludedConverter(converter))
                {
                    continue;
                }

                if (converter.Namespace?.StartsWith("Newtonsoft.Json.UnityConverters") == true)
                {
                    grouping.unityConverters.Add(converter);
                }
                else if (converter.Namespace?.StartsWith("Newtonsoft.Json.Converters") == true)
                {
                    grouping.jsonNetConverters.Add(converter);
                }
                else
                {
                    grouping.outsideConverters.Add(converter);
                }
            }

            return grouping;
        }

        /// <summary>
        /// Checks if a converter type should be excluded from automatic registration.
        /// </summary>
        /// <param name="converterType">The converter type to check.</param>
        /// <returns>True if the converter should be excluded, false otherwise.</returns>
        private static bool IsExcludedConverter(Type converterType)
        {
            if (converterType?.FullName == null)
            {
                return false;
            }

            // Check exact type name exclusions
            if (ExcludedConverterTypes.Contains(converterType.FullName))
            {
                return true;
            }

            // Check namespace pattern exclusions
            if (converterType.Namespace != null)
            {
                foreach (var excludedPattern in ExcludedNamespacePatterns)
                {
                    if (converterType.Namespace.StartsWith(excludedPattern))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
