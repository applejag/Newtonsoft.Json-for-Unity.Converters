﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes
{
    public class RandomStateTests : ValueTypeTester<Random.State>
    {
        private static readonly FieldInfo[] _randomStateFields = typeof(Random.State).GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .OrderBy(o => o.Name)
            .WhereNotNullRef()
            .ToArray();

        public static readonly IReadOnlyCollection<(Random.State deserialized, object anonymous)> representations = new (Random.State, object)[] {
            (new Random.State(), new { s0 = 0, s1 = 0, s2 = 0, s3 = 0 }),
            (CreateState(1,2,3,4), new { s0 = 1, s1 = 2, s2 = 3, s3 = 4 }),
        };

        protected override bool AreEqual(Random.State a, Random.State b)
        {
            if (_randomStateFields.Length != 4)
            {
                throw new InvalidOperationException("Was unable to find all four random state fields from the UnityEngine.Random.State type.");
            }

            foreach(FieldInfo field in _randomStateFields)
            {
                if (!Equals(field.GetValue(a), field.GetValue(b)))
                {
                    return false;
                }
            }

            return true;
        }

        protected override string ToString(Random.State value)
        {
            if (_randomStateFields.Length != 4)
            {
                throw new InvalidOperationException("Was unable to find all four random state fields from the UnityEngine.Random.State type.");
            }

            return $"[{string.Join(", ", _randomStateFields.Select(o => o.GetValue(value)))}]";
        }

        private static Random.State CreateState(int s0, int s1, int s2, int s3)
        {
            if (_randomStateFields.Length != 4)
            {
                throw new InvalidOperationException("Was unable to find all four random state fields from the UnityEngine.Random.State type.");
            }

            string json = $@"{{""s0"":{s0},""s1"":{s1},""s2"":{s2},""s3"":{s3}}}";
            return JsonUtility.FromJson<Random.State>(json);
        }

        [Test]
        public void CanSetStateViaBoxing()
        {
            // Arrange
            FieldInfo field = _randomStateFields[0];

            object boxed = new Random.State();
            Assert.AreEqual(0, field.GetValue(boxed));

            int newValue = 5;

            // Act
            field.SetValue(boxed, newValue);

            // Assert
            Assert.AreEqual(newValue, field.GetValue(boxed));
        }

        [Test]
        public void CanSetStateViaReference()
        {
            // Arrange
            FieldInfo field = _randomStateFields[0];

            var value = new Random.State();
            Assert.AreEqual(0, field.GetValue(value));

            int newValue = 5;

            TypedReference reference = __makeref(value);

            // Act
            field.SetValueDirect(reference, newValue);

            // Assert
            Assert.AreEqual(newValue, field.GetValue(value));
        }
    }
}
