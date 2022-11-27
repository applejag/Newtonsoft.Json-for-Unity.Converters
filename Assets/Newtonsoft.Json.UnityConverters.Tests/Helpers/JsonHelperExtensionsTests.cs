using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Newtonsoft.Json.UnityConverters.Helpers;
using System.IO;

namespace Newtonsoft.Json.UnityConverters.Tests.Helpers
{
    public class JsonHelperExtensionsTests
    {
        [Test]
        public void ReadAsFloatPrecision()
        {
            // https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/issues/46

            // Arrange
            const float INPUT = 0.000000156f;
            const float EXPECTED = INPUT;
            var json = JsonConvert.SerializeObject(INPUT);
            var reader = new JsonTextReader(new StringReader(json));

            // Act
            var result = reader.ReadAsFloat();

            // Assert
            Assert.AreEqual(EXPECTED, result);
        }
    }
}
