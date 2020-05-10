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
using UnityEngine.Scripting;

namespace Newtonsoft.Json.UnityConverters.Geometry
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity Bounds type <see cref="Bounds"/>.
    /// </summary>
    public class BoundsConverter : PartialVector3Converter<Bounds>
    {
        private static string[] _memberNames = { "center", "size" };

        public BoundsConverter()
            : base(_memberNames)
        {
        }

        /// <summary>
        /// Prevent the properties from being stripped.
        /// </summary>
        [Preserve]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Code Quality", "IDE0051:Remove unused private members",
            Justification = "Ensures the properties are preserved, instead of adding a link.xml file.")]
        private static void PreserveProperties()
        {
            var dummy = new Bounds();

            _ = dummy.center;
            _ = dummy.size;
        }

        protected override Bounds CreateInstanceFromValues(ValuesArray<Vector3> values)
        {
            return new Bounds(values[0], values[1]);
        }

        protected override Vector3[] ReadInstanceValues(Bounds instance)
        {
            return new[] { instance.center, instance.size };
        }
    }
}
