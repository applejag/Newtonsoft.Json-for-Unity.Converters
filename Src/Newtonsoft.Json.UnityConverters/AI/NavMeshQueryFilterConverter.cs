using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.AI;

namespace Newtonsoft.Json.UnityConverters.AI
{
    public class NavMeshQueryFilterConverter : PartialConverter<NavMeshQueryFilter, object?>
    {
        // Taken from /Modules/AI/NavMesh/NavMesh.bindings.cs
        // inside Unitys open source repo
        // https://github.com/Unity-Technologies/UnityCsReference/blob/2019.2/Modules/AI/NavMesh/NavMesh.bindings.cs#L149
        private const int AREA_COST_ELEMENT_COUNT = 32;

        private static readonly string[] _memberNames = { "costs", "areaMask", "agentTypeId" };

        public NavMeshQueryFilterConverter()
            : base(_memberNames)
        {
        }

        protected override NavMeshQueryFilter CreateInstanceFromValues(ValuesArray<object> values)
        {
            var instance = new NavMeshQueryFilter {
                areaMask = values[1] as int? ?? 0,
                agentTypeID = values[2] as int? ?? 0,
            };

            float[]? costs = values[0] as float[];
            for (int i = 0; i < costs.Length; i++)
            {
                instance.SetAreaCost(i, costs[i]);
            }

            return instance;
        }

        protected override object?[] ReadInstanceValues(NavMeshQueryFilter instance)
        {
            float[] costs = new float[AREA_COST_ELEMENT_COUNT];
            for (int i = 0; i < AREA_COST_ELEMENT_COUNT; i++)
            {
                costs[i] = instance.GetAreaCost(i);
            }

            return new object?[] {
                costs,
                instance.areaMask,
                instance.agentTypeID,
            };
        }

        protected override object? ReadValue(JsonReader reader, int index, JsonSerializer serializer)
        {
            return index switch
            {
                0 => reader.ReadViaSerializer<float[]>(serializer) ?? new float[AREA_COST_ELEMENT_COUNT],
                1 => reader.ReadAsInt32() ?? 0,
                2 => reader.ReadAsInt32() ?? 0,

                _ => throw new ArgumentOutOfRangeException(nameof(index), index, "Only accepts member index in range 0..2")
            };
        }
        
        protected override void WriteValue(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is float[] costs)
            {
                writer.WriteStartArray();

                for (int i = 0; i < costs.Length; i++)
                {
                    writer.WriteValue(costs[i]);
                }

                writer.WriteEndArray();
            }
            else if (value is int num)
            {
                writer.WriteValue(num);
            }
        }
    }
}
