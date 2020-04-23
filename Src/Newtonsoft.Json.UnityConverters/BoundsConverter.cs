
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

using UnityEngine;

namespace WanzyeeStudio.Json
{

    /// <summary>
    /// Custom <c>Newtonsoft.Json.JsonConverter</c> for <c>UnityEngine.Bounds</c>.
    /// </summary>
    public class BoundsConverter : PartialConverter<Bounds>
    {

        /// <summary>
        /// Prevent the properties from being stripped.
        /// </summary>
        /*
		 * https://docs.unity3d.com/Manual/IL2CPP-BytecodeStripping.html
		 * Instead of an extra file, work around by making and accessing a dummy instance.
		 */
        private void PreserveProperties()
        {

            var dummy = new Bounds();

            dummy.center = dummy.center;
            dummy.extents = dummy.extents;

        }

        /// <summary>
        /// Get the property names include <c>center</c>, <c>extents</c>.
        /// </summary>
        /// <returns>The property names.</returns>
        protected override string[] GetPropertyNames()
        {
            return new[] { "center", "extents" };
        }

    }

}
