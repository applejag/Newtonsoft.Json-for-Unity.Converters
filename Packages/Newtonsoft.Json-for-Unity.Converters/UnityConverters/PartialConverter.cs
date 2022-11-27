#region License
// The MIT License (MIT)
//
// Copyright (c) 2020 Wanzyee Studio
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.UnityConverters.Helpers;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom base <c>Newtonsoft.Json.JsonConverter</c> to filter serialized properties.
    /// </summary>
    public abstract class PartialConverter<T> : JsonConverter
        where T : new()
    {
        protected abstract void ReadValue(ref T value, string name, JsonReader reader, JsonSerializer serializer);

        protected abstract void WriteJsonProperties(JsonWriter writer, T value, JsonSerializer serializer);

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
        [return: MaybeNull]
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            [AllowNull] object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                bool isNullableStruct = objectType.IsGenericType
                    && objectType.GetGenericTypeDefinition() == typeof(Nullable<>);

                return isNullableStruct ? null : (object)default(T);
            }

            return InternalReadJson(reader, serializer, existingValue);
        }

        [return: MaybeNull]
        private T InternalReadJson(JsonReader reader, JsonSerializer serializer, [AllowNull] object existingValue)
        {
            if (reader.TokenType != JsonToken.StartObject)
            {
                throw reader.CreateSerializationException($"Failed to read type '{typeof(T).Name}'. Expected object start, got '{reader.TokenType}' <{reader.Value}>");
            }

            reader.Read();

            if (!(existingValue is T value))
            {
                value = new T();
            }
            
            string previousName = null;
            
            while (reader.TokenType == JsonToken.PropertyName)
            {
                if (reader.Value is string name)
                {
                    if (name == previousName)
                    {
                        throw reader.CreateSerializationException($"Failed to read type '{typeof(T).Name}'. Possible loop when reading property '{name}'");
                    }
                    
                    previousName = name;
                    ReadValue(ref value, name, reader, serializer);
                }
                else
                {
                    reader.Skip();
                }

                reader.Read();
            }

            return value;
        }

        /// <summary>
        /// Write the specified properties of the object.
        /// </summary>
        /// <param name="writer">The <c>Newtonsoft.Json.JsonWriter</c> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, [AllowNull] object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            writer.WriteStartObject();

            var typed = (T)value;
            WriteJsonProperties(writer, typed, serializer);

            writer.WriteEndObject();
        }
    }
}
