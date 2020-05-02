using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for a type containing only Unitys integer version of the Vector3 type <see cref="Vector3Int"/>,
    /// </summary>
    public abstract class PartialVector3IntConverter<T> : PartialConverter<T, Vector3Int>
    {
        protected PartialVector3IntConverter(string[] propertyNames) : base(propertyNames)
        {
        }

        protected override Vector3Int ReadValue(JsonReader reader, int index, JsonSerializer serializer)
        {
            return reader.ReadViaSerializer<Vector3Int>(serializer);
        }

        protected override void WriteValue(JsonWriter writer, Vector3Int value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(Vector3Int));
        }
    }
}
