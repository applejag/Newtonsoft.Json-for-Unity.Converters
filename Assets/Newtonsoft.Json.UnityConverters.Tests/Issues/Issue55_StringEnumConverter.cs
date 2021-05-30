using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Scripting;

namespace Newtonsoft.Json.UnityConverters.Tests
{
    public class Issue55_StringEnumConverter : TypeTesterBase
    {
        [Test]
        public void SerializesCorrectly()
        {
            // Arrange
            var myType = new MyType {
                myInt = 5,
                mySpaceEnum = Space.Self,
            };

            // Act
            string result = Serialize(myType);

            // Assert
            JObject jobj = Deserialize<JObject>(result);
            JToken mySpaceEnumToken = jobj["mySpaceEnum"];
            Assert.IsNotNull(mySpaceEnumToken, "JSON: " + result);
            Assert.AreEqual(JTokenType.String, mySpaceEnumToken.Type, "JSON: " + result);
            Assert.AreEqual("Self", mySpaceEnumToken.Value<string>(), "JSON: " + result);
        }

        [Preserve]
        public struct MyType
        {
            public int myInt;
            public Space mySpaceEnum;
        }
    }
}
