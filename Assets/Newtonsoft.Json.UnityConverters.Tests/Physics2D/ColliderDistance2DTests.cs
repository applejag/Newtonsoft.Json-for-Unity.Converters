#if HAVE_MODULE_PHYSICS2D || !UNITY_2019_1_OR_NEWER
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Physics2D
{
    public class ColliderDistance2DTests : ValueTypeTester<ColliderDistance2D>
    {
        [MaybeNull]
        private static readonly FieldInfo _normalField = typeof(ColliderDistance2D).GetField("m_Normal", BindingFlags.NonPublic | BindingFlags.Instance);

        public static readonly IReadOnlyCollection<(ColliderDistance2D deserialized, object anonymous)> representations = new (ColliderDistance2D, object)[] {
            (new ColliderDistance2D(), new {
                pointA = new { x = 0f, y = 0f },
                pointB = new { x = 0f, y = 0f },
                normal = new { x = 0f, y = 0f },
                distance = 0f,
                isValid = false,
            }),
            (CreateInstance(
                pointA: new Vector2(1, 2),
                pointB: new Vector2(3, 4),
                normal: new Vector2(5, 6),
                distance: 7,
                isValid: true
            ), new {
                pointA = new { x = 1f, y = 2f },
                pointB = new { x = 3f, y = 4f },
                normal = new { x = 5f, y = 6f },
                distance = 7f,
                isValid = true,
            }),
        };

        private static ColliderDistance2D CreateInstance(Vector2 pointA, Vector2 pointB, Vector2 normal, float distance, bool isValid)
        {
            if (_normalField == null)
            {
                throw new InvalidOperationException("Was unable to find 'm_Normal' field from the UnityEngine.ColliderDistance2D type.");
            }

            object boxed = new ColliderDistance2D {
                pointA = pointA,
                pointB = pointB,
                distance = distance,
                isValid = isValid,
            };

            _normalField.SetValue(boxed, normal);

            return (ColliderDistance2D)boxed;
        }

        [Test]
        public void CanSetNormalViaBoxing()
        {
            // Arrange
            object boxed = new ColliderDistance2D();
            Assert.AreEqual(new Vector2(), ((ColliderDistance2D)boxed).normal);

            Assert.IsNotNull(_normalField);
            FieldInfo field = _normalField;

            var normal = new Vector2(1, 0);

            // Act
            field.SetValue(boxed, normal);

            // Assert
            Assert.AreEqual(normal, ((ColliderDistance2D)boxed).normal);
            Assert.AreNotEqual(normal, new Vector2());
        }

#if !ENABLE_IL2CPP
        [Test]
        public void CanSetNormalViaReference()
        {
            // Arrange
            var value = new ColliderDistance2D();
            Assert.AreEqual(new Vector2(), value.normal);

            Assert.IsNotNull(_normalField);
            FieldInfo field = _normalField;

            var normal = new Vector2(1, 0);

            TypedReference reference = __makeref(value);

            // Act
            field.SetValueDirect(reference, normal);

            // Assert
            Assert.AreEqual(normal, value.normal);
            Assert.AreNotEqual(normal, new Vector2());
        }
#endif

        protected override string ToString([AllowNull] ColliderDistance2D value)
        {
            return $"pointA: {value.pointA}, pointB: {value.pointB}, normal: {value.normal}, distance: {value.distance}, isValid: {value.isValid}, isOverlapped: {value.isOverlapped}";
        }
    }
}
#endif
