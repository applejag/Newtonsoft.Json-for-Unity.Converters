using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine.Rendering;

namespace Newtonsoft.Json.UnityConverters.Math
{
    public class SphericalHarmonicsL2Converter : PartialConverter<SphericalHarmonicsL2>
    {
        // Magic numbers taken from /Runtime/Export/Math/SphericalHarmonicsL2.bindings.cs
        // inside Unitys open source repo
        // https://github.com/Unity-Technologies/UnityCsReference/blob/2019.2/Runtime/Export/Math/SphericalHarmonicsL2.bindings.cs#L59
        private const int COEFFICIENT_COUNT = 9;
        private const int ARRAY_SIZE = 3 * COEFFICIENT_COUNT;
        private static readonly (string name, int rgb, int coefficient)[] _indices = GetMemberNames();
        private static readonly Dictionary<string, (int color, int coefficient)> _nameToIndex = GetNamesToIndexDictionary(_indices);

        private static (string name, int rgb, int coefficient)[] GetMemberNames()
        {
            var array = new (string name, int rgb, int coefficient)[ARRAY_SIZE];

            for (int i = 0; i < COEFFICIENT_COUNT; i++)
            {
                array[i] = ('r' + i.ToString(), 0, i);
            }

            for (int i = 0; i < COEFFICIENT_COUNT; i++)
            {
                array[COEFFICIENT_COUNT + i] = ('g' + i.ToString(), 1, i);
            }

            for (int i = 0; i < COEFFICIENT_COUNT; i++)
            {
                array[COEFFICIENT_COUNT + COEFFICIENT_COUNT + i] = ('b' + i.ToString(), 2, i);
            }

            return array;
        }

        // Reusing the same strings here instead of creating new ones. Tiny bit lower memory footprint
        private static Dictionary<string, (int color, int coefficient)> GetNamesToIndexDictionary((string name, int rgb, int coefficient)[] indices)
        {
            var dict = new Dictionary<string, (int color, int coefficient)>();
            for (int i = 0; i < indices.Length; i++)
            {
                (string name, int rgb, int coefficient) = indices[i];
                dict[name] = (rgb, coefficient);
            }
            return dict;
        }

        protected override void ReadValue(ref SphericalHarmonicsL2 value, string name, JsonReader reader, JsonSerializer serializer)
        {
            if (_nameToIndex.TryGetValue(name, out var index))
            {
                value[index.color, index.coefficient] = reader.ReadAsFloat() ?? 0f;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, SphericalHarmonicsL2 value, JsonSerializer serializer)
        {
            foreach (var (name, rgb, coefficient) in _indices) 
            {
                writer.WritePropertyName(name);
                writer.WriteValue(value[rgb, coefficient]);
            }
        }
    }
}
