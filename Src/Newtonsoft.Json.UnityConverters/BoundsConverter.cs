
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
    public class BoundsConverter : PartialVector3Converter<Bounds>
    {
        private static string[] _memberNames = { "center", "size" };

        public BoundsConverter()
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
            _ = dummy.size;
        }

        protected override Bounds CreateInstanceFromValues(ValuesArray<Vector3> values)
        {
            return new Bounds(values[0], values[1]);
        }

        protected override Vector3[] ReadInstanceValues(Bounds instance)
        {
            return new[] { instance.center, instance.size };
        }
    }
}
