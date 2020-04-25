
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity RectOffset type <see cref="RectOffset"/>.
    /// </summary>
    public class RectOffsetConverter : IntObjectConverter<RectOffset>
    {
        private static readonly string[] _memberNames = { "left", "right", "top", "bottom" };

        public RectOffsetConverter()
            : base(_memberNames)
        {
        }

        protected override RectOffset CreateInstanceFromValues(int[] values)
        {
            return new RectOffset(values[0], values[1], values[2], values[3]);
        }

        protected override int[] ReadInstanceValues(RectOffset instance)
        {
            return new[] { instance.left, instance.right, instance.top, instance.bottom };
        }
    }
}
