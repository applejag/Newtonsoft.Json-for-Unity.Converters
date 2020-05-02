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

namespace Newtonsoft.Json.UnityConverters.Geometry
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity RectOffset type <see cref="RectOffset"/>.
    /// </summary>
    public class RectOffsetConverter : PartialIntConverter<RectOffset>
    {
        private static readonly string[] _memberNames = { "left", "right", "top", "bottom" };

        public RectOffsetConverter()
            : base(_memberNames)
        {
        }

        protected override RectOffset CreateInstanceFromValues(ValuesArray<int> values)
        {
            return new RectOffset(values[0], values[1], values[2], values[3]);
        }

        protected override int[] ReadInstanceValues(RectOffset instance)
        {
            return new[] { instance.left, instance.right, instance.top, instance.bottom };
        }
    }
}
