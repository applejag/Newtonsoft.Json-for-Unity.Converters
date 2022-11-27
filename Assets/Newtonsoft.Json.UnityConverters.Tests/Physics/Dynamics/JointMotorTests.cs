#if HAVE_MODULE_PHYSICS || !UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Physics.Dynamics
{
    public class JointMotorTests : ValueTypeTester<JointMotor>
    {
        public static readonly IReadOnlyCollection<(JointMotor deserialized, object anonymous)> representations = new (JointMotor, object)[] {
            (new JointMotor(), new {
                targetVelocity = 0f,
                force = 0f,
                freeSpin = false,
            }),
            (new JointMotor {
                targetVelocity = 1f,
                force = 2f,
                freeSpin = true,
            }, new {
                targetVelocity = 1f,
                force = 2f,
                freeSpin = true,
            }),
        };
    }
}
#endif
