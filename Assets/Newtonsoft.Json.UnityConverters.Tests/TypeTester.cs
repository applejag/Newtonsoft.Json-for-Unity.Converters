using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using Newtonsoft.Json.Utilities;
using NUnit.Framework;

namespace Newtonsoft.Json.UnityConverters.Tests
{
    public abstract class TypeTesterBase
    {
        protected readonly JsonSerializer _serializer;

        protected TypeTesterBase()
        {
            _serializer = JsonSerializer.Create(UnityConverterInitializer.defaultUnityConvertersSettings);
        }

        [OneTimeSetUp]
        public void SetUpSerializer()
        {
            ConfigureSerializer(_serializer);
        }

        protected virtual void ConfigureSerializer(JsonSerializer serializer)
        {
            // No settings changes by default
        }

        protected string Serialize([AllowNull] object value)
        {
            return Serialize(value, _serializer);
        }

        protected static string Serialize([AllowNull] object value, JsonSerializer serializer)
        {
            var builder = new StringBuilder();
            serializer.Serialize(new JsonTextWriter(new StringWriter(builder)), value);
            return builder.ToString();
        }

        [return: MaybeNull]
        protected object Deserialize(string json)
        {
            return Deserialize(json, _serializer);
        }

        [return: MaybeNull]
        protected static object Deserialize(string json, JsonSerializer serializer)
        {
            return serializer.Deserialize(new JsonTextReader(new StringReader(json)));
        }

        [return: MaybeNull]
        protected T Deserialize<T>(string json)
        {
            return Deserialize<T>(json, _serializer);
        }

        [return: MaybeNull]
        protected static T Deserialize<T>(string json, JsonSerializer serializer)
        {
            return serializer.Deserialize<T>(new JsonTextReader(new StringReader(json)));
        }

        protected void Populate(string json, object existingValue)
        {
            Populate(json, existingValue, _serializer);
        }

        protected void Populate(string json, object existingValue, JsonSerializer serializer)
        {
            serializer.Populate(new JsonTextReader(new StringReader(json)), existingValue);
        }

        public static string GetTypeNameWithAssembly(Type type)
        {
            string assemblyName = type.Assembly.FullName;
            int assemblyNameSeparator = assemblyName.IndexOf(',');
            if (assemblyNameSeparator != -1)
            {
                assemblyName = assemblyName.Substring(0, assemblyNameSeparator);
            }

            return $"{type.FullName}, {assemblyName}";
        }
    }

    public abstract class TypeTester<T> : TypeTesterBase
    {
        protected TypeTester()
        {
            AotHelper.EnsureList<T>();
        }

        protected virtual bool AreEqual([AllowNull] T a, [AllowNull] T b)
        {
            return Equals(a, b);
        }

        protected virtual string ToString([AllowNull] T value)
        {
            return value?.ToString() ?? "<null>";
        }

        protected void AssertAreEqual(T expected, [AllowNull] T actual)
        {
            AssertAreEqual(expected, actual, null);
        }

        protected void AssertAreEqual(T expected, [AllowNull] T actual, [AllowNull] string message)
        {
            if (!AreEqual(expected, actual))
            {
                Assert.Fail($"Expected: <{ToString(expected)}> (serialized: {Serialize(expected)})\n" +
                    $"  But was:  <{ToString(actual)}> (serialized: {Serialize(actual)})" +
                    (string.IsNullOrEmpty(message) ? string.Empty : $"\n  {message}"));
            }
        }

        [Test]
        [TestCaseSource("representations")]
        public virtual void SerializesAsExpected((T input, object anonymous) representation)
        {
            // Arrange
            string expected = Serialize(representation.anonymous);

            // Act
            string result = Serialize(representation.input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCaseSource("representations")]
        public virtual void DeserializesAsExpected((T expected, object anonymous) representation)
        {
            // Arrange
            string input = Serialize(representation.anonymous);
            TestContext.WriteLine($"Input given: '{input}'");

            // Act
            T result = Deserialize<T>(input);

            // Assert
            AssertAreEqual(representation.expected, result, $"Input given: '{input}'");
        }

        [Test]
        [TestCaseSource("representations")]
        public virtual void SerializesArrayAsExpected((T input, object anonymous) representation)
        {
            // Arrange
            string expected = Serialize(new[] { representation.anonymous });
            T[] input = new[] { representation.input };

            // Act
            string result = Serialize(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCaseSource("representations")]
        public virtual void DeserializesArrayAsExpected((T expected, object anonymous) representation)
        {
            // Arrange
            string input = Serialize(new[] { representation.anonymous });

            // Act
            T[] result = Deserialize<T[]>(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length, "result.Length");
            AssertAreEqual(representation.expected, result[0], $"Input given: '{input}'");
        }

        [Test]
        public virtual void OkWithEmptyObject()
        {
            // Arrange
            string input = "{}";

            // Act
            Assert.DoesNotThrow(() =>
            {
                _ = Deserialize(input);
            });
        }
    }

    public abstract class ValueTypeTester<T> : TypeTester<T>
        where T : struct
    {
        [Test]
        [TestCaseSource("representations")]
        public void SerializesNullableAsExpected((T input, object anonymous) representation)
        {
            // Arrange
            string expected = Serialize(representation.anonymous);

            // Act
            string result = Serialize((T?)representation.input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCaseSource("representations")]
        public void DeserializesNullableValueAsExpected((T expected, object anonymous) representation)
        {
            // Arrange
            string input = Serialize(representation.anonymous);

            // Act
            T? result = Deserialize<T?>(input);

            // Assert
            Assert.IsNotNull(result);
            AssertAreEqual(representation.expected, result.Value);
        }

        [Test]
        public void DeserializesNullableNullAsExpected()
        {
            // Act
            T? result = Deserialize<T?>("null");

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void OkWithSerializingNullableNull()
        {
            // Arrange
            var value = new { x = (T?)null };

            // Act
            Assert.DoesNotThrow(() =>
            {
                Serialize(value);
            });
        }
    }
}
