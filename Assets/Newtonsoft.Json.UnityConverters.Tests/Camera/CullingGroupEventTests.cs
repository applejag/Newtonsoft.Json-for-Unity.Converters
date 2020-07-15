using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Camera
{
    public class CullingGroupEventTests : ValueTypeTester<CullingGroupEvent>
    {
        private const byte DISTANCE_MASK = (1 << 7) - 1;

        [MaybeNull]
        private static readonly FieldInfo _indexField = typeof(CullingGroupEvent).GetField("m_Index", BindingFlags.NonPublic | BindingFlags.Instance);
        [MaybeNull]
        private static readonly FieldInfo _prevStateField = typeof(CullingGroupEvent).GetField("m_PrevState", BindingFlags.NonPublic | BindingFlags.Instance);
        [MaybeNull]
        private static readonly FieldInfo _thisStateField = typeof(CullingGroupEvent).GetField("m_ThisState", BindingFlags.NonPublic | BindingFlags.Instance);

        public static readonly IReadOnlyCollection<(CullingGroupEvent deserialized, object anonymous)> representations = new (CullingGroupEvent, object)[] {
            (new CullingGroupEvent(), new {
                index = 0,
                isVisible = false,
                wasVisible = false,
                currentDistance = 0,
                previousDistance = 0,
            }),
            (CreateInstance(
                index: 1,
                prevState: AsVisibility(true) | AsDistance(2),
                thisState: AsVisibility(true) | AsDistance(3)
            ), new {
                index = 1,
                isVisible = true,
                wasVisible = true,
                currentDistance = 3,
                previousDistance = 2,
            }),
            (CreateInstance(
                index: 2,
                prevState: AsVisibility(true) | AsDistance(3),
                thisState: AsVisibility(false) | AsDistance(4)
            ), new {
                index = 2,
                isVisible = false,
                wasVisible = true,
                currentDistance = 4,
                previousDistance = 3,
            }),
            (CreateInstance(
                index: 3,
                prevState: AsVisibility(false) | AsDistance(4),
                thisState: AsVisibility(true) | AsDistance(5)
            ), new {
                index = 3,
                isVisible = true,
                wasVisible = false,
                currentDistance = 5,
                previousDistance = 4,
            }),
        };

        private static CullingGroupEvent CreateInstance(int index, int prevState, int thisState)
        {
            if (_indexField is null)
            {
                throw new InvalidOperationException($"Was unable to find index field from the {typeof(CullingGroupEvent).FullName} type.");
            }

            if (_prevStateField is null)
            {
                throw new InvalidOperationException($"Was unable to find prevState field from the {typeof(CullingGroupEvent).FullName} type.");
            }

            if (_thisStateField is null)
            {
                throw new InvalidOperationException($"Was unable to find thisState field from the {typeof(CullingGroupEvent).FullName} type.");
            }

            byte prevStateByte = (byte)prevState;
            byte thisStateByte = (byte)thisState;

            object boxed = new CullingGroupEvent();

            _indexField.SetValue(boxed, index);
            _prevStateField.SetValue(boxed, prevStateByte);
            _thisStateField.SetValue(boxed, thisStateByte);

            return (CullingGroupEvent)boxed;
        }

        private static byte AsVisibility(bool isVisible)
        {
            return isVisible ? (byte)0x80 : (byte)0;
        }

        private static byte AsDistance(byte distance)
        {
            return (byte)(distance & DISTANCE_MASK);
        }
    }
}
