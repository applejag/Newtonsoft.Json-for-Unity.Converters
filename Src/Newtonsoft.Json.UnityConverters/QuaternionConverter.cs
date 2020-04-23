﻿using System;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    public class QuaternionConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is null)
            {
                writer.WriteNull();
                return;
            }

            var qt = (Quaternion)value;
            writer.WriteStartObject();
            writer.WritePropertyName("x");
            writer.WriteValue(qt.x);
            writer.WritePropertyName("y");
            writer.WriteValue(qt.y);
            writer.WritePropertyName("z");
            writer.WriteValue(qt.z);
            writer.WritePropertyName("w");
            writer.WriteValue(qt.w);
            writer.WriteEndObject();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Quaternion);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            var result = new Quaternion();
            JToken? token;

            if (obj.TryGetValue("w", out token))
            {
                result.w = token.Value<float>();
            }

            if (obj.TryGetValue("x", out token))
            {
                result.x = token.Value<float>();
            }

            if (obj.TryGetValue("y", out token))
            {
                result.y = token.Value<float>();
            }

            if (obj.TryGetValue("z", out token))
            {
                result.z = token.Value<float>();
            }

            if (obj.TryGetValue("eulerAngles", out token))
            {
                var eulerVec = new Vector3(
                    token.Value<float>("x"),
                    token.Value<float>("y"),
                    token.Value<float>("z")
                );

                result.eulerAngles = eulerVec;
            }

            return result;
        }

        public override bool CanRead => true;
    }
}
