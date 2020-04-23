
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

using System.Linq;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity Matrix4x4 type <see cref="Matrix4x4"/>.
    /// </summary>
    public class Matrix4x4Converter : FloatObjectConverter<Matrix4x4>
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

        protected override Matrix4x4 CreateInstanceFromValues(float[] values)
        {
            return new Matrix4x4 {
                m00 = values[0], m01 = values[1], m02 = values[2], m03 = values[3],
                m10 = values[4], m11 = values[5], m12 = values[6], m13 = values[7],
                m20 = values[8], m21 = values[9], m22 = values[10], m23 = values[11],
                m30 = values[12], m31 = values[13], m32 = values[14], m33 = values[15],
            };
        }

        protected override float[] ReadInstanceValues(Matrix4x4 instance)
        {
            return new [] {
                instance.m00, instance.m01, instance.m02, instance.m03,
                instance.m10, instance.m11, instance.m12, instance.m13,
                instance.m20, instance.m21, instance.m22, instance.m23,
                instance.m30, instance.m31, instance.m32, instance.m33,
            };
        }
    }
}
