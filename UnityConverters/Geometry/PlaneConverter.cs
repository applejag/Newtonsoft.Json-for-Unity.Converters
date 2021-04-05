using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Geometry
{
    public class PlaneConverter : PartialConverter<Plane>
    {
        protected override void ReadValue(ref Plane value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.normal):
                    value.normal = reader.ReadViaSerializer<Vector3>(serializer);
                    break;
                case nameof(value.distance):
                    value.distance = reader.ReadAsFloat() ?? 0;
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, Plane value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.normal));
            serializer.Serialize(writer, value.normal, typeof(Vector3));
            writer.WritePropertyName(nameof(value.distance));
            writer.WriteValue(value.distance);
        }
    }
}
