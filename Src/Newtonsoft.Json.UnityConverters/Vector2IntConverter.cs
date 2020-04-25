
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity Vector2Int type <see cref="Vector2Int"/>.
    /// </summary>
    public class Vector2IntConverter : PartialIntConverter<Vector2Int>
    {
        public Vector2IntConverter() : base(Vector2Converter._memberNames)
        {
        }

        protected override Vector2Int CreateInstanceFromValues(int[] values)
        {
            return new Vector2Int(values[0], values[1]);
        }

        protected override int[] ReadInstanceValues(Vector2Int instance)
        {
            return new int[] { instance.x, instance.y };
        }
    }
}
