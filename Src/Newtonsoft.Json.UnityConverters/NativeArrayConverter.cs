using System;
using System.Collections;
using System.Globalization;
using System.Text;
using Unity.Collections;

namespace Newtonsoft.Json.UnityConverters.Converters
{
    public class NativeArrayConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is null)
            {
                writer.WriteNull();
                return;
            }
            
            var enumerable = (IEnumerable)value;
            writer.WriteStartArray();
            foreach (object item in enumerable)
            {
                serializer.Serialize(writer, item);
            }
            writer.WriteEndArray();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var lineInfo = reader as IJsonLineInfo;
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

        public override bool CanConvert(Type objectType)
        {
            if (objectType.IsGenericType)
            {
                return objectType.GetGenericTypeDefinition() == typeof(NativeArray<>);
            }
            else
            {
                return false;
            }
        }
    }
}