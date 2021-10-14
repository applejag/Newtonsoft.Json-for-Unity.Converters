#if HAVE_MODULE_PHYSICS2D || !UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Physics2D
{
    public class PhysicsJobOptions2DTests : ValueTypeTester<PhysicsJobOptions2D>
    {
        public static readonly IReadOnlyCollection<(PhysicsJobOptions2D deserialized, object anonymous)> representations = new (PhysicsJobOptions2D, object)[] {
            (new PhysicsJobOptions2D(), new {
                useMultithreading = false,
                useConsistencySorting = false,
                interpolationPosesPerJob = 0,
                newContactsPerJob = 0,
                collideContactsPerJob = 0,
                clearFlagsPerJob = 0,
                clearBodyForcesPerJob = 0,
                syncDiscreteFixturesPerJob = 0,
                syncContinuousFixturesPerJob = 0,
                findNearestContactsPerJob = 0,
                updateTriggerContactsPerJob = 0,
                islandSolverCostThreshold = 0,
                islandSolverBodyCostScale = 0,
                islandSolverContactCostScale = 0,
                islandSolverJointCostScale = 0,
                islandSolverBodiesPerJob = 0,
                islandSolverContactsPerJob = 0,
            }),

            (new PhysicsJobOptions2D {
                useMultithreading = true,
                useConsistencySorting = true,
                interpolationPosesPerJob = 1,
                newContactsPerJob = 2,
                collideContactsPerJob = 3,
                clearFlagsPerJob = 4,
                clearBodyForcesPerJob = 5,
                syncDiscreteFixturesPerJob = 6,
                syncContinuousFixturesPerJob = 7,
                findNearestContactsPerJob = 8,
                updateTriggerContactsPerJob = 9,
                islandSolverCostThreshold = 10,
                islandSolverBodyCostScale = 11,
                islandSolverContactCostScale = 12,
                islandSolverJointCostScale = 13,
                islandSolverBodiesPerJob = 14,
                islandSolverContactsPerJob = 15,
            }, new {
                useMultithreading = true,
                useConsistencySorting = true,
                interpolationPosesPerJob = 1,
                newContactsPerJob = 2,
                collideContactsPerJob = 3,
                clearFlagsPerJob = 4,
                clearBodyForcesPerJob = 5,
                syncDiscreteFixturesPerJob = 6,
                syncContinuousFixturesPerJob = 7,
                findNearestContactsPerJob = 8,
                updateTriggerContactsPerJob = 9,
                islandSolverCostThreshold = 10,
                islandSolverBodyCostScale = 11,
                islandSolverContactCostScale = 12,
                islandSolverJointCostScale = 13,
                islandSolverBodiesPerJob = 14,
                islandSolverContactsPerJob = 15,
            }),
        };
    }
}
#endif
