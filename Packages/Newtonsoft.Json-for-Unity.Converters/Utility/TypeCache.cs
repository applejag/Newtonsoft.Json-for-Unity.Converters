using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Newtonsoft.Json.UnityConverters.Utility
{
    internal static class TypeCache
    {
        private static readonly Dictionary<ValueTuple<string, string>, Type> _typeByNameAndAssembly
            = new Dictionary<ValueTuple<string, string>, Type>();
        private static readonly Dictionary<string, Assembly> _assemblyByName
            = new Dictionary<string, Assembly>();

        private static readonly Assembly[] _assemblies;

        static TypeCache()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Select(x => new NamedAssembly(x))
                .Where(x => x.name != "Microsoft.GeneratedCode")
                .OrderBy(AssemblyOrderBy).ThenBy(x => x.name)
                .ToList();

            _assemblies = new Assembly[assemblies.Count];
            _assemblyByName = new Dictionary<string, Assembly>(assemblies.Count);

            for (int i = 0; i < assemblies.Count; i++)
            {
                NamedAssembly assembly = assemblies[i];
                _assemblies[i] = assembly.assembly;

                // Adding them like this because the LINQ ToDictionary does not like duplicate keys
                _assemblyByName[assembly.name] = assembly.assembly;
            }
        }

        private static int AssemblyOrderBy(NamedAssembly record)
        {
            // Newtonsoft.Json converters should be among the first, as they're most commonly referenced
            if (record.name.StartsWith("Newtonsoft.Json"))
            {
                return -10;
            }

            // Relies on the heuristic that "assembly name == namespace"
            switch (GetRootNamespace(record.name))
            {
                // User-defined code gets sent to the top
                case "Assembly-CSharp":
                    return -1;
                case "Assembly-CSharp-Editor":
                    return -2;

                // Unity standard library does not contain any converters
                case "Unity":
                    return 10;
                case "UnityEngine":
                    return 11;
                case "UnityEditor":
                    return 12;

                // .NET standard library does not contain any converters, so just put it at the end
                case "System":
                    return 20;
                case "netstandard":
                    return 21;
                case "mscorlib":
                    return 22;

                default:
                    return 0;
            }
        }

        private static string GetRootNamespace(string name)
        {
            int index = name.IndexOf('.');
            if (index > 0)
            {
                return name.Substring(0, index);
            }

            return name;
        }

        public static Type FindType(string name, string assemblyName)
        {
            Type type;
            if (assemblyName != null)
            {
                if (_typeByNameAndAssembly.TryGetValue((name, assemblyName), out type))
                {
                    return type;
                }

                if (_assemblyByName.TryGetValue(assemblyName, out var asm))
                {
                    type = asm.GetType(name);
                    if (type != null)
                    {
                        _typeByNameAndAssembly[(name, assemblyName)] = type;
                        return type;
                    }
                }
            }
            else
            {
                if (_typeByNameAndAssembly.TryGetValue((name, null), out type))
                {
                    return type;
                }
            }

            // Check this assembly, or if it has AssemblyQualifiedName
            type = Type.GetType(name);
            if (type != null)
            {
                _typeByNameAndAssembly[(name, null)] = type;
                return type;
            }

            // Check all the other assemblies, from last imported to first
            foreach (var assembly in _assemblies)
            {
                type = assembly.GetType(name);
                if (type != null)
                {
                    _typeByNameAndAssembly[(name, null)] = type;
                    return type;
                }
            }

            return null;
        }

        private readonly struct NamedAssembly
        {
            public Assembly assembly { get; }
            public string name { get; }

            public NamedAssembly(Assembly assembly)
            {
                this.assembly = assembly;
                name = assembly.GetName().Name;
            }
        }
    }
}
