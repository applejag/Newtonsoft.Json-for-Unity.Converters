
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity Color type <see cref="Color"/>.
    /// </summary>
    public class ColorConverter : PartialFloatConverter<Color>
    {
        internal static readonly string[] _memberNames = { "r", "g", "b", "a" };

        public ColorConverter()
            : base(_memberNames)
        {
        }

        protected override Color CreateInstanceFromValues(ValuesArray<float> values)
        {
            return new Color(values[0], values[1], values[2], values[3]);
        }

        protected override float[] ReadInstanceValues(Color instance)
        {
            return new [] { instance.r, instance.g, instance.b, instance.a };
        }
    }
}
