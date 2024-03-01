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
        private static readonly Dictionary<ValueTuple<string, string>, Type> _typeByNameAndAssembly
            = new Dictionary<ValueTuple<string, string>, Type>();
        private static readonly Dictionary<string, Assembly> _assemblyByName
            = new Dictionary<string, Assembly>();

        private static readonly Assembly[] _assemblies;

        static TypeCache()
        {
            var records = AppDomain.CurrentDomain.GetAssemblies()
                .Select(x => new Record(x))
                .Where(x => x.AssemblyName != "Microsoft.GeneratedCode")
                .OrderBy(AssemblyOrderBy).ThenBy(x => x.AssemblyName)
                .ToList();

            _assemblies = new Assembly[records.Count];
            _assemblyByName = new Dictionary<string, Assembly>(records.Count);

            for (int i = 0; i < records.Count; i++)
            {
                var record = records[i];
                _assemblies[i] = record.Assembly;

                // Adding them like this because the LINQ ToDictionary does not like duplicate keys
                _assemblyByName[record.AssemblyName] = record.Assembly;
            }
        }

        private static int AssemblyOrderBy(Record record)
        {
            // Newtonsoft.Json converters should be among the first, as they're most commonly referenced
            if (record.AssemblyName.StartsWith("Newtonsoft.Json"))
            {
                return -10;
            }

            // Relies on the heuristic that "assembly name == namespace"
            switch (GetRootNamespace(record.AssemblyName))
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
            if (_typeByName.TryGetValue(name, out var type))
            {
                return type;
            }

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
                        _typeByName[name] = type;
                        _typeByNameAndAssembly[(name, assemblyName)] = type;
                        return type;
                    }
                }
            }

            // Check this assembly, or if it has AssemblyQualifiedName
            type = Type.GetType(name);
            if (type != null)
            {
                _typeByName[name] = type;
                _typeByNameAndAssembly[(name, type.Assembly.GetName().Name)] = type;
                return type;
            }

            // Check all the other assemblies, from last imported to first
            foreach (var assembly in _assemblies)
            {
                type = assembly.GetType(name);
                if (type != null)
                {
                    _typeByName[name] = type;
                    _typeByNameAndAssembly[(name, type.Assembly.GetName().Name)] = type;
                    return type;
                }
            }

            return null;
        }


        private readonly struct Record
        {
            public Assembly Assembly { get; }
            public string AssemblyName { get; }

            public Record(Assembly assembly)
            {
                Assembly = assembly;
                AssemblyName = assembly.GetName().Name;
            }
        }
    }
}
