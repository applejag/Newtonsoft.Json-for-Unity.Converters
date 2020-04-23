
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

using UnityEngine;

namespace WanzyeeStudio.Json
{

    /// <summary>
    /// Custom <c>Newtonsoft.Json.JsonConverter</c> for <c>UnityEngine.Vector3</c>.
    /// </summary>
    public class Vector3Converter : PartialConverter<Vector3>
    {

        /// <summary>
        /// Get the property names include <c>x</c>, <c>y</c>, <c>z</c>.
        /// </summary>
        /// <returns>The property names.</returns>
        protected override string[] GetPropertyNames()
        {
            return new[] { "x", "y", "z" };
        }

    }

}
