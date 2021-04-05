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

using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Geometry
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity Bounds type <see cref="Bounds"/>.
    /// </summary>
    public class BoundsConverter : PartialConverter<Bounds>
    {
        protected override void ReadValue(ref Bounds value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.center):
                    value.center = reader.ReadViaSerializer<Vector3>(serializer);
                    break;
                case nameof(value.size):
                    value.size = reader.ReadViaSerializer<Vector3>(serializer);
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, Bounds value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.center));
            serializer.Serialize(writer, value.center, typeof(Vector3));
            writer.WritePropertyName(nameof(value.size));
            serializer.Serialize(writer, value.size, typeof(Vector3));
        }
    }
}
