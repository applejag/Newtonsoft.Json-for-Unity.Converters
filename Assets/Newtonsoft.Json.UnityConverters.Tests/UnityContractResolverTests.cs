using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests
{
    public class UnityContractResolverTests : TypeTester<UnityContractResolverTests.MockScriptableObject>
    {
        public static readonly IReadOnlyCollection<(MockScriptableObject deserialized, object anonymous)> representations = new (MockScriptableObject, object)[] {
            (ScriptableObject.CreateInstance<MockScriptableObject>(), new ExpectedSignature {
                float1 = 0f,
                name = string.Empty,
                hideFlags = HideFlags.None,
                float2 = 0f,
            }),
            (CreateMockInstance("myObject", HideFlags.DontSaveInBuild | HideFlags.HideInHierarchy, 1, 2), new ExpectedSignature {
                float1 = 1,
                name = "myObject",
                hideFlags = HideFlags.DontSaveInBuild | HideFlags.HideInHierarchy,
                float2 = 2,
            }),
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
                && Mathf.Approximately(a.float1, b.float1)
                && Mathf.Approximately(a.GetFloat2(), b.GetFloat2());
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

        private class ExpectedSignature
        {
            public float float1;

            public string name;

            public HideFlags hideFlags;

            public float float2;
        }

#pragma warning disable S1104 // Make this field 'private' and encapsulate it in a 'public' property.
#pragma warning disable S1144 // Unused private types or members should be removed
#pragma warning disable S2357 // Fields should be private
#pragma warning disable CA1034 // Nested types should not be visible
        public class MockScriptableObject : ScriptableObject
#pragma warning restore CA1034 // Nested types should not be visible
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
#pragma warning restore S2357 // Fields should be private
#pragma warning restore S1104 // Make this field 'private' and encapsulate it in a 'public' property.
#pragma warning restore S1144 // Unused private types or members should be removed

    }
}
