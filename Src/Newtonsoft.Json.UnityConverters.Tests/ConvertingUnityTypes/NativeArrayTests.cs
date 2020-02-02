using System;
using NUnit.Framework;
using Unity.Collections;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class NativeArrayTests : TypeTesterBase
    {
        public static (NativeArray<int> deserialized, string serialized)[] Representations { get; } = new[] {
            (new NativeArray<int>(new int[]{ 1,2,3,4 }, Allocator.Persistent), @"[1,2,3,4]"),
            (new NativeArray<int>(Array.Empty<int>(), Allocator.None), @"[]"),
        };

        protected override void ConfigureSettings(JsonSerializerSettings settings)
        {
        }

        [Test]
        [TestCaseSource("Representations")]
        public void SerializesAsExpected((NativeArray<int> input, string expected) representation)
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
        public void DeserializesAsExpected((NativeArray<int> expected, string input) representation)
        {
            // Arrange
            JsonSerializerSettings settings = GetSettings();

            // Act
            NativeArray<int> result = JsonConvert.DeserializeObject<NativeArray<int>>(representation.input, settings);

            // Assert
            Assert.IsTrue(result.IsCreated);
            CollectionAssert.AreEqual(representation.expected, result);
        }
    }
}
