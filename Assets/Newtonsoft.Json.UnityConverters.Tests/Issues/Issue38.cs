using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests
{
    public class Issue38 : TypeTesterBase
    {
        protected override void ConfigureSerializer(JsonSerializer serializer)
        {
            serializer.TypeNameHandling = TypeNameHandling.Auto;
        }

        [Test]
        public void DeserializesCorrectly()
        {
            // Arrange
            string json = $@"{{""vehicles"": [
                {{
                    ""$type"": ""{GetTypeNameWithAssembly(typeof(Car))}"",
                    ""id"": ""abc123"",
                    ""model"": ""Volvo V95""
                }},
                {{
                    ""$type"": ""{GetTypeNameWithAssembly(typeof(Boat))}"",
                    ""id"": ""def456"",
                    ""lengthMeters"": 12.5
                }}
            ] }}";

            // Act
            Data result = Deserialize<Data>(json);

            // Assert
            List<Vehicle> vehicles = result.GetVehicles();
            Assert.AreEqual(2, vehicles.Count, "data.vehicles.Count");
            Assert.IsInstanceOf<Car>(vehicles[0], "vehicles[0]");
            Assert.IsInstanceOf<Boat>(vehicles[1], "vehicles[1]");
        }

#pragma warning disable S1144 // Unused private types or members should be removed
#pragma warning disable S1104 // Make this field 'private' and encapsulate it in a 'public' property.
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value null
        private class Data : ScriptableObject
        {
            [SerializeField]
#pragma warning disable IDE1006 // Naming Styles
            private List<Vehicle> vehicles;
#pragma warning restore IDE1006 // Naming Styles

            public List<Vehicle> GetVehicles()
            {
                return vehicles;
            }
        }

        private abstract class Vehicle : ScriptableObject
        {
            public string id;
        }

        private class Car : Vehicle
        {
            public string model;
        }

        private class Boat : Vehicle
        {
            public float lengthMeters;
        }
#pragma warning restore CS0649 // Field is never assigned to, and will always have its default value null
#pragma warning restore S1104 // Make this field 'private' and encapsulate it in a 'public' property.
#pragma warning restore S1144 // Unused private types or members should be removed
    }
}
