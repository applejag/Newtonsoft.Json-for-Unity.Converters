
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity Vector3Int type <see cref="Vector3Int"/>.
    /// </summary>
    public class Vector3IntConverter : PartialIntConverter<Vector3Int>
    {
        public Vector3IntConverter() : base(Vector3Converter._memberNames)
        {
        }

        protected override Vector3Int CreateInstanceFromValues(int[] values)
        {
            return new Vector3Int(values[0], values[1], values[2]);
        }

        protected override int[] ReadInstanceValues(Vector3Int instance)
        {
            return new int[] { instance.x, instance.y, instance.z };
        }
    }
}
