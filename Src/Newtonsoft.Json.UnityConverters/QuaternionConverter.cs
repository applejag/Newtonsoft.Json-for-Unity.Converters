
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity Quaternion type <see cref="Quaternion"/>.
    /// </summary>
    public class QuaternionConverter : PartialFloatConverter<Quaternion>
    {
        private static readonly string[] _memberNames = { "x", "y", "z", "w" };

        public QuaternionConverter()
            : base(_memberNames)
        {
        }

        protected override Quaternion CreateInstanceFromValues(ValuesArray<float> values)
        {
            return new Quaternion(values[0], values[1], values[2], values[3]);
        }

        protected override float[] ReadInstanceValues(Quaternion instance)
        {
            return new[] {
                instance.x, instance.y, instance.z, instance.w
            };
        }
    }
}
