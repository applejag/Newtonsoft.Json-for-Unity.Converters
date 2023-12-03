using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Newtonsoft.Json.UnityConverters.Helpers
{
    internal static class JsonHelperExtensions
    {
        /// <summary>
        /// This refers to the ctor that lets you specify the line number and
        /// position that was introduced in Json.NET v12.0.1.
        /// <see cref="JsonSerializationException.JsonSerializationException(string, string, int, int, Exception)"/>
        /// <see href="https://github.com/JamesNK/Newtonsoft.Json/blob/12.0.1/Src/Newtonsoft.Json/JsonSerializationException.cs#L110"/>
        /// </summary>
        internal static readonly ConstructorInfo _JsonSerializationExceptionPositionalCtor
            = typeof(JsonSerializationException).GetConstructor(new[] {
                typeof(string), typeof(string), typeof(int), typeof(int), typeof(Exception)
            });

        private static JsonSerializationException NewJsonSerializationException(string message, string path, int lineNumber, int linePosition, [AllowNull] Exception innerException)
        {
            if (_JsonSerializationExceptionPositionalCtor != null)
            {
                return (JsonSerializationException)_JsonSerializationExceptionPositionalCtor.Invoke(new object[] {
                    message, path, lineNumber, linePosition, innerException
                });
            }
            else
            {
                return new JsonSerializationException(message, innerException);
            }
        }

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

            return NewJsonSerializationException(
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
            // https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/issues/46

            var str = reader.ReadAsString();

            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            else if (float.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out var valueParsed))
            {
                return valueParsed;
            }
            else
            {
                return 0f;
            }
        }

        public static byte? ReadAsInt8(this JsonReader reader)
        {
            return checked((byte)(reader.ReadAsInt32() ?? 0));
        }
    }
}
