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
    public class RectOffsetConverter : PartialConverter<RectOffset>
    {
        protected override void ReadValue(ref RectOffset value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.left):
                    value.left = reader.ReadAsInt32() ?? 0;
                    break;
                case nameof(value.right):
                    value.right = reader.ReadAsInt32() ?? 0;
                    break;
                case nameof(value.top):
                    value.top = reader.ReadAsInt32() ?? 0;
                    break;
                case nameof(value.bottom):
                    value.bottom = reader.ReadAsInt32() ?? 0;
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, RectOffset value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.left));
            writer.WriteValue(value.left);
            writer.WritePropertyName(nameof(value.right));
            writer.WriteValue(value.right);
            writer.WritePropertyName(nameof(value.top));
            writer.WriteValue(value.top);
            writer.WritePropertyName(nameof(value.bottom));
            writer.WriteValue(value.bottom);
        }
    }
}
