using System;
using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Geometry
{
    public class PlaneConverter : PartialConverter<Plane, object>
    {
        private static readonly string[] _memberNames = { "normal", "distance" };

        public PlaneConverter() : base(_memberNames)
        {
        }

        protected override Plane CreateInstanceFromValues(ValuesArray<object> values)
        {
            return new Plane(
                values.GetAsTypeOrDefault<Vector3>(0),
                values.GetAsTypeOrDefault<float>(1)
            );
        }

        protected override object[] ReadInstanceValues(Plane instance)
        {
            return new object[] { instance.normal, instance.distance };
        }

        protected override object ReadValue(JsonReader reader, int index, JsonSerializer serializer)
        {
            return index switch
            {
                0 => reader.ReadViaSerializer<Vector3>(serializer),
                1 => (float)(reader.ReadAsDouble() ?? 0),

                _ => throw new ArgumentOutOfRangeException(nameof(index), index, "Only accepts member index in range 0..1")
            };
        }

        protected override void WriteValue(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is float num)
            {
                writer.WriteValue(num);
            }
            else
            {
                serializer.Serialize(writer, value);
            }
        }
    }
}
