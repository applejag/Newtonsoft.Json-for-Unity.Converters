
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom base <c>Newtonsoft.Json.JsonConverter</c> to filter serialized properties.
    /// </summary>
    /// 
    /// <remarks>
    /// Useful for Unity or 3rd party classes, since we can't insert any <c>Newtonsoft.Json.JsonIgnoreAttribute</c>.
    /// By the way, this works by reflection to access properties.
    /// Please make sure your property not to be stripped by Unity.
    /// </remarks>
    /// 
    /// <example>
    /// It's very easy to make a custom converter, just inherit and override <c>GetPropertyNames()</c> as the filter:
    /// </example>
    /// 
    /// <code>
    /// public class SomeConverter : PartialConverter<SomeClass>{
    /// 	protected override string[] GetPropertyNames(){
    /// 		return new []{"someField", "someProperty", "etc"};
    /// 	}
    /// }
    /// </code>
    /// 
    public abstract class PartialConverter<T, TInner> : JsonConverter
    {
        private readonly Dictionary<string, int> _namesIndices;
        private readonly string[] _namesArray;

        /// <summary>
        /// Initializes this converter with the set of fields/properties to
        /// read/write to the object.
        /// </summary>
        /// <param name="propertyNames">The list of values.</param>
        protected PartialConverter(string[] propertyNames)
        {
            _namesArray = propertyNames.ToArray(); // Intentionally make a copy of the array

            _namesIndices = new Dictionary<string, int>(_namesArray.Length);

            for (int i = 0; i < _namesArray.Length; i++)
            {
                _namesIndices[_namesArray[i]] = i;
            }
        }

        /// <summary>
        /// Create the instance with the given values.
        /// </summary>
        /// <param name="values">The values read from the object. Known to have the same size as number of elements fed through the constructor.</param>
        /// <returns>The instance.</returns>
        protected abstract T CreateInstanceFromValues(TInner[] values);

        /// <summary>
        /// Read the values off from the given instance.
        /// The returned list must have the same number of elements as elements fed through the constructor.
        /// </summary>
        /// <param name="instance">The instance to read the values off.</param>
        /// <returns>The values.</returns>
        protected abstract TInner[] ReadInstanceValues(T instance);

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
        /// Determine if the object type is <typeparamref name="T"/>
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if this can convert the specified type; otherwise, <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T)
                || (objectType.IsGenericType
                    && objectType.GetGenericTypeDefinition() == typeof(Nullable<>)
                    && objectType.GenericTypeArguments[0] == typeof(T));
        }

        /// <summary>
        /// Read the specified properties to the object.
        /// </summary>
        /// <returns>The object value.</returns>
        /// <param name="reader">The <c>Newtonsoft.Json.JsonReader</c> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override object? ReadJson(
            JsonReader reader,
            Type objectType,
            object? existingValue,
            JsonSerializer serializer)
        {
            bool isNullableStruct = objectType.IsGenericType
                && objectType.GetGenericTypeDefinition() == typeof(Nullable<>);

            return InternalReadJson(reader, serializer, isNullableStruct);
        }

        private object? InternalReadJson(JsonReader reader, JsonSerializer serializer, bool isNullableStruct)
        {

            if (reader.TokenType == JsonToken.Null)
            {
                return CreateValueForNull(isNullableStruct);
            }

            if (reader.TokenType != JsonToken.StartObject)
            {
                throw reader.CreateSerializationException($"Failed to read type '{typeof(T).Name}'. Expected object start, got '{reader.TokenType}' <{reader.Value}>");
            }

            reader.Read();

            var values = new TInner[_namesArray.Length];
            int previousIndex = -1;

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

        private object? CreateValueForNull(bool isNullableStruct)
        {
            if (isNullableStruct)
            {
                return null;
            }
            else
            {
                var values = new TInner[_namesArray.Length];
                return CreateInstanceFromValues(values);
            }
        }

        /// <summary>
        /// Write the specified properties of the object.
        /// </summary>
        /// <param name="writer">The <c>Newtonsoft.Json.JsonWriter</c> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            writer.WriteStartObject();

            var typed = (T)value;

            TInner[] values = ReadInstanceValues(typed);

            if (values?.Length != _namesArray.Length)
            {
                throw writer.CreateWriterException(string.Format("Expected {0}() to return {1} values, matching [{2}]. Got {3}",
                    nameof(ReadInstanceValues),
                    _namesArray.Length,
                    string.Join(", ", _namesArray),
                    values?.Length.ToString() ?? "null")
                );
            }

            for (int i = 0; i < _namesArray.Length; i++)
            {
                string name = _namesArray[i];
                writer.WritePropertyName(name);
                WriteValue(writer, values[i], serializer);
            }

            writer.WriteEndObject();
        }
    }
}
