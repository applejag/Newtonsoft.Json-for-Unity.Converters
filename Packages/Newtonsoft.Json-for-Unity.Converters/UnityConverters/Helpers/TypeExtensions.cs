using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Newtonsoft.Json.UnityConverters.Helpers
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
#if DEBUG
                Console.WriteLine("Newtonsoft.Json.UnityConverters.Helpers.TypeExtensions: "
                    + "Failed to load some types from assembly '{assembly.FullName}'. Maybe assembly is not fully loaded yet?\n"
                    + ex.ToString());
#endif
                return ex.Types.Where(t => t != null);
            }
        }
    }
}
