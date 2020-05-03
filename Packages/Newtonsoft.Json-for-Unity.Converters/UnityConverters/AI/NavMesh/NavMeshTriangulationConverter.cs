using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;
using UnityEngine.AI;

namespace Newtonsoft.Json.UnityConverters.AI.NavMesh
{
    public class NavMeshTriangulationConverter : PartialConverter<NavMeshTriangulation, object>
    {
        private static readonly string[] _memberNames = { "vertices", "indices", "areas" };

        public NavMeshTriangulationConverter()
            : base(_memberNames)
        {
        }

        protected override NavMeshTriangulation CreateInstanceFromValues(ValuesArray<object> values)
        {
            return new NavMeshTriangulation {
                vertices = values[0] as Vector3[],
                indices = values[1] as int[],
                areas = values[2] as int[],
            };
        }

        [return: MaybeNull]
        protected override object[] ReadInstanceValues(NavMeshTriangulation instance)
        {
            return new object[] {
                instance.vertices,
                instance.indices,
                instance.areas
            };
        }

        [return: MaybeNull]
        protected override object ReadValue(JsonReader reader, int index, JsonSerializer serializer)
        {
            switch (index)
            {
            case 0:
                return reader.ReadViaSerializer<Vector3[]>(serializer);

            case 1:
            case 2:
                return reader.ReadViaSerializer<int[]>(serializer);

            default:
                throw new ArgumentOutOfRangeException(nameof(index), index, "Only accepts member index in range 0..2");
            }
        }

        protected override void WriteValue(JsonWriter writer, [AllowNull] object value, JsonSerializer serializer)
        {
            switch (value)
            {
            case null:
                writer.WriteNull();
                break;

            case Vector3[] vertices:
                writer.WriteStartArray();

                foreach (Vector3 vert in vertices)
                {
                    serializer.Serialize(writer, vert, typeof(Vector3));
                }

                writer.WriteEndArray();
                break;

            case int[] numArray:
                writer.WriteStartArray();

                foreach (int num in numArray)
                {
                    writer.WriteValue(num);
                }

                writer.WriteEndArray();
                break;

            default:
                throw writer.CreateWriterException($"Unexpected type '{value.GetType().Name}' when serializing {typeof(NavMeshTriangulation).FullName}");
            }
        }
    }
}
