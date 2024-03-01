# Unity Converters for Newtonsoft.Json changelog

## 1.6.3 (2024-03-01)

- Fixed converter lookups collisions when multiple assemblies converters
  with the same name, as it was not resolving assemblies in an exact way
  nor deterministic order:

  - Added assembly name field to `ConverterConfig` for each converter.

  - Changed TypeCache to sort assemblies based on `FullName`
    and some heuristics.

  - Changed TypeCache to lookup type in correct assembly,
    based on the assembly's name.

  Thanks [@Erifirin](https://github.com/Erifirin) for the pull request ([#90](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/pull/90))

## 1.6.2 (2024-01-08)

- Fixed typo in the new Unity.Mathematics QuaternionConverter's namespace:
  from `Newtonsoft.Json.UnityConverters.Math.QuaternionConverter`
  to `Newtonsoft.Json.UnityConverters.Mathematics.QuaternionConverter`
  (`Math` &rarr; `Mathematics`).
  ([#87](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/pull/87))

- Fixed compilation error when using Unity.Mathematics with Newtonsoft.JSON v10.
  ([#87](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/pull/87))

## 1.6.1 (2023-12-23)

- Fixed UnityConvertersConfigEditor scriptable object asset throwing error after
  recompiling scripts in Unity 2022.3.0 when selected and shown in inspector.
  ([#82](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/pull/82))

  Thanks [@EpsilonD3lta](https://github.com/EpsilonD3lta) for the implementation ([#83](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/pull/83))

## 1.6.0 (2023-12-03)

- Added converters for [Unity.Mathematics](https://docs.unity3d.com/Packages/com.unity.mathematics@1.3/manual/index.html).
  This includes all the `float2`, `double3`, `int4`, `bool4`, and similar types.
  ([#80](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/pull/80))

  There are no custom converters for the matrix types
  (`float2x2`, `float2x3`, etc), as they currently work out-of-the-box.

- Added `ResolutionConverter` to be able to read JSON from older Unity
  versions. ([#79](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/pull/79))

- Fixed compilation errors when targeting .NET Standard 2.1.
  ([#79](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/pull/79))

- Fixed converter types taking long time to load, sometimes causing lag spikes
  each time assembly got reloaded (especially when entering play-mode).

  The issue was that this package tries to find all converters by looping
  through all types in all assemblies.

  You should see better performance now, as we are using more optimized code
  paths and making use of Unity's [TypeCache](https://docs.unity3d.com/2023.3/Documentation/ScriptReference/TypeCache.html).

  If your project still suffers from big lag spikes, then you can opt-out
  completely of the "auto type scanning" code via the settings found at
  "Edit > Json.NET converters settings..." ([#79](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/pull/79))

  - Thanks [@tomkail](https://github.com/tomkail) for the excellent issue ([#77](https://github.com/applejag/Newtonsoft.Json-for-Unity.Converters/issues/77)).
  - Thanks [@Mefodei](https://github.com/Mefodei) for the inspiration ([#78](https://github.com/applejag/Newtonsoft.Json-for-Unity.Converters/pull/78))

## 1.5.1 (2023-04-19)

- Fixed converters being stripped when Managed Stripping Level is set to
  anything higher than "minimal", by adding `[Preserve]` attribute
  to the entire assemblies. ([#73](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/pull/73))

## 1.5.0 (2022-08-16)

- Added support for `UnityEngine.AddressableAssets.AssetReferenceT<T>`, in
  addition to the existing support for the non-generic `AssetReference` version
  introduced in v1.4.0.

  Thanks [@kyverr](https://github.com/kyverr) for the implementation ([#71](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/pull/71))

## 1.4.0 (2022-02-05)

- Added support for `UnityEngine.AddressableAssets.AssetReference`.
  The new `AssetReferenceConverter` is only included in the build if your
  project contains the `com.unity.addressables` package. 
  ([#67](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/pull/67))

  This automatic inclusion relies on AssemblyDefinition version defines, which
  was introduced in Unity 2019.1.x. To enable the `AssetReferenceConverter` in
  earlier versions of Unity, please add `HAVE_MODULE_ADDRESSABLES` to your
  project's "Scripting Define Symbols" found in the
  "Project Settings" -> "Player" -> "Other Settings" panel.

## 1.3.0 (2021-10-21)

- Changed the following modules to be automatically excluded from compilation
  if they are not used in the project:

  - `com.unity.modules.ai` via new define `HAVE_MODULE_AI`
  - `com.unity.modules.physics` via new define `HAVE_MODULE_PHYSICS`
  - `com.unity.modules.physics2d` via new define `HAVE_MODULE_PHYSICS2D`

  This is active starting with Unity 2019.1.x. The regarded modules are always
  active in prior Unity versions.

  Thanks [@SolidAlloy](https://github.com/SolidAlloy) for the implementation ([#60](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/pull/60))

## 1.2.0 (2021-09-11)

- Changed `UnityConverterInitializer` from `internal` to `public`.
  ([#58](https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/issues/58))

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
