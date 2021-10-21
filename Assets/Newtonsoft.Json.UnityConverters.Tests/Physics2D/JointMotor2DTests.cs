#if HAVE_MODULE_PHYSICS2D || !UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Physics2D
{
    public class JointMotor2DTests : ValueTypeTester<JointMotor2D>
    {
        public static readonly IReadOnlyCollection<(JointMotor2D deserialized, object anonymous)> representations = new (JointMotor2D, object)[] {
            (new JointMotor2D(), new { motorSpeed = 0f, maxMotorTorque = 0f }),
            (new JointMotor2D { motorSpeed = 1, maxMotorTorque = 2 }, new { motorSpeed = 1f, maxMotorTorque = 2f }),
        };
    }
}
#endif
