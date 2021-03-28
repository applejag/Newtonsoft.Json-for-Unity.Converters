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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.UnityConverters.Helpers;
using Unity.Collections;

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
    public abstract class PartialConverter<T, TValues> : JsonConverter
    {
        protected readonly Dictionary<string, int> _namesIndices;
        protected readonly string[] _namesArray;

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

        protected abstract T ReadJsonProperties(JsonReader reader, JsonSerializer serializer);

        protected abstract void WriteJsonProperties(JsonWriter writer, T value, JsonSerializer serializer);

        /// <summary>
        /// Create the instance with the given values.
        /// </summary>
        /// <param name="values">The values read from the object. Known to have the same size as number of elements fed through the constructor of this PartialConverter.</param>
        /// <returns>The instance.</returns>
        protected abstract T CreateInstanceFromValues(TValues values);

        protected abstract T CreateEmptyInstance();

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
            bool isNullableStruct = objectType.IsGenericType
                && objectType.GetGenericTypeDefinition() == typeof(Nullable<>);

            return InternalReadJson(reader, serializer, isNullableStruct);
        }

        [return: MaybeNull]
        private object InternalReadJson(JsonReader reader, JsonSerializer serializer, bool isNullableStruct)
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

            return ReadJsonProperties(reader, serializer);
        }

        [return: MaybeNull]
        private object CreateValueForNull(bool isNullableStruct)
        {
            if (isNullableStruct)
            {
                return null;
            }
            else
            {
                return CreateEmptyInstance();
            }
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

        /// <summary>
        /// Gets the non-public instance field info <see cref="FieldInfo"/> for the converted type
        /// <typeparamref name="T"/>.
        /// If not found then will throw a missing member exception <see cref="MissingMemberException"/>.
        /// </summary>
        /// <remarks>
        /// If used in static initialization (ex: inside static constructor,
        /// static field, or static property backing field initialization)
        /// and the field does not exist it would invalidate the type for
        /// the entirety of the programs lifetime.
        /// </remarks>
        /// <param name="name">Name of the non-public instance field.</param>
        protected internal static FieldInfo GetFieldInfoOrThrow(string name)
        {
            return typeof(T).GetField(name, BindingFlags.NonPublic | BindingFlags.Instance)
                ?? throw new MissingMemberException(typeof(T).FullName, name);
        }
    }
}
