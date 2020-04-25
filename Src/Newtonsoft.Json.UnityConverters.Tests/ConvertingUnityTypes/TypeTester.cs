using System;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public abstract class TypeTesterBase
    {
        protected virtual void ConfigureSettings(JsonSerializerSettings settings)
        {
            // No settings changes by default
        }

        protected JsonSerializerSettings GetSettings()
        {
            JsonSerializerSettings settings = UnityConverterInitializer.GetDefaultUnitySettings();
            settings.Formatting = Formatting.None;
            ConfigureSettings(settings);
            return settings;
        }

        protected TypeTesterBase()
        {
        }
    }

    public abstract class TypeTester<T> : TypeTesterBase
    {
        protected virtual bool AreEqual(T a, T b)
        {
            return a.Equals(b);
        }

        protected virtual string ToString(T value)
        {
            return value?.ToString() ?? "<null>";
        }

        protected void AssertAreEqual(T expected, T actual)
        {
            if (!AreEqual(expected, actual))
            {
                Assert.Fail($"Expected: <{ToString(expected)}>\n" +
                    $"  But was:  <{ToString(actual)}>");
            }
        }

        [Test]
        [TestCaseSource("representations")]
        public void SerializesAsExpected((T input, object anonymous) representation)
        {
            // Arrange
            JsonSerializerSettings settings = GetSettings();
            string expected = JObject.FromObject(representation.anonymous).ToString(Formatting.None);

            // Act
            string result = JsonConvert.SerializeObject(representation.input, settings);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCaseSource("representations")]
        public void DeserializesAsExpected((T expected, object anonymous) representation)
        {
            // Arrange
            JsonSerializerSettings settings = GetSettings();
            string input = JsonConvert.SerializeObject(representation.anonymous, Formatting.None);

            // Act
            T result = JsonConvert.DeserializeObject<T>(input, settings);

            // Assert
            AssertAreEqual(representation.expected, result);
        }

        [Test]
        [TestCaseSource("representations")]
        public void SerializesArrayAsExpected((T input, object anonymous) representation)
        {
            // Arrange
            JsonSerializerSettings settings = GetSettings();
            string expected = JsonConvert.SerializeObject(new [] { representation.anonymous }, Formatting.None);
            T[] input = new[] { representation.input };

            // Act
            string result = JsonConvert.SerializeObject(input, settings);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCaseSource("representations")]
        public void DeserializesArrayAsExpected((T expected, object anonymous) representation)
        {
            // Arrange
            JsonSerializerSettings settings = GetSettings();
            string input = JArray.FromObject(new [] { representation.anonymous }).ToString(Formatting.None);

            // Act
            T[] result = JsonConvert.DeserializeObject<T[]>(input, settings);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length, "result.Length");
            AssertAreEqual(representation.expected, result[0]);
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
            JsonSerializerSettings settings = GetSettings();
            string expected = JObject.FromObject(representation.anonymous).ToString(Formatting.None);

            // Act
            string result = JsonConvert.SerializeObject(new T?(representation.input), settings);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCaseSource("representations")]
        public void DeserializesNullableValueAsExpected((T expected, object anonymous) representation)
        {
            // Arrange
            JsonSerializerSettings settings = GetSettings();
            string input = JsonConvert.SerializeObject(representation.anonymous, Formatting.None);

            // Act
            T? result = JsonConvert.DeserializeObject<T?>(input, settings);

            // Assert
            AssertAreEqual(representation.expected, result.Value);
        }

        [Test]
        public void DeserializesNullableNullAsExpected()
        {
            // Arrange
            JsonSerializerSettings settings = GetSettings();

            // Act
            T? result = JsonConvert.DeserializeObject<T?>("null", settings);

            // Assert
            Assert.IsNull(result);
        }
    }
}
