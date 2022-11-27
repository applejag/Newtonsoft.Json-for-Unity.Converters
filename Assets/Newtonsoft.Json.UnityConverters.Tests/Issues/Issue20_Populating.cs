using NUnit.Framework;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests
{
    public class Issue20_Populating : TypeTesterBase
    {
        [Test]
        public void PopulatesExistingProperty()
        {
            // Arrange
            // Wrapping in yet another object for Newtonsoft.Json's populate
            // algo to really kick in.
            // Otherwise it just seems to do JSON diffing
            var input = new MyClass { myProperty = new Vector3(1, 2, 3) };
            string json = Serialize(new { myProperty = new { y = 8 } });
            var expectedProp = new Vector3(1, 8, 3);

            // Act
            Populate(json, input);

            // Assert
            Assert.AreEqual(expectedProp, input.myProperty, "JSON: " + json);
        }

        [Test]
        public void PopulatesExistingField()
        {
            // Arrange
            // Wrapping in yet another object for Newtonsoft.Json's populate
            // algo to really kick in.
            // Otherwise it just seems to do JSON diffing
            var input = new MyClass { myField = new Vector3(4, 5, 6) };
            string json = Serialize(new { myField = new { y = 9 } });
            var expectedField = new Vector3(4, 9, 6);

            // Act
            Populate(json, input);

            // Assert
            Assert.AreEqual(expectedField, input.myField, "JSON: " + json);
        }

        private class MyClass
        {
            public Vector3 myProperty { get; set; }

            public Vector3 myField;
        }
    }
}
