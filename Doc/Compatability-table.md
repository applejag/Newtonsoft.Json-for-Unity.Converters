# Unity types compatibility table

<!--
Footnotes superscript were generated with
https://beautifuldingbats.com/superscript-generator/
-->

| Module         | Type                                                            | Can read        | Can write       | Custom converter |
| -------------- | --------------------------------------------------------------- | --------------- | --------------- | ---------------- |
| AI/NavMesh     | _UnityEngine.<i></i>AI_.**NavMeshDataInstance**                 | ❌[⁽²⁾](#note-2) | ❓[⁽³⁾](#note-3) | ❌[⁽²⁾](#note-2)  |
| AI/NavMesh     | _UnityEngine.<i></i>AI_.**NavMeshHit**                          | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| AI/NavMesh     | _UnityEngine.<i></i>AI_.**NavMeshLinkData**                     | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| AI/NavMesh     | _UnityEngine.<i></i>AI_.**NavMeshLinkInstance**                 | ❌[⁽²⁾](#note-2) | ❓[⁽³⁾](#note-3) | ❌[⁽²⁾](#note-2)  |
| AI/NavMesh     | _UnityEngine.<i></i>AI_.**NavMeshQueryFilter**                  | ✔               | ✔               | ✔                |
| AI/NavMesh     | _UnityEngine.<i></i>AI_.**NavMeshTriangulation**                | ✔               | ✔               | ✔                |
| Animation      | _UnityEngine_.**Keyframe**                                      | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Camera         | _UnityEngine_.**BoundingSphere**                                | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Camera         | _UnityEngine_.**CullingGroupEvent**                             | ✔               | ✔               | ✔                |
| GameCenter     | _UnityEngine.SocialPlatforms_.**Range**                         | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Geometry       | _UnityEngine_.**Bounds**                                        | ✔               | ✔               | ✔                |
| Geometry       | _UnityEngine_.**BoundsInt**                                     | ✔               | ✔               | ✔                |
| Geometry       | _UnityEngine_.**Plane**                                         | ✔               | ✔               | ✔                |
| Geometry       | _UnityEngine_.**Ray**                                           | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Geometry       | _UnityEngine_.**Ray2D**                                         | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Geometry       | _UnityEngine_.**Rect**                                          | ✔               | ✔               | ✔                |
| Geometry       | _UnityEngine_.**RectInt**                                       | ✔               | ✔               | ✔                |
| Geometry       | _UnityEngine_.**RectOffset**                                    | ✔               | ✔               | ✔                |
| Graphics       | _UnityEngine_.**Resolution**                                    | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Hashing        | _UnityEngine_.**Hash128**                                       | ✔               | ✔               | ✔                |
| Math           | _UnityEngine_.**Color**                                         | ✔               | ✔               | ✔                |
| Math           | _UnityEngine_.**Color32**                                       | ✔               | ✔               | ✔                |
| Math           | _UnityEngine_.**FrustumPlanes**                                 | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Math           | _UnityEngine_.**Gradient**                                      | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Math           | _UnityEngine_.**GradientAlphaKey**                              | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Math           | _UnityEngine_.**GradientColorKey**                              | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Math           | _UnityEngine_.**Quaternion**                                    | ✔               | ✔               | ✔                |
| Math           | _UnityEngine.Rendering_.**SphericalHarmonicsL2**                | ✔               | ✔               | ✔                |
| Math           | _UnityEngine_.**Vector2**                                       | ✔               | ✔               | ✔                |
| Math           | _UnityEngine_.**Vector2Int**                                    | ✔               | ✔               | ✔                |
| Math           | _UnityEngine_.**Vector3**                                       | ✔               | ✔               | ✔                |
| Math           | _UnityEngine_.**Vector3Int**                                    | ✔               | ✔               | ✔                |
| Math           | _UnityEngine_.**Vector4**                                       | ✔               | ✔               | ✔                |
| NativeArray    | _Unity.Collections_.**NativeArray&lt;T&gt;**                    | ❌[⁽⁴⁾](#note-4) | ✔               | ✔                |
| NativeArray    | _Unity.Collections_.**NativeSlice&lt;T&gt;**                    | ❌[⁽⁴⁾](#note-4) | ✔               | ✔                |
| ParticleSystem | _UnityEngine.ParticleSystemJobs_.**ParticleSystemJobData**      | ❌[⁽⁴⁾](#note-4) | ❔[⁽⁵⁾](#note-5) | ❌[⁽⁴⁾](#note-4)  |
| ParticleSystem | _UnityEngine.ParticleSystemJobs_.**ParticleSystemNativeArray3** | ❌[⁽⁴⁾](#note-4) | ❔[⁽⁵⁾](#note-5) | ❌[⁽⁴⁾](#note-4)  |
| ParticleSystem | _UnityEngine.ParticleSystemJobs_.**ParticleSystemNativeArray4** | ❌[⁽⁴⁾](#note-4) | ❔[⁽⁵⁾](#note-5) | ❌[⁽⁴⁾](#note-4)  |
| Physics        | _UnityEngine_.**BoxcastCommand**                                | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics        | _UnityEngine_.**CapsulecastCommand**                            | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics        | _UnityEngine_.**ContactPoint**                                  | ❌[⁽²⁾](#note-2) | ❓[⁽³⁾](#note-3) | ❌[⁽²⁾](#note-2)  |
| Physics        | _UnityEngine_.**JointDrive**                                    | ✔               | ✔               | ✔                |
| Physics        | _UnityEngine_.**JointLimits**                                   | ✔               | ✔               | ✔                |
| Physics        | _UnityEngine_.**JointMotor**                                    | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics        | _UnityEngine_.**JointSpring**                                   | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics        | _UnityEngine_.**PhysicsScene**                                  | ❌[⁽²⁾](#note-2) | ❓[⁽³⁾](#note-3) | ❌[⁽²⁾](#note-2)  |
| Physics        | _UnityEngine_.**RaycastCommand**                                | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics        | _UnityEngine_.**RaycastHit**                                    | ❌[⁽²⁾](#note-2) | ❓[⁽³⁾](#note-3) | ❌[⁽²⁾](#note-2)  |
| Physics        | _UnityEngine_.**SoftJointLimit**                                | ✔               | ✔               | ✔                |
| Physics        | _UnityEngine_.**SoftJointLimitSpring**                          | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics        | _UnityEngine_.**SpherecastCommand**                             | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics        | _UnityEngine_.**WheelFrictionCurve**                            | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics2D      | _UnityEngine_.**ColliderDistance2D**                            | ✔               | ✔               | ✔                |
| Physics2D      | _UnityEngine_.**ContactFilter2D**                               | ✔               | ✔               | ✔                |
| Physics2D      | _UnityEngine_.**ContactPoint2D**                                | ❌[⁽²⁾](#note-2) | ❓[⁽³⁾](#note-3) | ❌[⁽²⁾](#note-2)  |
| Physics2D      | _UnityEngine_.**JointAngleLimits2D**                            | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics2D      | _UnityEngine_.**JointMotor2D**                                  | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics2D      | _UnityEngine_.**JointSuspension2D**                             | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics2D      | _UnityEngine_.**JointTranslationLimits2D**                      | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics2D      | _UnityEngine_.**PhysicsJobOptions2D**                           | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| Physics2D      | _UnityEngine_.**PhysicsScene2D**                                | ❌[⁽²⁾](#note-2) | ❓[⁽³⁾](#note-3) | ❌[⁽²⁾](#note-2)  |
| Physics2D      | _UnityEngine_.**RaycastHit2D**                                  | ❌[⁽²⁾](#note-2) | ❓[⁽³⁾](#note-3) | ❌[⁽²⁾](#note-2)  |
| Random         | _UnityEngine_.**Random.State**                                  | ✔               | ✔               | ✔                |
| Rendering      | _UnityEngine.Rendering_.**BatchCullingContext**                 | ❌[⁽⁴⁾](#note-4) | ❔[⁽⁵⁾](#note-5) | ❌[⁽⁴⁾](#note-4)  |
| Rendering      | _UnityEngine.Rendering_.**BatchVisibility**                     | ❌[⁽⁶⁾](#note-6) | ❔[⁽⁵⁾](#note-5) | ❌[⁽⁶⁾](#note-6)  |
| RenderPipeline | _UnityEngine.Rendering_.**FilteringSettings**                   | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| RenderPipeline | _UnityEngine.Rendering_.**RenderQueueRange**                    | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| RenderPipeline | _UnityEngine.Rendering_.**SortingLayerRange**                   | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| RenderPipeline | _UnityEngine.Rendering_.**VisibleLight**                        | ❌[⁽²⁾](#note-2) | ❓[⁽³⁾](#note-3) | ❌[⁽²⁾](#note-2)  |
| Scripting      | _UnityEngine_.**LayerMask**                                     | ✔               | ✔               | ✔                |
| Scripting      | _UnityEngine_.**RangeInt**                                      | ✔               | ✔               | ✔                |
| SpriteShape    | _UnityEngine.U2D_.**AngleRangeInfo**                            | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| SpriteShape    | _UnityEngine.U2D_.**ShapeControlPoint**                         | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |
| SpriteShape    | _UnityEngine.U2D_.**SpriteShapeMetaData**                       | ✔               | ✔               | ✖[⁽¹⁾](#note-1)  |

1. ✖<a name="note-1"></a> Does not need a custom converter. Works out of the
  box as-is.

2. ❌<a name="note-2"></a> Contains ID or reference to _UnityEngine_.**Object** and
  will therefore never be deserializable.

3. ❓<a name="note-3"></a> Serializing this type is discouraged. Serializing
  this type will highly likely result in errors such as self referencing loops
  or infinite recursions.

4. ❌<a name="note-4"></a> Type directly or indirectly contains reference to
  the NativeArray or NativeSlice types. Deserializing these types will cause
  imminent memory leaks and so deserializing (writing JSON) using these types
  are therefore highly discouraged.

5. ❔<a name="note-5"></a> Serializing this type has not been tested nor
  proven to work. It is fully possible they work alright, but be wary.

6. ❌<a name="note-6"></a> Type contains fields marked as `readonly` and
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

| OS    | Unity       | Scripting runtime | API compatability mode |
| ----- | ----------- | ----------------- | ---------------------- |
| Linux | 2020.1.0b6  | Mono              | .NET Standard 2.0      |
| Linux | 2019.2.11f1 | Mono              | .NET Standard 2.0      |
| Linux | 2018.4.14f1 | Mono              | .NET Standard 2.0      |
