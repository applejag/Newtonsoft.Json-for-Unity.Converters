
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for a type containing only Unitys Vector3 type <see cref="Vector3"/>,
    /// </summary>
    public abstract class Vector3ObjectConverter<T> : PartialConverter<T, Vector3>
    {
        protected Vector3ObjectConverter(string[] propertyNames) : base(propertyNames)
        {
        }

        protected override Vector3 ReadValue(JsonReader reader, JsonSerializer serializer)
        {
            reader.Read();
            return serializer.Deserialize<Vector3>(reader);
        }

        protected override void WriteValue(JsonWriter writer, Vector3 value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(Vector3));
        }
    }
}
