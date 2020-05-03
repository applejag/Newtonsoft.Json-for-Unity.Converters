using System;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace Newtonsoft.Json.UnityConverters.Tests.Math
{
    public class SphericalHarmonicsL2Tests : ValueTypeTester<SphericalHarmonicsL2>
    {
        public static readonly IReadOnlyCollection<(SphericalHarmonicsL2 deserialized, object anonymous)> representations = new (SphericalHarmonicsL2, object)[] {
            (new SphericalHarmonicsL2(), new {
                r0 = 0f, r1 = 0f, r2 = 0f, r3 = 0f, r4 = 0f, r5 = 0f, r6 = 0f, r7 = 0f, r8 = 0f,
                g0 = 0f, g1 = 0f, g2 = 0f, g3 = 0f, g4 = 0f, g5 = 0f, g6 = 0f, g7 = 0f, g8 = 0f,
                b0 = 0f, b1 = 0f, b2 = 0f, b3 = 0f, b4 = 0f, b5 = 0f, b6 = 0f, b7 = 0f, b8 = 0f,
            }),
            (CreateInstance(
                r: new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                g: new float[] { 11, 12, 13, 14, 15, 16, 17, 18, 19 },
                b: new float[] { 21, 22, 23, 24, 25, 26, 27, 28, 29 }
            ), new {
                r0 = 1f, r1 = 2f, r2 = 3f, r3 = 4f, r4 = 5f, r5 = 6f, r6 = 7f, r7 = 8f, r8 = 9f,
                g0 = 11f, g1 = 12f, g2 = 13f, g3 = 14f, g4 = 15f, g5 = 16f, g6 = 17f, g7 = 18f, g8 = 19f,
                b0 = 21f, b1 = 22f, b2 = 23f, b3 = 24f, b4 = 25f, b5 = 26f, b6 = 27f, b7 = 28f, b8 = 29f,
            })
        };

        private static SphericalHarmonicsL2 CreateInstance(float[] r, float[] g, float[] b)
        {
            var instance = new SphericalHarmonicsL2();

            ApplyArray(ref instance, r, 0);
            ApplyArray(ref instance, g, 1);
            ApplyArray(ref instance, b, 2);

            return instance;
        }

        private static void ApplyArray(ref SphericalHarmonicsL2 sh, float[] values, int rgbIndex)
        {
            if (values?.Length != 9)
            {
                throw new ArgumentException($"Expected 9 elements in RGB index {rgbIndex}, got {values?.Length.ToString() ?? "null"}");
            }

            for (int i = 0; i < 9; i++)
            {
                sh[rgbIndex, i] = values[i];
            }
        }
    }
}
