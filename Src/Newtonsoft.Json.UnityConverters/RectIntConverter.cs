
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity RectInt type <see cref="RectInt"/>.
    /// </summary>
    public class RectIntConverter : IntObjectConverter<RectInt>
    {
        internal static readonly string[] _memberNames = { "x", "y", "width", "height" };

        public RectIntConverter()
            : base(_memberNames)
        {
        }

        protected override RectInt CreateInstanceFromValues(int[] values)
        {
            return new RectInt(values[0], values[1], values[2], values[3]);
        }

        protected override int[] ReadInstanceValues(RectInt instance)
        {
            return new[] { instance.x, instance.y, instance.width, instance.height };
        }
    }
}
