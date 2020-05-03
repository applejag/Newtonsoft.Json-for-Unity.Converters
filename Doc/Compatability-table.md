# Unity types compatibility table

| Module | Type | Can read | Can write | Custom converter
| --- | --- | --- | --- | --- |
| AI/NavMesh | _UnityEngine.<i></i>AI_.**NavMeshDataInstance** | ❌<sup>[[2]](#footnote-2)</sup> | ❓<sup>[[3]](#footnote-3)</sup> | ❌<sup>[[2]](#footnote-2)</sup>
| AI/NavMesh | _UnityEngine.<i></i>AI_.**NavMeshHit** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| AI/NavMesh | _UnityEngine.<i></i>AI_.**NavMeshLinkData** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| AI/NavMesh | _UnityEngine.<i></i>AI_.**NavMeshLinkInstance** | ❌<sup>[[2]](#footnote-2)</sup> | ❓<sup>[[3]](#footnote-3)</sup> | ❌<sup>[[2]](#footnote-2)</sup>
| AI/NavMesh | _UnityEngine.<i></i>AI_.**NavMeshQueryFilter** | ✔ | ✔ | ✔
| AI/NavMesh | _UnityEngine.<i></i>AI_.**NavMeshTriangulation** | ✔ | ✔ | ✔
| Animation | _UnityEngine_.**Keyframe** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Camera | _UnityEngine_.**BoundingSphere** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Camera | _UnityEngine_.**CullingGroupEvent** | ✔ | ✔ | ✔
| GameCenter | _UnityEngine.SocialPlatforms_.**Range** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Geometry | _UnityEngine_.**Bounds** | ✔ | ✔ | ✔
| Geometry | _UnityEngine_.**BoundsInt** | ✔ | ✔ | ✔
| Geometry | _UnityEngine_.**Plane** | ✔ | ✔ | ✔
| Geometry | _UnityEngine_.**Ray** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Geometry | _UnityEngine_.**Ray2D** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Geometry | _UnityEngine_.**Rect** | ✔ | ✔ | ✔
| Geometry | _UnityEngine_.**RectInt** | ✔ | ✔ | ✔
| Geometry | _UnityEngine_.**RectOffset** | ✔ | ✔ | ✔
| Graphics | _UnityEngine_.**Resolution** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Hashing | _UnityEngine_.**Hash128** | ✔ | ✔ | ✔
| Math | _UnityEngine_.**Color** | ✔ | ✔ | ✔
| Math | _UnityEngine_.**Color32** | ✔ | ✔ | ✔
| Math | _UnityEngine_.**FrustumPlanes** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Math | _UnityEngine_.**Gradient** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Math | _UnityEngine_.**GradientAlphaKey** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Math | _UnityEngine_.**GradientColorKey** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Math | _UnityEngine_.**Quaternion** | ✔ | ✔ | ✔
| Math | _UnityEngine.Rendering_.**SphericalHarmonicsL2** | ✔ | ✔ | ✔
| Math | _UnityEngine_.**Vector2** | ✔ | ✔ | ✔
| Math | _UnityEngine_.**Vector2Int** | ✔ | ✔ | ✔
| Math | _UnityEngine_.**Vector3** | ✔ | ✔ | ✔
| Math | _UnityEngine_.**Vector3Int** | ✔ | ✔ | ✔
| Math | _UnityEngine_.**Vector4** | ✔ | ✔ | ✔
| NativeArray | _Unity.Collections_.**NativeArray&lt;T&gt;** | ❌<sup>[[4]](#footnote-4)</sup> | ✔ | ✔
| NativeArray | _Unity.Collections_.**NativeSlice&lt;T&gt;** | ❌<sup>[[4]](#footnote-4)</sup> | ✔ | ✔
| ParticleSystem | _UnityEngine.ParticleSystemJobs_.**ParticleSystemJobData** | ❌<sup>[[4]](#footnote-4)</sup> | ❔<sup>[[5]](#footnote-5)</sup> | ❌<sup>[[4]](#footnote-4)</sup>
| ParticleSystem | _UnityEngine.ParticleSystemJobs_.**ParticleSystemNativeArray3** | ❌<sup>[[4]](#footnote-4)</sup> | ❔<sup>[[5]](#footnote-5)</sup> | ❌<sup>[[4]](#footnote-4)</sup>
| ParticleSystem | _UnityEngine.ParticleSystemJobs_.**ParticleSystemNativeArray4** | ❌<sup>[[4]](#footnote-4)</sup> | ❔<sup>[[5]](#footnote-5)</sup> | ❌<sup>[[4]](#footnote-4)</sup>
| Physics | _UnityEngine_.**BoxcastCommand** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Physics | _UnityEngine_.**CapsulecastCommand** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Physics | _UnityEngine_.**ContactPoint** | ❌<sup>[[2]](#footnote-2)</sup> | ❓<sup>[[3]](#footnote-3)</sup> | ❌<sup>[[2]](#footnote-2)</sup>
| Physics | _UnityEngine_.**JointDrive** | ✔ | ✔ | ✔
| Physics | _UnityEngine_.**JointLimits** | ✔ | ✔ | ✔
| Physics | _UnityEngine_.**JointMotor** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Physics | _UnityEngine_.**JointSpring** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Physics | _UnityEngine_.**PhysicsScene** | ❌<sup>[[2]](#footnote-2)</sup> | ❓<sup>[[3]](#footnote-3)</sup> | ❌<sup>[[2]](#footnote-2)</sup>
| Physics | _UnityEngine_.**RaycastCommand** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Physics | _UnityEngine_.**RaycastHit** | ❌<sup>[[2]](#footnote-2)</sup> | ❓<sup>[[3]](#footnote-3)</sup> | ❌<sup>[[2]](#footnote-2)</sup>
| Physics | _UnityEngine_.**SoftJointLimit** | ✔ | ✔ | ✔
| Physics | _UnityEngine_.**SoftJointLimitSpring** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Physics | _UnityEngine_.**SpherecastCommand** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Physics | _UnityEngine_.**WheelFrictionCurve** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Physics2D | _UnityEngine_.**ColliderDistance2D** | ✔ | ✔ | ✔
| Physics2D | _UnityEngine_.**ContactFilter2D** | ✔ | ✔ | ✔
| Physics2D | _UnityEngine_.**ContactPoint2D** | ❌<sup>[[2]](#footnote-2)</sup> | ❓<sup>[[3]](#footnote-3)</sup> | ❌<sup>[[2]](#footnote-2)</sup>
| Physics2D | _UnityEngine_.**JointAngleLimits2D** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Physics2D | _UnityEngine_.**JointMotor2D** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Physics2D | _UnityEngine_.**JointSuspension2D** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Physics2D | _UnityEngine_.**JointTranslationLimits2D** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Physics2D | _UnityEngine_.**PhysicsJobOptions2D** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| Physics2D | _UnityEngine_.**PhysicsScene2D** | ❌<sup>[[2]](#footnote-2)</sup> | ❓<sup>[[3]](#footnote-3)</sup> | ❌<sup>[[2]](#footnote-2)</sup>
| Physics2D | _UnityEngine_.**RaycastHit2D** | ❌<sup>[[2]](#footnote-2)</sup> | ❓<sup>[[3]](#footnote-3)</sup> | ❌<sup>[[2]](#footnote-2)</sup>
| Random | _UnityEngine_.**Random.State** | ✔ | ✔ | ✔
| Rendering | _UnityEngine.Rendering_.**BatchCullingContext** | ❌<sup>[[4]](#footnote-4)</sup> | ❔<sup>[[5]](#footnote-5)</sup> | ❌<sup>[[4]](#footnote-4)</sup>
| Rendering | _UnityEngine.Rendering_.**BatchVisibility** | ❌<sup>[[4]](#footnote-6)</sup> | ❔<sup>[[5]](#footnote-5)</sup> | ❌<sup>[[4]](#footnote-6)</sup>
| RenderPipeline | _UnityEngine.Rendering_.**FilteringSettings** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| RenderPipeline | _UnityEngine.Rendering_.**RenderQueueRange** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| RenderPipeline | _UnityEngine.Rendering_.**SortingLayerRange** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| RenderPipeline | _UnityEngine.Rendering_.**VisibleLight** | ❌<sup>[[2]](#footnote-2)</sup> | ❓<sup>[[3]](#footnote-3)</sup> | ❌<sup>[[2]](#footnote-2)</sup>
| Scripting | _UnityEngine_.**LayerMask** | ✔ | ✔ | ✔
| Scripting | _UnityEngine_.**RangeInt** | ✔ | ✔ | ✔
| SpriteShape | _UnityEngine.U2D_.**AngleRangeInfo** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| SpriteShape | _UnityEngine.U2D_.**ShapeControlPoint** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>
| SpriteShape | _UnityEngine.U2D_.**SpriteShapeMetaData** | ✔ | ✔ | ✖<sup>[[1]](#footnote-1)</sup>

1. ✖<a name="footnote-1"></a> Does not need a custom converter. Works out of the
    box as-is.

2. ❌<a name="footnote-2"></a> Contains ID or reference to _UnityEngine_.**Object** and
    will therefore never be deserializable.

3. ❓<a name="footnote-3"></a> Serializing this type is discouraged. Serializing
    this type will highly likely result in errors such as self referencing loops
    or infinite recursions.

4. ❌<a name="footnote-4"></a> Type directly or indirectly contains reference to
    the NativeArray or NativeSlice types. Deserializing these types may cause
    imminent memory leaks.

5. ❔<a name="footnote-5"></a> Serializing this type has not been tested nor
    proven to work. It is fully possible they work alright, but be wary.
    
6. ❌<a name="footnote-6"></a> Type contains fields marked as `readonly` and
    therefore has been left out. Possible to solve by using reflection tricks
    but this has been down prioritized.


## Legend

- **Module**: Most converters are created by referencing the GitHub repository
  for the Unity types made by Unity Technologies themselves.
  (<https://github.com/Unity-Technologies/UnityCsReference>)
  The "modules" concept is taken from there where all types are grouped by
  category instead of by namespace.

- **Type**: The namespace (in italic) and type name (in bold), giving the full
  name for said type.

- **Can read**: reading JSON is also known as "deserializing". Tómàtò-Tómátó.
  A green check mark ✔ here means that it has been proven via tests to
  deserialize when all significant data is specified in the JSON and
  successfully construct an instance of said type with no data loss.

- **Can write**: writing JSON is also known as "serializing". Where it writes
  JSON based on the values of the instance. A green check-mark ✔ here means
  that it has been proven via tests to serialize this type with no data loss.

- **Custom converter**: This package,
  jilleJr/Newtonsoft.Json-for-Unity.Converters, comes with a converter to
  resolve any serialization or deserialization bugs for said type, making it
  work as expected.

## Verified via tests

All types with green check-mark ✔ are proven to work via the suite of tests
found in this repository. The tests prove the types work in many obscure
scenarios in all of the following configurations:

| OS | Unity | Scripting runtime | API compatability mode |
| --- | --- | ---- | ---- |
| Linux | 2020.1.0b6 | Mono | .NET Standard 2.0
| Linux | 2019.2.11f1 | Mono | .NET Standard 2.0
| Linux | 2018.4.14f1 | Mono | .NET Standard 2.0
