using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class Matrix4x4Tests : TypeTester<Matrix4x4>
    {
        public static readonly IReadOnlyCollection<(Matrix4x4 deserialized, object anonymous)> representations = new (Matrix4x4, object)[] {
            (new Matrix4x4 (
                new Vector4(0f, 1f, 2f, 3f),
                new Vector4(10f, 11f, 12f, 13f),
                new Vector4(20f, 21f, 22f, 23f),
                new Vector4(30f, 31f, 32f, 33f)
            ), new { 
                m00 = 0f, m01 = 1f, m02 = 2f, m03 = 3f,
                m10 = 10f, m11 = 11f, m12 = 12f, m13 = 13f,
                m20 = 20f, m21 = 21f, m22 = 22f, m23 = 23f,
                m30 = 30f, m31 = 31f, m32 = 32f, m33 = 33f,
            })
        };
    }
}
