#region License
// The MIT License (MIT)
//
// Copyright (c) 2020 Wanzyee Studio
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

using System.Linq;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Math
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity Matrix4x4 type <see cref="Matrix4x4"/>.
    /// </summary>
    public class Matrix4x4Converter : PartialFloatConverter<Matrix4x4>
    {
        private static readonly string[] _memberNames = GetMemberNames();

        public Matrix4x4Converter() : base(_memberNames)
        {
        }

        /// <summary>
        /// Get the property names include from <c>m00</c> to <c>m33</c>.
        /// </summary>
        /// <returns>The property names.</returns>
        private static string[] GetMemberNames()
        {
            string[] indexes = new[] { "0", "1", "2", "3" };
            return indexes.SelectMany((row) => indexes.Select((column) => "m" + row + column)).ToArray();
        }

        protected override Matrix4x4 CreateInstanceFromValues(ValuesArray<float> values)
        {
            return new Matrix4x4 {
                m00 = values[0],
                m01 = values[1],
                m02 = values[2],
                m03 = values[3],
                m10 = values[4],
                m11 = values[5],
                m12 = values[6],
                m13 = values[7],
                m20 = values[8],
                m21 = values[9],
                m22 = values[10],
                m23 = values[11],
                m30 = values[12],
                m31 = values[13],
                m32 = values[14],
                m33 = values[15],
            };
        }

        protected override float[] ReadInstanceValues(Matrix4x4 instance)
        {
            return new[] {
                instance.m00, instance.m01, instance.m02, instance.m03,
                instance.m10, instance.m11, instance.m12, instance.m13,
                instance.m20, instance.m21, instance.m22, instance.m23,
                instance.m30, instance.m31, instance.m32, instance.m33,
            };
        }
    }
}
