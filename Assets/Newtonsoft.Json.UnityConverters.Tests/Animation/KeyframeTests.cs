using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Animation
{
    public class KeyframeTests : ValueTypeTester<Keyframe>
    {
        public static readonly IReadOnlyCollection<(Keyframe deserialized, object anonymous)> representations = new (Keyframe, object)[] {
            (new Keyframe(), new {
                time = 0f,
                value = 0f,
                inTangent = 0f,
                outTangent = 0f,
                inWeight = 0f,
                outWeight = 0f,
                weightedMode = WeightedMode.None,
                tangentMode = 0,
            }),
            (new Keyframe(1, 2), new {
                time = 1f,
                value = 2f,
                inTangent = 0f,
                outTangent = 0f,
                inWeight = 0f,
                outWeight = 0f,
                weightedMode = WeightedMode.None,
                tangentMode = 0,
            }),
            (new Keyframe(1, 2, 3, 4), new {
                time = 1f,
                value = 2f,
                inTangent = 3f,
                outTangent = 4f,
                inWeight = 0f,
                outWeight = 0f,
                weightedMode = WeightedMode.None,
                tangentMode = 0,
            }),
            (new Keyframe(1, 2, 3, 4, 5, 6), new {
                time = 1f,
                value = 2f,
                inTangent = 3f,
                outTangent = 4f,
                inWeight = 5f,
                outWeight = 6f,
                weightedMode = WeightedMode.Both,
                tangentMode = 0,
            }),
            (new Keyframe(1, 2, 3, 4, 5, 6) { weightedMode = WeightedMode.In }, new {
                time = 1f,
                value = 2f,
                inTangent = 3f,
                outTangent = 4f,
                inWeight = 5f,
                outWeight = 6f,
                weightedMode = WeightedMode.In,
                tangentMode = 0,
            }),
        };
    }
}
