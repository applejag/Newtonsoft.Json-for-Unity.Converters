
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity Vector4 type <see cref="Vector4"/>.
    /// </summary>
    public class Vector4Converter : PartialFloatConverter<Vector4>
    {
        private static readonly string[] _memberNames = { "x", "y", "z", "w" };

        public Vector4Converter() : base(_memberNames)
        {
        }

        protected override Vector4 CreateInstanceFromValues(ValuesArray<float> values)
        {
            return new Vector4(values[0], values[1], values[2], values[3]);
        }

        protected override float[] ReadInstanceValues(Vector4 instance)
        {
            return new float[] { instance.x, instance.y, instance.z, instance.w };
        }
    }
}
