using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Newtonsoft.Json.UnityConverters.Utility
{
    internal static class TypeCache
    {
        private static readonly Dictionary<string, Type> _typeByName
            = new Dictionary<string, Type>();

        private static readonly Assembly[] _assemblies
            = AppDomain.CurrentDomain.GetAssemblies()
                // Reversing so we get last imported assembly first.
                // When searching for types we want to look in mscorlib last
                // and Newtonsoft.Json up as the first ones
                .Reverse()
                .ToArray();

        public static Type FindType(string name)
        {
            if (_typeByName.TryGetValue(name, out var type))
            {
                return type;
            }
            else
            {
                // Check this assembly, or if it has AssemblyQualifiedName
                type = Type.GetType(name);
                if (type != null)
                {
                    _typeByName[name] = type;
                    return type;
                }

                // Check all the other assemblies, from last imported to first
                foreach (var assembly in _assemblies)
                {
                    type = assembly.GetType(name);
                    if (type != null)
                    {
                        _typeByName[name] = type;
                        return type;
                    }
                }
                return null;
            }
        }
    }
}
