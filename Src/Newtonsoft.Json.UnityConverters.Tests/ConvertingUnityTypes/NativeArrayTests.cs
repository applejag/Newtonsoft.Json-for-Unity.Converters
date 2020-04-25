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
        public void SerializesArrayAsExpected((int[] inputArray, object anonymous) representation)
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
        public void ThrowsOnArrayDeserialize((int[] expectedArray, object anonymous) representation)
        {
            // Arrange
            JsonSerializerSettings settings = GetSettings();
            string input = JArray.FromObject(representation.anonymous).ToString(Formatting.None);

            // Act
            var ex = Assert.Throws<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<NativeArray<int>>(input, settings)
            );

            // Assert
            StringAssert.StartsWith("Deserializing NativeArray<> and NativeSlice<> is disabled to not cause accidental memory leaks. Use regular List<> or array types instead.", ex.Message, ex.ToString());
        }


        [Test]
        [TestCaseSource("representations")]
        public void SerializesSliceAsExpected((int[] inputArray, object anonymous) representation)
        {
            // Arrange
            using (var nativeArray = new NativeArray<int>(representation.inputArray, Allocator.Temp))
            {
                var nativeSlice = new NativeSlice<int>(nativeArray);

                JsonSerializerSettings settings = GetSettings();
                string expected = JArray.FromObject(representation.anonymous).ToString(Formatting.None);

                // Act
                string result = JsonConvert.SerializeObject(nativeSlice, settings);

                // Assert
                Assert.AreEqual(expected, result);
            }
        }

        [Test]
        [TestCaseSource("representations")]
        public void ThrowsOnSliceDeserialize((int[] expectedArray, object anonymous) representation)
        {
            // Arrange
            JsonSerializerSettings settings = GetSettings();
            string input = JArray.FromObject(representation.anonymous).ToString(Formatting.None);

            // Act
            var ex = Assert.Throws<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<NativeSlice<int>>(input, settings)
            );

            // Assert
            StringAssert.StartsWith("Deserializing NativeArray<> and NativeSlice<> is disabled to not cause accidental memory leaks. Use regular List<> or array types instead.", ex.Message, ex.ToString());
        }
    }
}
