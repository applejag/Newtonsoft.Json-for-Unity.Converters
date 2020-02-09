using System;
using NUnit.Framework;
using Unity.Collections;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class NativeArrayTests : TypeTesterBase
    {
        public static (int[] array, string serialized)[] representations = new[] {
            (new int[]{ 1,2,3,4 }, @"[1,2,3,4]"),
            (Array.Empty<int>(), @"[]"),
        };

        protected override void ConfigureSettings(JsonSerializerSettings settings)
        {
        }

        [Test]
        [TestCaseSource("representations")]
        public void SerializesAsExpected((int[] inputArray, string expected) representation)
        {
            // Arrange
            using (var nativeArray = new NativeArray<int>(representation.inputArray, Allocator.Temp)){
                JsonSerializerSettings settings = GetSettings();

                // Act
                string result = JsonConvert.SerializeObject(nativeArray, settings);

                // Assert
                Assert.AreEqual(representation.expected, result);
            }
        }

        [Test]
        [TestCaseSource("representations")]
        public void ThrowsOnDeserialize((int[] expectedArray, string input) representation)
        {
            // Arrange
            JsonSerializerSettings settings = GetSettings();

            // Act
            var ex = Assert.Throws<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<NativeArray<int>>(representation.input, settings)
            );

            // Assert
            StringAssert.StartsWith("Deserializing NativeArray<> is disabled to not cause accidental memory leaks. Use regular List<> or array types instead.", ex.Message, ex.ToString());
        }
    }
}
