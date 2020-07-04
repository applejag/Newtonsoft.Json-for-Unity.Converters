using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Scripting
{
    public class ScriptableObjectTests : TypeTester<ScriptableObjectTests.MockScriptableObject>
    {
        public static readonly IReadOnlyCollection<(MockScriptableObject deserialized, object anonymous)> representations = new (MockScriptableObject, object)[] {
            (CreateMockInstance("myObject", HideFlags.DontSaveInBuild | HideFlags.HideInHierarchy, 1, 2), new ExpectedSignature {
                type = typeof(MockScriptableObject).FullName,
                name = "myObject",
                float1 = 1,
                float2 = 2,
                hideFlags = HideFlags.DontSaveInBuild | HideFlags.HideInHierarchy,
            })
        };

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
            [JsonProperty("$type")]
            public string type;

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
                return $"{typeof(MockScriptableObject).Name}{{name: \"{name}\", hideFlags: \"{hideFlags}\", float1: {float1}, float2: {float2}}}";
            }
        }

    }
}
