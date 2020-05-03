
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Math
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity Vector2 type <see cref="Vector2"/>.
    /// </summary>
    public class Vector2Converter : PartialFloatConverter<Vector2>
    {
        internal static readonly string[] _memberNames = { "x", "y" };

        public Vector2Converter() : base(_memberNames)
        {
        }

        protected override Vector2 CreateInstanceFromValues(ValuesArray<float> values)
        {
            return new Vector2(values[0], values[1]);
        }

        protected override float[] ReadInstanceValues(Vector2 instance)
        {
            return new float[] { instance.x, instance.y };
        }
    }
}
