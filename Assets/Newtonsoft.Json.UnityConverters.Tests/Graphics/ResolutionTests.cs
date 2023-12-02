using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Graphics
{
    public class ResolutionTests : ValueTypeTester<Resolution>
    {
        public static readonly IReadOnlyCollection<(Resolution deserialized, object anonymous)> representations = new (Resolution, object)[] {
            (new Resolution(), new {
                width = 0,
                height = 0,
                refreshRate = 0,
#if UNITY_2022_2_OR_NEWER
                // For 2022.2+, we want it to print both refreshRate and refreshRateRatio, to not break backward compatibility.
                refreshRateRatio = new {
                    numerator = 0,
                    denominator = 0,
                    value = double.NaN,
                },
#endif
            }),
            (new Resolution {
                width = 1,
                height = 2,
#pragma warning disable CS0618 // Type or member is obsolete
                refreshRate = 3,
#pragma warning restore CS0618 // Type or member is obsolete
            }, new {
                width = 1,
                height = 2,
                refreshRate = 3,
#if UNITY_2022_2_OR_NEWER
                // For 2022.2+, we want it to print both refreshRate and refreshRateRatio, to not break backward compatibility.
                refreshRateRatio = new {
                    numerator = 3,
                    denominator = 1,
                    value = 3.0d,
                },
#endif
            }),
        };
    }
}
