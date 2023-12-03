# Unity types compatibility table

<!--
Footnotes superscript were generated with
https://beautifuldingbats.com/superscript-generator/
-->

| Module         | Type                                                            | Can read        | Can write       | Custom converter |
| -------------- | --------------------------------------------------------------- | --------------- | --------------- | ---------------- |
| Addressables   | *UnityEngine.AddressableAssets*.**AssetReference**              | ✔[⁽⁷⁾](#note-7) | ✔[⁽⁷⁾](#note-7) | ✔                |
| Addressables   | *UnityEngine.AddressableAssets*.**AssetReferenceT&lt;T&gt;**    | ✔[⁽⁷⁾](#note-7) | ✔[⁽⁷⁾](#note-7) | ✔                |
| AI/NavMesh     | *UnityEngine.<i></i>AI*.**NavMeshDataInstance**                 | ❌[⁽²⁾](#note-2) | ❓[⁽³⁾](#note-3) | ❌[⁽²⁾](#note-2)  |
| AI/NavMesh     | *UnityEngine.<i></i>AI*.**NavMeshHit**                          | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| AI/NavMesh     | *UnityEngine.<i></i>AI*.**NavMeshLinkData**                     | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| AI/NavMesh     | *UnityEngine.<i></i>AI*.**NavMeshLinkInstance**                 | ❌[⁽²⁾](#note-2) | ❓[⁽³⁾](#note-3) | ❌[⁽²⁾](#note-2)  |
| AI/NavMesh     | *UnityEngine.<i></i>AI*.**NavMeshQueryFilter**                  | ✔               | ✔               | ✔                |
| AI/NavMesh     | *UnityEngine.<i></i>AI*.**NavMeshTriangulation**                | ✔               | ✔               | ✔                |
| Animation      | *UnityEngine*.**Keyframe**                                      | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Camera         | *UnityEngine*.**BoundingSphere**                                | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Camera         | *UnityEngine*.**CullingGroupEvent**                             | ✔               | ✔               | ✔                |
| GameCenter     | *UnityEngine.SocialPlatforms*.**Range**                         | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Geometry       | *UnityEngine*.**Bounds**                                        | ✔               | ✔               | ✔                |
| Geometry       | *UnityEngine*.**BoundsInt**                                     | ✔               | ✔               | ✔                |
| Geometry       | *UnityEngine*.**Plane**                                         | ✔               | ✔               | ✔                |
| Geometry       | *UnityEngine*.**Ray**                                           | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Geometry       | *UnityEngine*.**Ray2D**                                         | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Geometry       | *UnityEngine*.**Rect**                                          | ✔               | ✔               | ✔                |
| Geometry       | *UnityEngine*.**RectInt**                                       | ✔               | ✔               | ✔                |
| Geometry       | *UnityEngine*.**RectOffset**                                    | ✔               | ✔               | ✔                |
| Graphics       | *UnityEngine*.**Resolution**                                    | ✔               | ✔               | ✔                |
| Hashing        | *UnityEngine*.**Hash128**                                       | ✔               | ✔               | ✔                |
| Math           | *UnityEngine*.**Color**                                         | ✔               | ✔               | ✔                |
| Math           | *UnityEngine*.**Color32**                                       | ✔               | ✔               | ✔                |
| Math           | *UnityEngine*.**FrustumPlanes**                                 | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Math           | *UnityEngine*.**Gradient**                                      | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Math           | *UnityEngine*.**GradientAlphaKey**                              | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Math           | *UnityEngine*.**GradientColorKey**                              | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Math           | *UnityEngine*.**Matrix4x4**                                     | ✔               | ✔               | ✔                |
| Math           | *UnityEngine*.**Quaternion**                                    | ✔               | ✔               | ✔                |
| Math           | *UnityEngine*.**Vector2**                                       | ✔               | ✔               | ✔                |
| Math           | *UnityEngine*.**Vector2Int**                                    | ✔               | ✔               | ✔                |
| Math           | *UnityEngine*.**Vector3**                                       | ✔               | ✔               | ✔                |
| Math           | *UnityEngine*.**Vector3Int**                                    | ✔               | ✔               | ✔                |
| Math           | *UnityEngine*.**Vector4**                                       | ✔               | ✔               | ✔                |
| Math           | *UnityEngine.Rendering*.**SphericalHarmonicsL2**                | ✔               | ✔               | ✔                |
| Mathematics    | *Unity.Mathematics*.**half**                                    | ✔[⁽⁹⁾](#note-9) | ✔[⁽⁹⁾](#note-9)  | ✔                |
| Mathematics    | *Unity.Mathematics*.**boolN** [⁽⁸⁾](#note-8)                    | ✔[⁽⁹⁾](#note-9) | ✔[⁽⁹⁾](#note-9)  | ✔                |
| Mathematics    | *Unity.Mathematics*.**doubleN** [⁽⁸⁾](#note-8)                  | ✔[⁽⁹⁾](#note-9) | ✔[⁽⁹⁾](#note-9)  | ✔                |
| Mathematics    | *Unity.Mathematics*.**floatN** [⁽⁸⁾](#note-8)                   | ✔[⁽⁹⁾](#note-9) | ✔[⁽⁹⁾](#note-9)  | ✔                |
| Mathematics    | *Unity.Mathematics*.**halfN** [⁽⁸⁾](#note-8)                    | ✔[⁽⁹⁾](#note-9) | ✔[⁽⁹⁾](#note-9)  | ✔                |
| Mathematics    | *Unity.Mathematics*.**intN** [⁽⁸⁾](#note-8)                     | ✔[⁽⁹⁾](#note-9) | ✔[⁽⁹⁾](#note-9)  | ✔                |
| Mathematics    | *Unity.Mathematics*.**uintN** [⁽⁸⁾](#note-8)                    | ✔[⁽⁹⁾](#note-9) | ✔[⁽⁹⁾](#note-9)  | ✔                |
| Mathematics    | *Unity.Mathematics*.**boolNxN** [⁽⁸⁾](#note-8)                  | ✔                | ✔              | ✖[⁽¹⁾](#note-1)  |
| Mathematics    | *Unity.Mathematics*.**doubleNxN** [⁽⁸⁾](#note-8)                | ✔                | ✔              | ✖[⁽¹⁾](#note-1)  |
| Mathematics    | *Unity.Mathematics*.**floatNxN** [⁽⁸⁾](#note-8)                 | ✔                | ✔              | ✖[⁽¹⁾](#note-1)  |
| Mathematics    | *Unity.Mathematics*.**intNxN** [⁽⁸⁾](#note-8)                   | ✔                | ✔              | ✖[⁽¹⁾](#note-1)  |
| Mathematics    | *Unity.Mathematics*.**uintNxN** [⁽⁸⁾](#note-8)                  | ✔                | ✔              | ✖[⁽¹⁾](#note-1)  |
| NativeArray    | *Unity.Collections*.**NativeArray&lt;T&gt;**                    | ❌[⁽⁴⁾](#note-4) | ✔               | ✔                |
| NativeArray    | *Unity.Collections*.**NativeSlice&lt;T&gt;**                    | ❌[⁽⁴⁾](#note-4) | ✔               | ✔                |
| ParticleSystem | *UnityEngine.ParticleSystemJobs*.**ParticleSystemJobData**      | ❌[⁽⁴⁾](#note-4) | ❔[⁽⁵⁾](#note-5) | ❌[⁽⁴⁾](#note-4)  |
| ParticleSystem | *UnityEngine.ParticleSystemJobs*.**ParticleSystemNativeArray3** | ❌[⁽⁴⁾](#note-4) | ❔[⁽⁵⁾](#note-5) | ❌[⁽⁴⁾](#note-4)  |
| ParticleSystem | *UnityEngine.ParticleSystemJobs*.**ParticleSystemNativeArray4** | ❌[⁽⁴⁾](#note-4) | ❔[⁽⁵⁾](#note-5) | ❌[⁽⁴⁾](#note-4)  |
| Physics        | *UnityEngine*.**BoxcastCommand**                                | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics        | *UnityEngine*.**CapsulecastCommand**                            | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics        | *UnityEngine*.**ContactPoint**                                  | ❌[⁽²⁾](#note-2) | ❓[⁽³⁾](#note-3) | ❌[⁽²⁾](#note-2)  |
| Physics        | *UnityEngine*.**JointDrive**                                    | ✔               | ✔               | ✔                |
| Physics        | *UnityEngine*.**JointLimits**                                   | ✔               | ✔               | ✔                |
| Physics        | *UnityEngine*.**JointMotor**                                    | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics        | *UnityEngine*.**JointSpring**                                   | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics        | *UnityEngine*.**PhysicsScene**                                  | ❌[⁽²⁾](#note-2) | ❓[⁽³⁾](#note-3) | ❌[⁽²⁾](#note-2)  |
| Physics        | *UnityEngine*.**RaycastCommand**                                | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics        | *UnityEngine*.**RaycastHit**                                    | ❌[⁽²⁾](#note-2) | ❓[⁽³⁾](#note-3) | ❌[⁽²⁾](#note-2)  |
| Physics        | *UnityEngine*.**SoftJointLimit**                                | ✔               | ✔               | ✔                |
| Physics        | *UnityEngine*.**SoftJointLimitSpring**                          | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics        | *UnityEngine*.**SpherecastCommand**                             | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics        | *UnityEngine*.**WheelFrictionCurve**                            | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics2D      | *UnityEngine*.**ColliderDistance2D**                            | ✔               | ✔               | ✔                |
| Physics2D      | *UnityEngine*.**ContactFilter2D**                               | ✔               | ✔               | ✔                |
| Physics2D      | *UnityEngine*.**ContactPoint2D**                                | ❌[⁽²⁾](#note-2) | ❓[⁽³⁾](#note-3) | ❌[⁽²⁾](#note-2)  |
| Physics2D      | *UnityEngine*.**JointAngleLimits2D**                            | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics2D      | *UnityEngine*.**JointMotor2D**                                  | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics2D      | *UnityEngine*.**JointSuspension2D**                             | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics2D      | *UnityEngine*.**JointTranslationLimits2D**                      | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics2D      | *UnityEngine*.**PhysicsJobOptions2D**                           | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics2D      | *UnityEngine*.**PhysicsScene2D**                                | ❌[⁽²⁾](#note-2) | ❓[⁽³⁾](#note-3) | ❌[⁽²⁾](#note-2)  |
| Physics2D      | *UnityEngine*.**RaycastHit2D**                                  | ❌[⁽²⁾](#note-2) | ❓[⁽³⁾](#note-3) | ❌[⁽²⁾](#note-2)  |
| Random         | *UnityEngine*.**Random.State**                                  | ✔               | ✔               | ✔                |
| Rendering      | *UnityEngine.Rendering*.**BatchCullingContext**                 | ❌[⁽⁴⁾](#note-4) | ❔[⁽⁵⁾](#note-5) | ❌[⁽⁴⁾](#note-4)  |
| Rendering      | *UnityEngine.Rendering*.**BatchVisibility**                     | ❌[⁽⁶⁾](#note-6) | ❔[⁽⁵⁾](#note-5) | ❌[⁽⁶⁾](#note-6)  |
| RenderPipeline | *UnityEngine.Rendering*.**FilteringSettings**                   | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| RenderPipeline | *UnityEngine.Rendering*.**RenderQueueRange**                    | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| RenderPipeline | *UnityEngine.Rendering*.**SortingLayerRange**                   | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| RenderPipeline | *UnityEngine.Rendering*.**VisibleLight**                        | ❌[⁽²⁾](#note-2) | ❓[⁽³⁾](#note-3) | ❌[⁽²⁾](#note-2)  |
| Scripting      | *UnityEngine*.**LayerMask**                                     | ✔               | ✔               | ✔                |
| Scripting      | *UnityEngine*.**RangeInt**                                      | ✔               | ✔               | ✔                |
| Scripting      | *UnityEngine*.**ScriptableObject**                              | ✔               | ✔               | ✔                |
| SpriteShape    | *UnityEngine.U2D*.**AngleRangeInfo**                            | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| SpriteShape    | *UnityEngine.U2D*.**ShapeControlPoint**                         | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| SpriteShape    | *UnityEngine.U2D*.**SpriteShapeMetaData**                       | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |

1. ✖<a name="note-1"></a> Does not need a custom converter. Works out of the
  box as-is.

2. ❌<a name="note-2"></a> Contains ID or reference to *UnityEngine*.**Object** and
  will therefore never be deserializable.

3. ❓<a name="note-3"></a> Serializing this type is discouraged. Serializing
  this type will highly likely result in errors such as self referencing loops
  or infinite recursions.

4. ❌<a name="note-4"></a> Type directly or indirectly contains reference to
  the NativeArray or NativeSlice types. Deserializing these types will cause
  imminent memory leaks and so deserializing (reading JSON) using these types
  are therefore highly discouraged.

5. ❔<a name="note-5"></a> Serializing this type has not been tested nor
  proven to work. It is fully possible they work alright, but be wary.

6. ❌<a name="note-6"></a> Type contains fields marked as `readonly` and
  therefore has been left out. Possible to solve by using reflection tricks
  but this has been down prioritized.

7. ✔<a name="note-7"></a> Support for [Addressables](https://docs.unity3d.com/Packages/com.unity.addressables@2.0/manual/index.html)
  package, which was added in v1.4.0, is only automatically included if your
  Unity project has imported the `com.unity.addressable` package.
  This automatic inclusion relies on AssemblyDefinition version defines,
  which was introduced in Unity 2019.1.x.
  To enable the `AssetReferenceConverter` in earlier versions of Unity,
  please add `HAVE_MODULE_ADDRESSABLES` to your project's
  "Scripting Define Symbols" found in the
  "Project Settings" -> "Player" -> "Other Settings" panel.

8. ✔<a name="note-8"></a> The `N` in `floatN`, `intN`, etc. stands for all the
  different vector types available in [Unity.Mathematics](https://docs.unity3d.com/Packages/com.unity.mathematics@1.3/api/Unity.Mathematics.html):
  `float2`, `float3`, `float4`, etc.
  Similarly, the `NxN` in `floatNxN`, `intNxN`, etc. stands for all the
  different matrix types: `float2x2`, `float2x3`, `float4x4`, etc.

9. ✔<a name="note-9"></a> Support for [Mathematics](https://docs.unity3d.com/Packages/com.unity.mathematics@1.3/manual/index.html)
  package, which was added in v1.6.0, is only automatically included if your
  Unity project has imported the `com.unity.mathematics` package.
  This automatic inclusion relies on AssemblyDefinition version defines,
  which was introduced in Unity 2019.1.x.
  To enable for example the `Float3Converter` in earlier versions of Unity,
  please add `HAVE_MODULE_MATHEMATICS` to your project's
  "Scripting Define Symbols" found in the
  "Project Settings" -> "Player" -> "Other Settings" panel.

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

| OS    | Unity       | Json .NET for Unity version |
| ----- | ----------- | --------------------------- |
| Linux | 2020.1.0b6  | 13.0.102                    |
| -     | -           | 12.0.302                    |
| -     | -           | 11.0.202                    |
| -     | -           | 10.0.302                    |
| -     | 2019.2.11f1 | 13.0.102                    |
| -     | -           | 12.0.302                    |
| -     | -           | 11.0.202                    |
| -     | -           | 10.0.302                    |
| -     | 2018.4.14f1 | 13.0.102                    |
| -     | -           | 12.0.302                    |
| -     | -           | 11.0.202                    |
| -     | -           | 10.0.302                    |
