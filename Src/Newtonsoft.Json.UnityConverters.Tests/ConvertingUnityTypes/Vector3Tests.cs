using NUnit.Framework;
using UnityEngine;

namespace Newtonsoft.Json.Unity.Tests.ConvertingUnityTypes
{
    public class Vector3Tests
    {
        private static JsonSerializerSettings _settings;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _settings = UnityTypeConverterInitializer.GetUnityJsonSerializerSettings();
            _settings.Formatting = Formatting.None;
        }

        [Test]
        public void SerializesAsExpected()
        {
            // Arrange
            const string expected = @"{""x"":1,""y"":2,""z"":3}";
            var input = new Vector3(1, 2, 3);

            // Act
            string result = JsonConvert.SerializeObject(input, _settings);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
