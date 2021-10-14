#if HAVE_MODULE_AI || !UNITY_2019_1_OR_NEWER
using System;
using Newtonsoft.Json.UnityConverters.Helpers;
using UnityEngine;
using UnityEngine.AI;

namespace Newtonsoft.Json.UnityConverters.AI.NavMesh
{
    public class NavMeshQueryFilterConverter : PartialConverter<NavMeshQueryFilter>
    {
        // Magic number taken from /Modules/AI/NavMesh/NavMesh.bindings.cs
        // inside Unitys open source repo
        // https://github.com/Unity-Technologies/UnityCsReference/blob/2019.2/Modules/AI/NavMesh/NavMesh.bindings.cs#L149
        private const int AREA_COST_ELEMENT_COUNT = 32;

        protected override void ReadValue(ref NavMeshQueryFilter value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case "costs":
                    var costs = reader.ReadViaSerializer<float[]>(serializer);
                    if (costs != null)
                    {
                        for (int i = Mathf.Min(costs.Length, AREA_COST_ELEMENT_COUNT) - 1; i >= 0; i--)
                        {
                            value.SetAreaCost(i, costs[i]);
                        }
                    }
                    break;
                case nameof(value.areaMask):
                    value.areaMask = reader.ReadAsInt32() ?? 0;
                    break;
                case "agentTypeId": // camelCased the ID->Id
                    value.agentTypeID = reader.ReadAsInt32() ?? 0;
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, NavMeshQueryFilter value, JsonSerializer serializer)
        {
            writer.WritePropertyName("costs");
            writer.WriteStartArray();
            for (int i = 0; i < AREA_COST_ELEMENT_COUNT; i++)
            {
                writer.WriteValue(value.GetAreaCost(i));
            }
            writer.WriteEndArray();
            writer.WritePropertyName(nameof(value.areaMask));
            writer.WriteValue(value.areaMask);
            writer.WritePropertyName("agentTypeId"); // camelCased the ID->id
            writer.WriteValue(value.agentTypeID);
        }
    }
}
#endif
