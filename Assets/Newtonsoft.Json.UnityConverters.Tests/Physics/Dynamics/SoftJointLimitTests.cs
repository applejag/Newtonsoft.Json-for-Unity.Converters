using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Physics.Dynamics
{
    public class SoftJointLimitTests : ValueTypeTester<SoftJointLimit>
    {
        public static readonly IReadOnlyCollection<(SoftJointLimit deserialized, object anonymous)> representations = new (SoftJointLimit, object)[] {
            (new SoftJointLimit(), new {
                limit = 0f,
                bounciness = 0f,
                contactDistance = 0f,
            }),
            (new SoftJointLimit {
                limit = 1f,
                bounciness = 2f,
                contactDistance = 3f,
            }, new {
                limit = 1f,
                bounciness = 2f,
                contactDistance = 3f,
            }),
        };
    }
}
