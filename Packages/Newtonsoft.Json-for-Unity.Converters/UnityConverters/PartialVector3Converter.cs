using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for a type containing only Unitys Vector3 type <see cref="Vector3"/>,
    /// </summary>
    public abstract class PartialVector3Converter<T> : PartialConverter<T, Vector3>
    {
        protected PartialVector3Converter(string[] propertyNames) : base(propertyNames)
        {
        }

        protected override Vector3 ReadValue(JsonReader reader, int index, JsonSerializer serializer)
        {
            return reader.ReadViaSerializer<Vector3>(serializer);
        }

        protected override void WriteValue(JsonWriter writer, Vector3 value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(Vector3));
        }
    }
}
