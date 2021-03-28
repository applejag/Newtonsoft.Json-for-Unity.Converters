
using Newtonsoft.Json.UnityConverters.Helpers;
using Unity.Collections;

namespace Newtonsoft.Json.UnityConverters
{
    public abstract class PartialArrayConverter<T, TInner> : PartialConverter<T, ValuesArray<TInner>>
        where TInner : struct
    {
        public PartialArrayConverter(string[] propertyNames)
            : base(propertyNames)
        {
        }

        /// <summary>
        /// Writes a value directly to the JSON writer. Meant to implement the appropriate WriteValue
        /// <see cref="JsonWriter.WriteValue(object)"/>
        /// for the generic type.
        /// </summary>
        /// <param name="writer">The JSON writer</param>
        /// <param name="value">The value to write</param>
        protected abstract void WriteValue(JsonWriter writer, TInner value, JsonSerializer serializer);

        /// <summary>
        /// Read a value directly from the JSON reader. Meant to implement the appropriate ReadAsX,
        /// (ex: <see cref="JsonReader.ReadAsInt32()"/>)
        /// for the generic type.
        /// </summary>
        /// <param name="reader">The JSON reader</param>
        protected abstract TInner ReadValue(JsonReader reader, int index, JsonSerializer serializer);


        /// <summary>
        /// Read the values off from the given instance.
        /// The returned list must have the same number of elements as elements fed through the constructor.
        /// </summary>
        /// <param name="instance">The instance to read the values off.</param>
        /// <returns>The values.</returns>
        protected abstract ValuesArray<TInner> ReadInstanceValues(T instance, Allocator allocator);

        protected override T ReadJsonProperties(JsonReader reader, JsonSerializer serializer)
        {
            var values = new ValuesArray<TInner>(_namesArray.Length, Allocator.Temp);
            int previousIndex = -1;

            try {
                while (reader.TokenType == JsonToken.PropertyName)
                {
                    if (reader.Value is string name
                        && _namesIndices.TryGetValue(name, out int index))
                    {
                        if (index == previousIndex)
                        {
                            throw reader.CreateSerializationException($"Failed to read type '{typeof(T).Name}'. Possible loop when reading property '{name}'");
                        }

                        previousIndex = index;
                        values[index] = ReadValue(reader, index, serializer);
                    }
                    else
                    {
                        reader.Skip();
                    }

                    reader.Read();
                }

                return CreateInstanceFromValues(values);
            }
            finally
            {
                values.Dispose();
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, T value, JsonSerializer serializer)
        {
            using (var values = ReadInstanceValues(value, Allocator.Temp))
            {
                if (values.Length != _namesArray.Length)
                {
                    throw writer.CreateWriterException(string.Format("Expected {0}() to return {1} values, matching [{2}]. Got {3}",
                        nameof(ReadInstanceValues),
                        _namesArray.Length,
                        string.Join(", ", _namesArray),
                        values.Length.ToString() ?? "null")
                    );
                }

                for (int i = 0; i < _namesArray.Length; i++)
                {
                    string name = _namesArray[i];
                    writer.WritePropertyName(name);
                    WriteValue(writer, values[i], serializer);
                }
            }
        }
    }
}
