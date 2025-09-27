using System;
using System.Linq;
using NUnit.Framework;

namespace Newtonsoft.Json.UnityConverters.Tests
{
    public class HiddenConverterTests
    {
        [Test]
        public void AssertHiddenConverterNotRegistered()
        {
            var registered = UnityConverterInitializer.defaultUnityConvertersSettings.Converters
                .Any(x => x.GetType() == typeof(TestHiddenJsonConverter));

            Assert.IsFalse(registered, "TestHiddenJsonConverter registered, but should not.");
        }

        [Test]
        public void AssertVisibleConverterRegistered()
        {
            var registered = UnityConverterInitializer.defaultUnityConvertersSettings.Converters
                .Any(x => x.GetType() == typeof(TestVisibleJsonConverter));

            Assert.IsTrue(registered, "TestVisibleJsonConverter not registered, but should be.");
        }


        [HideInJsonConverterSettings]
        internal class TestHiddenJsonConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType) => false;

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }


        internal class TestVisibleJsonConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType) => false;

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
    }
}
