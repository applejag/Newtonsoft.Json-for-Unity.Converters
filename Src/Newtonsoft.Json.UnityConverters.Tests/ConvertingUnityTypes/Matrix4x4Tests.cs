using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class Matrix4x4Tests : TypeTester<Matrix4x4>
    {
        public static readonly IReadOnlyCollection<(Matrix4x4 deserialized, object anonymous)> representations = new (Matrix4x4, object)[] {
            (new Matrix4x4 (
                new Vector4(00f, 10f, 20f, 30f),
                new Vector4(01f, 11f, 21f, 31f),
                new Vector4(02f, 12f, 22f, 32f),
                new Vector4(03f, 13f, 23f, 33f)
            ), new { 
                m00 = 00f, m01 = 01f, m02 = 02f, m03 = 03f,
                m10 = 10f, m11 = 11f, m12 = 12f, m13 = 13f,
                m20 = 20f, m21 = 21f, m22 = 22f, m23 = 23f,
                m30 = 30f, m31 = 31f, m32 = 32f, m33 = 33f,
            })
        };
    }
}
