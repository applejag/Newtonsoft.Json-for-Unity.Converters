﻿using System;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    public class PlaneConverter : PartialConverter<Plane, object>
    {
        private static readonly string[] _memberNames = { "normal", "distance" };

        public PlaneConverter() : base(_memberNames)
        {
        }

        protected override Plane CreateInstanceFromValues(object[] values)
        {
            return new Plane((Vector3)values[0], (float)values[1]);
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
            switch (value)
            {
            case float num:
                writer.WriteValue(num);
                break;

            default:
                serializer.Serialize(writer, value);
                break;
            }
        }
    }
}
