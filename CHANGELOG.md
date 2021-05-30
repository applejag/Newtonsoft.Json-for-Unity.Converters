# Unity Converters for Newtonsoft.Json changelog

## 1.1.1 (2021-05-30)

- Fixed Newtonsoft.Json converters (ex: `StringEnumConverter` &
  `VersionConverter`) not being loaded even if you had then enabled in the
  Newtonsoft.Json-for-Unity.Converters config.
  ([#55](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/issues/55))

## 1.1.0 (2021-04-05)

- Added configurability to enable/disable any converter that was all previously
  inserted automatically. Access the settings via the menu at
  "Edit > Json .NET converters settings..."
  ([#40](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/pull/40))

- Added custom contract resolver to look for the
  `UnityEngine.SerializeFieldAttribute` and include attributed fields and
  properties appropriately.
  ([#39](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/issues/39))

- Added `UnityEngine.ScriptableObject` deserialization support by using the
  `ScriptableObject.Create(Type type)` method when reading the JSON.
  ([#39](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/issues/39))

- Fixed IL2CPP builds failing due to usage of `__makeref` in
  `CullingGroupEventConverter`, `ColliderDistance2DConverter`, and
  `RandomStateConverter`
  ([#35](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/issues/35))

- Fixed `float` precision error when reading/prasing. ([#46](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/issues/46),
  [#51](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/issues/51))

- Added support for populating using `JsonConvert.PopulateObject` when using
  any of the custom converters. ([#49](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/issues/49))

- Removed the array passing and reflection in the PartialConverter and removed
  all partial converters except `PartialConverter.cs`, simplifying the code a
  lot. This should lead to a minor performance boost as well.
  ([#48](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/pull/48))

## 1.0.0 (2020-05-10)

- ✨ Initial release

- ❤ Big love from these authors allowing me to take inspiration from their
  converters packages:

  - ParentElement <https://github.com/ianmacgillivray/Json-NET-for-Unity>
  - Wanzyee Studio <http://wanzyeestudio.blogspot.com/2017/03/jsonnet-converters.html>

- UnityConverterInitializer that registers converters on load

- Ensured via tests to work in Unity version:
  - 2018.4
  - 2019.2
  - 2020.1

- Ensured via tests to work with API compatibility:
  - .NET Standard 2.0

- Ensured via tests to work with Newtonsoft.Json version:
  - 12.0.3

- Added custom converters for following types:
  - [x] (AI/NavMesh) UnityEngine.AI.NavMeshQueryFilter
  - [x] (AI/NavMesh) UnityEngine.AI.NavMeshTriangulation
  - [x] (Camera) CullingGroupEvent
  - [x] (Geometry) UnityEngine.Bounds
  - [x] (Geometry) UnityEngine.BoundsInt
  - [x] (Geometry) UnityEngine.Plane
  - [x] (Geometry) UnityEngine.Rect
  - [x] (Geometry) UnityEngine.RectInt
  - [x] (Geometry) UnityEngine.RectOffset
  - [x] (Hashing) UnityEngine.Hash128
  - [x] (Math) UnityEngine.Color
  - [x] (Math) UnityEngine.Color32
  - [x] (Math) UnityEngine.Quaternion
  - [x] (Math) UnityEngine.Rendering.SphericalHarmonicsL2
  - [x] (Math) UnityEngine.Vector2
  - [x] (Math) UnityEngine.Vector2Int
  - [x] (Math) UnityEngine.Vector3
  - [x] (Math) UnityEngine.Vector3Int
  - [x] (Math) UnityEngine.Vector4
  - [x] (Physics) UnityEngine.JointDrive
  - [x] (Physics) UnityEngine.JointLimits
  - [x] (Physics) UnityEngine.SoftJointLimit
  - [x] (Physics2D) UnityEngine.ColliderDistance2D
  - [x] (Physics2D) UnityEngine.ContactFilter2D
  - [x] (Random) UnityEngine.Random.State
  - [x] (Scripting) UnityEngine.LayerMask
  - [x] (Scripting) UnityEngine.RangeInt

- Known to work, but no custom converter needed:
  - [x] (AI/NavMesh) UnityEngine.AI.NavMeshHit
  - [x] (AI/NavMesh) UnityEngine.AI.NavMeshLinkData
  - [x] (Animation) UnityEngine.Keyframe
  - [x] (Camera) BoundingSphere
  - [x] (GameCenter) UnityEngine.SocialPlatforms.Range
  - [x] (Geometry) UnityEngine.Ray
  - [x] (Geometry) UnityEngine.Ray2D
  - [x] (Graphics) UnityEngine.Resolution
  - [x] (Math) UnityEngine.FrustumPlanes
  - [x] (Math) UnityEngine.Gradient
  - [x] (Math) UnityEngine.GradientAlphaKey
  - [x] (Math) UnityEngine.GradientColorKey
  - [x] (Physics) UnityEngine.BoxcastCommand
  - [x] (Physics) UnityEngine.CapsulecastCommand
  - [x] (Physics) UnityEngine.JointMotor
  - [x] (Physics) UnityEngine.JointSpring
  - [x] (Physics) UnityEngine.RaycastCommand
  - [x] (Physics) UnityEngine.SoftJointLimitSpring
  - [x] (Physics) UnityEngine.SpherecastCommand
  - [x] (Physics) UnityEngine.WheelFrictionCurve
  - [x] (Physics2D) UnityEngine.JointAngleLimits2D
  - [x] (Physics2D) UnityEngine.JointMotor2D
  - [x] (Physics2D) UnityEngine.JointSuspension2D
  - [x] (Physics2D) UnityEngine.JointTranslationLimits2D
  - [x] (Physics2D) UnityEngine.PhysicsJobOptions2D
  - [x] (RenderPipeline) UnityEngine.Rendering.FilteringSettings
  - [x] (RenderPipeline) UnityEngine.Rendering.RenderQueueRange
  - [x] (RenderPipeline) UnityEngine.Rendering.SortingLayerRange
  - [x] (SpriteShape) UnityEngine.U2D.AngleRangeInfo
  - [x] (SpriteShape) UnityEngine.U2D.ShapeControlPoint
  - [x] (SpriteShape) UnityEngine.U2D.SpriteShapeMetaData

- ❌ KNOWN NOT TO WORK (contains ID or reference to UnityEngine.Object):
  - (AI/NavMesh) UnityEngine.AI.NavMeshDataInstance
  - (AI/NavMesh) UnityEngine.AI.NavMeshLinkInstance
  - (Physics) UnityEngine.ContactPoint
  - (Physics) UnityEngine.PhysicsScene
  - (Physics) UnityEngine.RaycastHit
  - (Physics2D) UnityEngine.ContactPoint2D
  - (Physics2D) UnityEngine.PhysicsScene2D
  - (Physics2D) UnityEngine.RaycastHit2D
  - (RenderPipeline) UnityEngine.Rendering.VisibleLight

- ❌ KNOWN NOT TO WORK (contains NativeArray/NativeSlice):
  - (NativeArray) Unity.Collections.NativeArray<>
  - (NativeArray) Unity.Collections.NativeSlice<>
  - (ParticleSystem) UnityEngine.ParticleSystemJobs.ParticleSystemJobData
  - (ParticleSystem) UnityEngine.ParticleSystemJobs.ParticleSystemNativeArray3
  - (ParticleSystem) UnityEngine.ParticleSystemJobs.ParticleSystemNativeArray4
  - (Rendering) UnityEngine.Rendering.BatchCullingContext

- ❌ KNOWN NOT TO WORK (contains readonly fields):
  - (Rendering) UnityEngine.Rendering.BatchVisibility
