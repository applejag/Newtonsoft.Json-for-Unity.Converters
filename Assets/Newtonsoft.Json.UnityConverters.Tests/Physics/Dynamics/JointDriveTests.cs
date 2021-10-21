#if HAVE_MODULE_PHYSICS || !UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Physics.Dynamics
{
    public class JointDriveTests : ValueTypeTester<JointDrive>
    {
        public static readonly IReadOnlyCollection<(JointDrive deserialized, object anonymous)> representations = new (JointDrive, object)[] {
            (new JointDrive(), new {
                positionSpring = 0f,
                positionDamper = 0f,
                maximumForce = 0f,
            }),
            (new JointDrive {
                positionSpring = 1f,
                positionDamper = 2f,
                maximumForce = 3f,
            }, new {
                positionSpring = 1f,
                positionDamper = 2f,
                maximumForce = 3f,
            }),
        };
    }
}
#endif
