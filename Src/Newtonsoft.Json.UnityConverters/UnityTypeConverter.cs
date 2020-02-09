using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json.Linq;
using Unity.Collections;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Converters {
    public class UnityTypeConverter : JsonConverter
    {
        private static readonly HashSet<Type> UNITY_ENGINE_TYPES = new HashSet<Type>(typeof(UnityEngine.Object).Assembly.GetTypes());

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value != null)
            {
                Type objectType = value.GetType();

                if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(NativeArray<>))
                {
                    var enumerable = (IEnumerable)value;
                    writer.WriteStartArray();
                    foreach (var item in enumerable)
                    {
                        JObject.FromObject(item, serializer).WriteTo(writer);
                    }
                    writer.WriteEndArray();
                    return;
                }
            }

            writer.WriteRawValue(JsonUtility.ToJson(value));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(NativeArray<>))
            {
                IJsonLineInfo? lineInfo = reader as IJsonLineInfo;
                int lineNumber = default;
                int linePosition = default;

                var message = new StringBuilder("Deserializing NativeArray<> is disabled to not cause accidental memory leaks. Use regular List<> or array types instead.");
                message.AppendFormat(CultureInfo.InvariantCulture, "Path '{0}'", reader.Path);

                if (lineInfo?.HasLineInfo() == true)
                {
                    lineNumber = lineInfo.LineNumber;
                    linePosition = lineInfo.LinePosition;
                    message.AppendFormat(CultureInfo.InvariantCulture, ", line {0}, position {1}", lineNumber, linePosition);
                }
                message.Append('.');

                throw new JsonSerializationException(
                    message: message.ToString(), reader.Path, lineNumber, linePosition, null);
            }

            return JsonUtility.FromJson(JObject.Load(reader).ToString(), objectType);
        }

        public override bool CanConvert(Type objectType)
        {
            return IsUnityEngineType(objectType);
        }

        private static bool IsUnityEngineType(Type objectType)
        {
            if (objectType.IsGenericType)
            {
                return UNITY_ENGINE_TYPES.Contains(objectType.GetGenericTypeDefinition());
            }
            else
            {
                return UNITY_ENGINE_TYPES.Contains(objectType);
            }
        }
    }
}
