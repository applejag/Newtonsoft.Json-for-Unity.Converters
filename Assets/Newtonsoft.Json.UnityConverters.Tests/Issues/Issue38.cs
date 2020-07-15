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

        public class Data : ScriptableObject
        {
            [SerializeField]
            private List<Vehicle> vehicles;

            public List<Vehicle> GetVehicles()
            {
                return vehicles;
            }
        }

        public abstract class Vehicle : ScriptableObject
        {
            public string id;
        }

        public class Car : Vehicle
        {
            public string model;
        }

        public class Boat : Vehicle
        {
            public float lengthMeters;
        }
    }
}
