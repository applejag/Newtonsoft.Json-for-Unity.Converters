using NUnit.Framework;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public abstract class TypeTesterBase
    {
        protected abstract void ConfigureSettings(JsonSerializerSettings settings);
        protected JsonSerializerSettings GetSettings()
        {
            JsonSerializerSettings settings = UnityTypeConverterInitializer.GetUnityJsonSerializerSettings();
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
        [Test]
        [TestCaseSource("Representations")]
        public void SerializesAsExpected((T input, string expected) representation)
        {
            // Arrange
            JsonSerializerSettings settings = GetSettings();

            // Act
            string result = JsonConvert.SerializeObject(representation.input, settings);

            // Assert
            Assert.AreEqual(representation.expected, result);
        }

        [Test]
        [TestCaseSource("Representations")]
        public void DeserializesAsExpected((T expected, string input) representation)
        {
            // Arrange
            JsonSerializerSettings settings = GetSettings();

            // Act
            T result = JsonConvert.DeserializeObject<T>(representation.input, settings);

            // Assert
            Assert.AreEqual(representation.expected, result);
        }
    }
}
