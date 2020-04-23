
/*WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW*\     (   (     ) )
|/                                                      \|       )  )   _((_
||  (c) Wanzyee Studio  < wanzyeestudio.blogspot.com >  ||      ( (    |_ _ |=n
|\                                                      /|   _____))   | !  ] U
\.ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ./  (_(__(S)   |___*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
    public abstract class PartialConverter<T> : JsonConverter
    {

        #region Static Methods

        /// <summary>
        /// Get the field or property of the specified <c>name</c>.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="name">Name.</param>
        private static MemberInfo GetMember(string name)
        {
            BindingFlags flag = BindingFlags.Instance | BindingFlags.Public;

            FieldInfo field = typeof(T).GetField(name, flag);
            if (null != field)
            {
                return field;
            }

            PropertyInfo property = typeof(T).GetProperty(name, flag);
            if (null == property)
            {
                throw Error(name, "Public instance field or property {0} is not found.");
            }

            if (null == property.GetGetMethod())
            {
                throw Error(name, "Property {0} is not readable.");
            }

            if (null == property.GetSetMethod())
            {
                throw Error(name, "Property {0} is not writable.");
            }

            if (property.GetIndexParameters().Any())
            {
                throw Error(name, "Not support property {0} with indexes.");
            }

            return property;

        }

        /// <summary>
        /// Throw an exception of the specified message formatted with the member name.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="format">Format.</param>
        private static ArgumentException Error(string name, string format)
        {
            return new ArgumentException(string.Format(format, $"{typeof(T).Name}.{name}"), nameof(name));
        }

        /// <summary>
        /// Get the value from the member.
        /// </summary>
        /// <returns>The value.</returns>
        /// <param name="member">Member.</param>
        /// <param name="target">Target.</param>
        private static object GetMemberValue(MemberInfo member, object target)
        {
            if (member is FieldInfo field)
            {
                return field.GetValue(target);
            }
            else
            {
                return (member as PropertyInfo).GetValue(target, null);
            }
        }

        /// <summary>
        /// Set the value to the member.
        /// </summary>
        /// <param name="member">Member.</param>
        /// <param name="target">Target.</param>
        /// <param name="value">Value.</param>
        private static void SetValue(MemberInfo member, object target, object value)
        {
            if (member is FieldInfo)
            {
                (member as FieldInfo).SetValue(target, value);
            }
            else
            {
                (member as PropertyInfo).SetValue(target, value, null);
            }
        }

        /// <summary>
        /// Get the value type of the member.
        /// </summary>
        /// <returns>The value type.</returns>
        /// <param name="member">Member.</param>
        private static Type GetValueType(MemberInfo member)
        {
            if (member is FieldInfo)
            {
                return (member as FieldInfo).FieldType;
            }
            else
            {
                return (member as PropertyInfo).PropertyType;
            }
        }

        #endregion


        #region Fields

        /// <summary>
        /// The stored property names with the member.
        /// </summary>
        private static Dictionary<string, MemberInfo> _properties;

        #endregion


        #region Methods

        /// <summary>
        /// Gets the property names paired with the accessing member.
        /// </summary>
        /// <returns>The properties.</returns>
        private Dictionary<string, MemberInfo> GetProperties()
        {
            if (_properties != null)
            {
                return _properties;
            }

            string[] names = GetPropertyNames();

            if (names?.Any() != true)
            {
                throw new InvalidProgramException("GetPropertyNames() cannot return empty.");
            }

            if (names.Any((name) => string.IsNullOrEmpty(name)))
            {
                throw new InvalidProgramException("GetPropertyNames() cannot contain empty value.");
            }

            _properties = names.Distinct().ToDictionary((name) => name, (name) => GetMember(name));
            return _properties;

        }

        /// <summary>
        /// Get the property names to serialize, only used once when initializing.
        /// </summary>
        /// <returns>The property names.</returns>
        protected abstract string[] GetPropertyNames();

        /// <summary>
        /// Create the instance for <c>ReadJson()</c> to populate.
        /// </summary>
        /// <returns>The instance.</returns>
        protected virtual T CreateInstance()
        {
            return Activator.CreateInstance<T>();
        }

        /// <summary>
        /// Determine if the object type is <c>T</c>.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if this can convert the specified type; otherwise, <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(T) == objectType;
        }

        /// <summary>
        /// Read the specified properties to the object.
        /// </summary>
        /// <returns>The object value.</returns>
        /// <param name="reader">The <c>Newtonsoft.Json.JsonReader</c> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /*
		 * Force the instance as an object reference, otherwise this may reflect to a wrong copy if the T is struct.
		 * But keep the CreateInstance() to return T for safer overriding.
		 */
        public override object? ReadJson(
            JsonReader reader,
            Type objectType,
            object? existingValue,
            JsonSerializer serializer)
        {
            if (JsonToken.Null == reader.TokenType)
            {
                return null;
            }

            var jObject = JObject.Load(reader);
            object? result = CreateInstance() as object;

            foreach (KeyValuePair<string, MemberInfo> pair in GetProperties())
            {
                object? value = jObject[pair.Key].ToObject(GetValueType(pair.Value), serializer);
                SetValue(pair.Value, result, value);
            }

            return result;
        }

        /// <summary>
        /// Write the specified properties of the object.
        /// </summary>
        /// <param name="writer">The <c>Newtonsoft.Json.JsonWriter</c> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var jObject = new JObject();

            foreach (KeyValuePair<string, MemberInfo> pair in GetProperties())
            {
                object memberValue = GetMemberValue(pair.Value, value);
                jObject[pair.Key] = JToken.FromObject(memberValue, serializer);
            }

            jObject.WriteTo(writer);
        }

        #endregion

    }

}
