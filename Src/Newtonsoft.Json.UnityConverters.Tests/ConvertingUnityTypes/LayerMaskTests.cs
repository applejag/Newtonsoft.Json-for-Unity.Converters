using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class LayerMaskTests : TypeTester<LayerMask>
    {
        public static readonly IReadOnlyCollection<(LayerMask deserialized, object anonymous)> representations = new (LayerMask, object)[] {
            (new LayerMask(), 0),
            (new LayerMask { value = 123 }, 123),
            (new LayerMask { value = -123 }, -123),
        };

        [Test]
        public void DeserializesObjectFine()
        {
            // Arrange
            string input = @"{ ""value"": 5 }";

            // Act
            LayerMask result = Deserialize<LayerMask>(input);

            // Assert
            Assert.AreEqual(5, result.value);
        }
    }
}
