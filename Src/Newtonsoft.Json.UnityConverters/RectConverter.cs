
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity Rect type <see cref="Rect"/>.
    /// </summary>
    public class RectConverter : PartialFloatConverter<Rect>
    {
        internal static readonly string[] _memberNames = { "x", "y", "width", "height" };

        public RectConverter()
            : base(_memberNames)
        {
        }

        protected override Rect CreateInstanceFromValues(ValuesArray<float> values)
        {
            return new Rect(values[0], values[1], values[2], values[3]);
        }

        protected override float[] ReadInstanceValues(Rect instance)
        {
            return new[] { instance.x, instance.y, instance.width, instance.height };
        }
    }
}
