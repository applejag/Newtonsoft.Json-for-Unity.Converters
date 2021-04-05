using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Newtonsoft.Json.UnityConverters.Helpers
{
    internal static class TypeExtensions
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

        /// <summary>
        /// Gets the non-public instance field info <see cref="FieldInfo"/> for the converted type
        /// <typeparamref name="T"/>.
        /// If not found then will throw a missing member exception <see cref="MissingMemberException"/>.
        /// </summary>
        /// <remarks>
        /// If used in static initialization (ex: inside static constructor,
        /// static field, or static property backing field initialization)
        /// and the field does not exist it would invalidate the type for
        /// the entirety of the programs lifetime.
        /// </remarks>
        /// <param name="name">Name of the non-public instance field.</param>
        public static FieldInfo GetFieldInfoOrThrow(this Type type, string name)
        {
            return type.GetField(name, BindingFlags.NonPublic | BindingFlags.Instance)
                ?? throw new MissingMemberException(type.FullName, name);
        }

        public static void SetValueDirectRef<T1, T2>(this FieldInfo field, ref T1 state, T2 value)
        {
#if ENABLE_IL2CPP
            object boxed = state;
            field.SetValue(boxed, value);
            state = (T1)boxed;
#else
            TypedReference reference = __makeref(state);
            field.SetValueDirect(reference, value);
#endif
        }
    }
}
