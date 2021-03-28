using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Math
{
    public class Matrix4x4Tests : ValueTypeTester<Matrix4x4>
    {
        public static readonly IReadOnlyCollection<(Matrix4x4 deserialized, object anonymous)> representations = new (Matrix4x4, object)[] {
            (new Matrix4x4(), new {
                m00 = 0f, m10 = 0f, m20 = 0f, m30 = 0f,
                m01 = 0f, m11 = 0f, m21 = 0f, m31 = 0f,
                m02 = 0f, m12 = 0f, m22 = 0f, m32 = 0f,
                m03 = 0f, m13 = 0f, m23 = 0f, m33 = 0f,
            }),
            (new Matrix4x4(
                new Vector4(00f, 10f, 20f, 30f),
                new Vector4(01f, 11f, 21f, 31f),
                new Vector4(02f, 12f, 22f, 32f),
                new Vector4(03f, 13f, 23f, 33f)
            ), new {
                m00 = 00f, m10 = 10f, m20 = 20f, m30 = 30f,
                m01 = 01f, m11 = 11f, m21 = 21f, m31 = 31f,
                m02 = 02f, m12 = 12f, m22 = 22f, m32 = 32f,
                m03 = 03f, m13 = 13f, m23 = 23f, m33 = 33f,
            }),
        };
    }
}
