using UnityEngine.Rendering;

namespace Newtonsoft.Json.UnityConverters.Math
{
    public class SphericalHarmonicsL2Converter : PartialFloatConverter<SphericalHarmonicsL2>
    {
        // Magic numbers taken from /Runtime/Export/Math/SphericalHarmonicsL2.bindings.cs
        // inside Unitys open source repo
        // https://github.com/Unity-Technologies/UnityCsReference/blob/2019.2/Runtime/Export/Math/SphericalHarmonicsL2.bindings.cs#L59
        private const int COEFFICIENT_COUNT = 9;
        private const int ARRAY_SIZE = 3 * COEFFICIENT_COUNT;
        private static readonly string[] _memberNames = GetMemberNames();

        public SphericalHarmonicsL2Converter() : base(_memberNames)
        {
        }

        protected override SphericalHarmonicsL2 CreateInstanceFromValues(ValuesArray<float> values)
        {
            var instance = new SphericalHarmonicsL2();

            for (int rgb = 0; rgb < 3; rgb++)
            {
                for (int coefficient = 0; coefficient < COEFFICIENT_COUNT; coefficient++)
                {
                    instance[rgb, coefficient] = values[rgb * COEFFICIENT_COUNT + coefficient];
                }
            }

            return instance;
        }

        protected override float[] ReadInstanceValues(SphericalHarmonicsL2 instance)
        {
            float[] array = new float[ARRAY_SIZE];

            for (int rgb = 0; rgb < 3; rgb++)
            {
                for (int coefficient = 0; coefficient < COEFFICIENT_COUNT; coefficient++)
                {
                    array[rgb * COEFFICIENT_COUNT + coefficient] = instance[rgb, coefficient];
                }
            }

            return array;
        }

        private static string[] GetMemberNames()
        {
            string[] array = new string[ARRAY_SIZE];

            for (int i = 0; i < COEFFICIENT_COUNT; i++)
            {
                array[i] = 'r' + i.ToString();
            }

            for (int i = 0; i < COEFFICIENT_COUNT; i++)
            {
                array[COEFFICIENT_COUNT + i] = 'g' + i.ToString();
            }

            for (int i = 0; i < COEFFICIENT_COUNT; i++)
            {
                array[COEFFICIENT_COUNT + COEFFICIENT_COUNT + i] = 'b' + i.ToString();
            }

            return array;
        }
    }
}
