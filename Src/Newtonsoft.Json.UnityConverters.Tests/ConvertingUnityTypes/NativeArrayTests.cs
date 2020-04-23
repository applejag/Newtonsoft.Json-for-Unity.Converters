using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Unity.Collections;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class NativeArrayTests : TypeTesterBase
    {
        public static readonly IReadOnlyCollection<(int[] array, object anonymous)> representations = new int[][] {
            new[] {1,2,3,4},
            Array.Empty<int>(),
        }
        .Select(o => (o, (object)o)).ToArray();

        [Test]
        [TestCaseSource("representations")]
        public void SerializesAsExpected((int[] inputArray, object anonymous) representation)
        {
            // Arrange
            using (var nativeArray = new NativeArray<int>(representation.inputArray, Allocator.Temp))
            {
                JsonSerializerSettings settings = GetSettings();
                string expected = JArray.FromObject(representation.anonymous).ToString(Formatting.None);

                // Act
                string result = JsonConvert.SerializeObject(nativeArray, settings);

                // Assert
                Assert.AreEqual(expected, result);
            }
        }

        [Test]
        [TestCaseSource("representations")]
        public void ThrowsOnDeserialize((int[] expectedArray, object anonymous) representation)
        {
            // Arrange
            JsonSerializerSettings settings = GetSettings();
            string input = JArray.FromObject(representation.anonymous).ToString(Formatting.None);

            // Act
            var ex = Assert.Throws<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<NativeArray<int>>(input, settings)
            );

            // Assert
            StringAssert.StartsWith("Deserializing NativeArray<> is disabled to not cause accidental memory leaks. Use regular List<> or array types instead.", ex.Message, ex.ToString());
        }
    }
}
