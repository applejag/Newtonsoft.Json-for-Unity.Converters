﻿using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes.AI
{
    public class ColliderDistance2DTests : ValueTypeTester<ColliderDistance2D>
    {
        private static readonly FieldInfo _normalField = typeof(ColliderDistance2D).GetField("m_Normal", BindingFlags.NonPublic | BindingFlags.Instance);

        public static readonly IReadOnlyCollection<(ColliderDistance2D deserialized, object anonymous)> representations = new (ColliderDistance2D, object)[] {
            (new ColliderDistance2D(), new {
                position = new { x = 0f, y = 0f },
                normal = new { x = 0f, y = 0f },
                distance = 0f,
                mask = 0,
                hit = false
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
    }
}