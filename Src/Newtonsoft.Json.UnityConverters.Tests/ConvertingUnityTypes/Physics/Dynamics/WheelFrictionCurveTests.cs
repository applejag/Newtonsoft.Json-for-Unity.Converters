﻿using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes.Physics.Dynamics
{
    public class WheelFrictionCurveTests : ValueTypeTester<WheelFrictionCurve>
    {
        public static readonly IReadOnlyCollection<(WheelFrictionCurve deserialized, object anonymous)> representations = new (WheelFrictionCurve, object)[] {
            (new WheelFrictionCurve(), new {
                extremumSlip = 0f,
                extremumValue = 0f,
                asymptoteSlip = 0f,
                asymptoteValue = 0f,
                stiffness = 0f,
            }),
            (new WheelFrictionCurve {
                extremumSlip = 1f,
                extremumValue = 2f,
                asymptoteSlip = 3f,
                asymptoteValue = 4f,
                stiffness = 5f,
            }, new {
                extremumSlip = 1f,
                extremumValue = 2f,
                asymptoteSlip = 3f,
                asymptoteValue = 4f,
                stiffness = 5f,
            }),
        };
    }
}
