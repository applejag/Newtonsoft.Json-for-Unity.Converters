using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.UnityConverters.Helpers;
using NUnit.Framework;
using UnityEngine;
using State = UnityEngine.Random.State;

namespace Newtonsoft.Json.UnityConverters.Tests.Random
{
    public class RandomStateTests : ValueTypeTester<State>
    {
        private static readonly FieldInfo[] _randomStateFields = typeof(State).GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .OrderBy(o => o.Name)
            .WhereNotNullRef()
            .ToArray();

        public static readonly IReadOnlyCollection<(State deserialized, object anonymous)> representations = new (State, object)[] {
            (new State(), new { s0 = 0, s1 = 0, s2 = 0, s3 = 0 }),
            (CreateState(1,2,3,4), new { s0 = 1, s1 = 2, s2 = 3, s3 = 4 }),
        };

        protected override bool AreEqual(State a, State b)
        {
            if (_randomStateFields.Length != 4)
            {
                throw new InvalidOperationException("Was unable to find all four random state fields from the UnityEngine.State type.");
            }

            foreach (FieldInfo field in _randomStateFields)
            {
                if (!Equals(field.GetValue(a), field.GetValue(b)))
                {
                    return false;
                }
            }

            return true;
        }

        protected override string ToString(State value)
        {
            if (_randomStateFields.Length != 4)
            {
                throw new InvalidOperationException("Was unable to find all four random state fields from the UnityEngine.State type.");
            }

            return $"[{string.Join(", ", _randomStateFields.Select(o => o.GetValue(value)))}]";
        }

        private static State CreateState(int s0, int s1, int s2, int s3)
        {
            if (_randomStateFields.Length != 4)
            {
                throw new InvalidOperationException("Was unable to find all four random state fields from the UnityEngine.State type.");
            }

            string json = $@"{{""s0"":{s0},""s1"":{s1},""s2"":{s2},""s3"":{s3}}}";
            return JsonUtility.FromJson<State>(json);
        }

        [Test]
        public void CanSetStateViaBoxing()
        {
            // Arrange
            FieldInfo field = _randomStateFields[0];

            object boxed = new State();
            Assert.AreEqual(0, field.GetValue(boxed));

            int newValue = 5;

            // Act
            field.SetValue(boxed, newValue);

            // Assert
            Assert.AreEqual(newValue, field.GetValue(boxed));
        }

#if !ENABLE_IL2CPP
        [Test]
        public void CanSetStateViaReference()
        {
            // Arrange
            FieldInfo field = _randomStateFields[0];

            var value = new State();
            Assert.AreEqual(0, field.GetValue(value));

            int newValue = 5;

            TypedReference reference = __makeref(value);

            // Act
            field.SetValueDirect(reference, newValue);

            // Assert
            Assert.AreEqual(newValue, field.GetValue(value));
        }
#endif
    }
}
