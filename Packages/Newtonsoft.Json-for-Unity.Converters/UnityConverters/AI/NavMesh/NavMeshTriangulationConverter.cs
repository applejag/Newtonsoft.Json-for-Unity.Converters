#if HAVE_MODULE_AI || !UNITY_2019_1_OR_NEWER
using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;
using UnityEngine.AI;

namespace Newtonsoft.Json.UnityConverters.AI.NavMesh
{
    public class NavMeshTriangulationConverter : PartialConverter<NavMeshTriangulation>
    {
        protected override void ReadValue(ref NavMeshTriangulation value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.vertices):
                    value.vertices = reader.ReadViaSerializer<Vector3[]>(serializer);
                    break;
                case nameof(value.indices):
                    value.indices = reader.ReadViaSerializer<int[]>(serializer);
                    break;
                case nameof(value.areas):
                    value.areas = reader.ReadViaSerializer<int[]>(serializer);
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, NavMeshTriangulation value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.vertices));
            serializer.Serialize(writer, value.vertices, typeof(Vector3[]));
            writer.WritePropertyName(nameof(value.indices));
            serializer.Serialize(writer, value.indices, typeof(int[]));
            writer.WritePropertyName(nameof(value.areas));
            serializer.Serialize(writer, value.areas, typeof(int[]));
        }
    }
}
#endif
