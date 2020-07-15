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

using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Math
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity Vector3 type <see cref="Vector3"/>.
    /// </summary>
    public class Vector3Converter : PartialFloatConverter<Vector3>
    {
        internal static readonly string[] _memberNames = { "x", "y", "z" };

        public Vector3Converter() : base(_memberNames)
        {
        }

        protected override Vector3 CreateInstanceFromValues(ValuesArray<float> values)
        {
            return new Vector3(values[0], values[1], values[2]);
        }

        protected override float[] ReadInstanceValues(Vector3 instance)
        {
            return new float[] { instance.x, instance.y, instance.z };
        }
    }
}
