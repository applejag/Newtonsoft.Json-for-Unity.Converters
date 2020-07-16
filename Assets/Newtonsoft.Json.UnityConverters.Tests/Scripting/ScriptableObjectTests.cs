using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Scripting
{
    public class ScriptableObjectTests : TypeTester<ScriptableObjectTests.MockScriptableObject>
    {
        public static readonly IReadOnlyCollection<(MockScriptableObject deserialized, object anonymous)> representations = new (MockScriptableObject, object)[] {
            (ScriptableObject.CreateInstance<MockScriptableObject>(), new ExpectedSignature {
                name = string.Empty,
                hideFlags = HideFlags.None,
            }),
            (CreateMockInstance("myObject", HideFlags.DontSaveInBuild | HideFlags.HideInHierarchy), new ExpectedSignature {
                name = "myObject",
                hideFlags = HideFlags.DontSaveInBuild | HideFlags.HideInHierarchy,
            }),
        };

        [Test]
        [TestCase(TypeNameHandling.All)]
        [TestCase(TypeNameHandling.Objects)]
        [TestCase(TypeNameHandling.Auto)]
        public void SerializedContainsTypeName(TypeNameHandling typeNameHandling)
        {
            string typeName = SerializeWithTypeNameHandling(typeNameHandling);

            // Assert
            Assert.AreEqual(GetTypeNameWithAssembly(typeof(MockScriptableObject)), typeName);
        }

        [Test]
        [TestCase(TypeNameHandling.Arrays)]
        [TestCase(TypeNameHandling.None)]
        public void SerializedDoesNotContainTypeName(TypeNameHandling typeNameHandling)
        {
            string typeName = SerializeWithTypeNameHandling(typeNameHandling);

            // Assert
            Assert.IsNull(typeName);
        }

        [return: MaybeNull]
        private static string SerializeWithTypeNameHandling(TypeNameHandling typeNameHandling)
        {
            // Arrange
            var serializer = JsonSerializer.Create(UnityConverterInitializer.defaultUnityConvertersSettings);
            serializer.TypeNameHandling = typeNameHandling;

            MockScriptableObject instance = ScriptableObject.CreateInstance<MockScriptableObject>();
            var obj = new {
                scriptableObject = (ScriptableObject)instance,
            };

            // Act
            string result = Serialize(obj, serializer);

            var jObject = JObject.Parse(result);
            JToken scriptableObjectToken = jObject["scriptableObject"];

            return scriptableObjectToken.Value<string>("$type");
        }

        [Test]
        [TestCase(TypeNameHandling.All)]
        [TestCase(TypeNameHandling.Objects)]
        [TestCase(TypeNameHandling.Arrays)]
        [TestCase(TypeNameHandling.Auto)]
        public void DeserializeGivenTypeFromProperty(TypeNameHandling typeNameHandling)
        {
            ScriptableObject result = DeserializeWithTypeNameHandling(typeNameHandling);

            // Assert
            Assert.IsInstanceOf<MockScriptableObject>(result);
        }

        [Test]
        [TestCase(TypeNameHandling.None)]
        public void DeserializesGivenTypeFromSignature(TypeNameHandling typeNameHandling)
        {
            ScriptableObject result = DeserializeWithTypeNameHandling(typeNameHandling);

            // Assert
            Assert.IsNotInstanceOf<MockScriptableObject>(result);
        }

        private static ScriptableObject DeserializeWithTypeNameHandling(TypeNameHandling typeNameHandling)
        {
            // Arrange
            var serializer = JsonSerializer.Create(UnityConverterInitializer.defaultUnityConvertersSettings);
            serializer.TypeNameHandling = typeNameHandling;

            string input = $@"{{""$type"":""{GetTypeNameWithAssembly(typeof(MockScriptableObject))}""}}";

            // Act
            ScriptableObject result = Deserialize<ScriptableObject>(input, serializer);
            return result;
        }

        protected override bool AreEqual([AllowNull] MockScriptableObject a, [AllowNull] MockScriptableObject b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.name == b.name
                && a.hideFlags == b.hideFlags;
        }

        private static MockScriptableObject CreateMockInstance(string name, HideFlags hideFlags)
        {
            MockScriptableObject instance = ScriptableObject.CreateInstance<MockScriptableObject>();

            instance.name = name;
            instance.hideFlags = hideFlags;

            return instance;
        }

        private class ExpectedSignature
        {
            public string name;

            public HideFlags hideFlags;
        }

        public class MockScriptableObject : ScriptableObject
        {
            public override string ToString()
            {
                return $"{nameof(MockScriptableObject)}{{name: \"{name}\", hideFlags: \"{hideFlags}\"}}";
            }
        }

    }
}
