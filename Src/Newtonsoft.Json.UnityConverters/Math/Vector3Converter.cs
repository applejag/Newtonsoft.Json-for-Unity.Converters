
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

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
