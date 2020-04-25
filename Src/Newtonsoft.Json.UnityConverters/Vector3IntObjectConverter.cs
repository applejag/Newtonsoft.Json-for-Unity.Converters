using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for a type containing only Unitys integer version of the Vector3 type <see cref="Vector3Int"/>,
    /// </summary>
    public abstract class Vector3IntObjectConverter<T> : PartialConverter<T, Vector3Int>
    {
        protected Vector3IntObjectConverter(string[] propertyNames) : base(propertyNames)
        {
        }

        protected override Vector3Int ReadValue(JsonReader reader, JsonSerializer serializer)
        {
            reader.Read();
            return serializer.Deserialize<Vector3Int>(reader);
        }

        protected override void WriteValue(JsonWriter writer, Vector3Int value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(Vector3Int));
        }
    }
}
