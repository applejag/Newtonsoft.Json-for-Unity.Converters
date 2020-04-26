using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.ConvertingUnityTypes.Physics2D
{
    public class ContactFilter2DTests : ValueTypeTester<ContactFilter2D>
    {
        public static readonly IReadOnlyCollection<(ContactFilter2D deserialized, object anonymous)> representations = new (ContactFilter2D, object)[] {
            (new ContactFilter2D(), new {
                useTriggers = false,
                useLayerMask = false,
                useDepth = false,
                useOutsideDepth = false,
                useNormalAngle = false,
                useOutsideNormalAngle = false,
                layerMask = 0,
                minDepth = 0f,
                maxDepth = 0f,
                minNormalAngle = 0f,
                maxNormalAngle = 0f,
            }),
            (new ContactFilter2D {
                useTriggers = true,
                useLayerMask = true,
                useDepth = true,
                useOutsideDepth = true,
                useNormalAngle = true,
                useOutsideNormalAngle = true,
                layerMask = new LayerMask { value = 1 },
                minDepth = 2,
                maxDepth = 3,
                minNormalAngle = 4,
                maxNormalAngle = 5,
            }, new {
                useTriggers = false,
                useLayerMask = false,
                useDepth = false,
                useOutsideDepth = false,
                useNormalAngle = false,
                useOutsideNormalAngle = false,
                layerMask = 1,
                minDepth = 2f,
                maxDepth = 3f,
                minNormalAngle = 4f,
                maxNormalAngle = 5f,
            }),
        };
    }
}
