using System;
using System.Globalization;
using System.Text;

namespace Newtonsoft.Json.UnityConverters
{
    internal static class ExceptionHelper
    {
        public static JsonSerializationException CreateSerializationException(this JsonReader reader, string message, Exception? innerException = null)
        {
            var lineInfo = reader as IJsonLineInfo;
            int lineNumber = default;
            int linePosition = default;

            var builder = new StringBuilder(message);

            if (message.EndsWith("."))
            {
                builder.Append(' ');
            }
            else if (!message.EndsWith(". "))
            {
                builder.Append(". ");
            }

            builder.AppendFormat(CultureInfo.InvariantCulture, "Path '{0}'", reader.Path);

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

        public static JsonWriterException CreateWriterException(this JsonWriter writer, string message, Exception? innerException = null)
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

            builder.AppendFormat(CultureInfo.InvariantCulture, "Path '{0}'.", writer.Path);

            return new JsonWriterException(
                message: builder.ToString(), writer.Path, innerException);
        }
    }
}
