
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

using System.Linq;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{

    /// <summary>
    /// Custom <c>Newtonsoft.Json.JsonConverter</c> for <c>UnityEngine.Matrix4x4</c>.
    /// </summary>
    public class Matrix4x4Converter : PartialConverter<Matrix4x4>
    {

        /// <summary>
        /// Get the property names include from <c>m00</c> to <c>m33</c>.
        /// </summary>
        /// <returns>The property names.</returns>
        protected override string[] GetPropertyNames()
        {
            string[] indexes = new[] { "0", "1", "2", "3" };
            return indexes.SelectMany((row) => indexes.Select((column) => "m" + row + column)).ToArray();
        }

    }

}
