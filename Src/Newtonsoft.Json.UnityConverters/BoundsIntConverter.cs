
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

using UnityEngine;
using UnityEngine.Scripting;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity Bounds type <see cref="Bounds"/>.
    /// </summary>
    public class BoundsIntConverter : Vector3IntObjectConverter<BoundsInt>
    {
        private static string[] _memberNames = { "position", "size" };

        public BoundsIntConverter()
            : base(_memberNames)
        {
        }

        /// <summary>
        /// Prevent the properties from being stripped.
        /// </summary>
        [Preserve]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Code Quality", "IDE0051:Remove unused private members", Justification = "Ensures the properties are preserved, instead of adding a link.xml file.")]
        private static void PreserveProperties()
        {
            var dummy = new Bounds();

            _ = dummy.center;
            _ = dummy.extents;
        }

        protected override BoundsInt CreateInstanceFromValues(Vector3Int[] values)
        {
            return new BoundsInt(values[0], values[1]);
        }

        protected override Vector3Int[] ReadInstanceValues(BoundsInt instance)
        {
            return new[] { instance.position, instance.size };
        }
    }
}
