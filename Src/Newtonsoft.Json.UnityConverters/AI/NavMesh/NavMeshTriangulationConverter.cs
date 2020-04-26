using System;
using UnityEngine;
using UnityEngine.AI;

namespace Newtonsoft.Json.UnityConverters.AI.NavMesh
{
    public class NavMeshTriangulationConverter : PartialConverter<NavMeshTriangulation, object?>
    {
        private static readonly string[] _memberNames = { "vertices", "indices", "areas" };

        public NavMeshTriangulationConverter()
            : base(_memberNames)
        {
        }

        protected override NavMeshTriangulation CreateInstanceFromValues(ValuesArray<object?> values)
        {
            return new NavMeshTriangulation {
                vertices = values[0] as Vector3[],
                indices = values[1] as int[],
                areas = values[2] as int[],
            };
        }

        protected override object?[] ReadInstanceValues(NavMeshTriangulation instance)
        {
            return new object?[] {
                instance.vertices,
                instance.indices,
                instance.areas
            };
        }

        protected override object? ReadValue(JsonReader reader, int index, JsonSerializer serializer)
        {
            return index switch
            {
                0 => reader.ReadViaSerializer<Vector3[]?>(serializer),
                1 => reader.ReadViaSerializer<int[]?>(serializer),
                2 => reader.ReadViaSerializer<int[]?>(serializer),

                _ => throw new ArgumentOutOfRangeException(nameof(index), index, "Only accepts member index in range 0..2")
            };
        }

        protected override void WriteValue(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is null)
            {
                writer.WriteNull();
            }
            else if (value is Vector3[] vertices)
            {
                writer.WriteStartArray();

                foreach (Vector3 vert in vertices)
                {
                    serializer.Serialize(writer, vert, typeof(Vector3));
                }

                writer.WriteEndArray();
            }
            else if (value is int[] numArray)
            {
                writer.WriteStartArray();

                foreach (int num in numArray)
                {
                    writer.WriteValue(num);
                }

                writer.WriteEndArray();
            }
        }
    }
}
