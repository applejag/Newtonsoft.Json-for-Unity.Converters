using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace Newtonsoft.Json.UnityConverters.Helpers
{
    internal static class JsonHelperExtensions
    {
        public static JsonSerializationException CreateSerializationException(this JsonReader reader, string message, [AllowNull] Exception innerException = null)
        {
            StringBuilder builder = CreateStringBuilderWithSpaceAfter(message);

            builder.AppendFormat(CultureInfo.InvariantCulture, "Path '{0}'", reader.Path);

            var lineInfo = reader as IJsonLineInfo;
            int lineNumber = default;
            int linePosition = default;

            if (lineInfo?.HasLineInfo() == true)
            {
                lineNumber = lineInfo.LineNumber;
                linePosition = lineInfo.LinePosition;
                builder.AppendFormat(CultureInfo.InvariantCulture, ", line {0}, position {1}", lineNumber, linePosition);
            }

            builder.Append('.');

            return new JsonSerializationException(
                message: builder.ToString(), reader.Path, lineNumber, linePosition, innerException);
        }

        public static JsonWriterException CreateWriterException(this JsonWriter writer, string message, [AllowNull] Exception innerException = null)
        {
            StringBuilder builder = CreateStringBuilderWithSpaceAfter(message);

            builder.AppendFormat(CultureInfo.InvariantCulture, "Path '{0}'.", writer.Path);

            return new JsonWriterException(
                message: builder.ToString(), writer.Path, innerException);
        }

        private static StringBuilder CreateStringBuilderWithSpaceAfter(string message)
        {
            var builder = new StringBuilder(message);

            if (message.EndsWith("."))
            {
                builder.Append(' ');
            }
            else if (!message.EndsWith(". "))
            {
                builder.Append(". ");
            }

            return builder;
        }

        [return: MaybeNull]
        public static T ReadViaSerializer<T>(this JsonReader reader, JsonSerializer serializer)
        {
            reader.Read();
            return serializer.Deserialize<T>(reader);
        }

        public static float? ReadAsFloat(this JsonReader reader)
        {
            return (float?)reader.ReadAsDouble();
        }

        public static byte? ReadAsInt8(this JsonReader reader)
        {
            return checked((byte)(reader.ReadAsInt32() ?? 0));
        }
    }
}
