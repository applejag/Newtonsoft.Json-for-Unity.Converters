
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

using UnityEngine;

namespace WanzyeeStudio.Json
{

    /// <summary>
    /// Custom <c>Newtonsoft.Json.JsonConverter</c> for <c>UnityEngine.Color</c>.
    /// </summary>
    public class ColorConverter : PartialConverter<Color>
    {

        /// <summary>
        /// Get the property names include <c>r</c>, <c>g</c>, <c>b</c>, <c>a</c>.
        /// </summary>
        /// <returns>The property names.</returns>
        protected override string[] GetPropertyNames()
        {
            return new[] { "r", "g", "b", "a" };
        }

    }

}
