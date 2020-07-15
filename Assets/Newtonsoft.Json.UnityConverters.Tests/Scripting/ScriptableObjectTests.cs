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
                float1 = 0f,
                float2 = 0f,
                hideFlags = HideFlags.None,
            }),
            (CreateMockInstance("myObject", HideFlags.DontSaveInBuild | HideFlags.HideInHierarchy, 1, 2), new ExpectedSignature {
                name = "myObject",
                float1 = 1,
                float2 = 2,
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
            Assert.AreEqual(typeof(MockScriptableObject).FullName, typeName);
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
            var serializer = JsonSerializer.Create(UnityConverterInitializer.DefaultUnityConvertersSettings);
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
        [TestCase(TypeNameHandling.Auto)]
        public void DeserializeGivenTypeFromProperty(TypeNameHandling typeNameHandling)
        {
            ScriptableObject result = DeserializeWithTypeNameHandling(typeNameHandling);

            // Assert
            Assert.IsInstanceOf<MockScriptableObject>(result);
        }

        [Test]
        [TestCase(TypeNameHandling.Arrays)]
        [TestCase(TypeNameHandling.None)]
        public void DeserializesGivenTypeFromTypeOption(TypeNameHandling typeNameHandling)
        {
            ScriptableObject result = DeserializeWithTypeNameHandling(typeNameHandling);

            // Assert
            Assert.IsNotInstanceOf<MockScriptableObject>(result);
        }

        private static ScriptableObject DeserializeWithTypeNameHandling(TypeNameHandling typeNameHandling)
        {
            // Arrange
            var serializer = JsonSerializer.Create(UnityConverterInitializer.DefaultUnityConvertersSettings);
            serializer.TypeNameHandling = typeNameHandling;

            string input = $@"{{""$type"":{typeof(MockScriptableObject).FullName}}}";

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
                && a.hideFlags == b.hideFlags
                && a.float1 == b.float1
                && a.GetFloat2() == b.GetFloat2();
        }

        private static MockScriptableObject CreateMockInstance(string name, HideFlags hideFlags, float float1, float float2)
        {
            MockScriptableObject instance = ScriptableObject.CreateInstance<MockScriptableObject>();

            instance.name = name;
            instance.hideFlags = hideFlags;
            instance.float1 = float1;
            instance.SetFloat2(float2);

            return instance;
        }

        private struct ExpectedSignature
        {
            public string name;

            public HideFlags hideFlags;

            public float float1;

            public float float2;
        }

        public class MockScriptableObject : ScriptableObject
        {
            public float float1;

#pragma warning disable IDE1006 // Naming Styles
            [SerializeField]
            private float float2;
#pragma warning restore IDE1006 // Naming Styles

            // This field should be ignored
            [NonSerialized]
            public float float3;

            public void SetFloat2(float value)
            {
                float2 = value;
            }

            public float GetFloat2()
            {
                return float2;
            }

            public override string ToString()
            {
                return $"{nameof(MockScriptableObject)}{{name: \"{name}\", hideFlags: \"{hideFlags}\", float1: {float1}, float2: {float2}}}";
            }
        }

    }
}
