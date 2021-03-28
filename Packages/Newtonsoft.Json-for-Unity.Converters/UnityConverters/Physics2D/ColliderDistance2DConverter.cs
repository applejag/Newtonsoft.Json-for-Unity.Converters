using System;
using System.Reflection;
using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Physics2D
{
    public class ColliderDistance2DConverter : PartialConverter<ColliderDistance2D>
    {
        protected override void ReadValue(ref ColliderDistance2D value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch(name)
            {
                case nameof(value.pointA):
                    value.pointA = reader.ReadViaSerializer<Vector2>(serializer);
                    break;
                case nameof(value.pointB):
                    value.pointB = reader.ReadViaSerializer<Vector2>(serializer);
                    break;
                case nameof(value.distance):
                    value.distance = reader.ReadAsFloat() ?? 0;
                    break;
                case nameof(value.isValid):
                    value.isValid = reader.ReadAsBoolean() ?? false;
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, ColliderDistance2D value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.pointA));
            writer.WriteValue(value.pointA);
            writer.WritePropertyName(nameof(value.pointB));
            writer.WriteValue(value.pointB);
            writer.WritePropertyName(nameof(value.distance));
            writer.WriteValue(value.distance);
            writer.WritePropertyName(nameof(value.isValid));
            writer.WriteValue(value.isValid);
        }
    }
}
