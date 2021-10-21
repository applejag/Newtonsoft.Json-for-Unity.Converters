#if HAVE_MODULE_PHYSICS2D || !UNITY_2019_1_OR_NEWER
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.UnityConverters.Physics2D;
using NUnit.Framework;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Tests.Physics2D
{
    public class ContactFilter2DTests : ValueTypeTester<ContactFilter2D>
    {
        public static readonly IReadOnlyCollection<(ContactFilter2D deserialized, object anonymous)> representations = new (ContactFilter2D, object)[] {
            (new ContactFilter2D(), new {
                useTriggers = false,
                useLayerMask = false,
                useDepth = false,
                useOutsideDepth = false,
                useNormalAngle = false,
                useOutsideNormalAngle = false,
                layerMask = 0,
                minDepth = 0f,
                maxDepth = 0f,
                minNormalAngle = 0f,
                maxNormalAngle = 0f,
            }),
            (new ContactFilter2D {
                useTriggers = true,
                useLayerMask = true,
                useDepth = true,
                useOutsideDepth = true,
                useNormalAngle = true,
                useOutsideNormalAngle = true,
                layerMask = new LayerMask { value = 1 },
                minDepth = 2,
                maxDepth = 3,
                minNormalAngle = 4,
                maxNormalAngle = 5,
            }, new {
                useTriggers = true,
                useLayerMask = true,
                useDepth = true,
                useOutsideDepth = true,
                useNormalAngle = true,
                useOutsideNormalAngle = true,
                layerMask = 1,
                minDepth = 2f,
                maxDepth = 3f,
                minNormalAngle = 4f,
                maxNormalAngle = 5f,
            }),
        };

        [Test]
        public void WithConverterItDoesntSerializesIsFiltering()
        {
            // Arrange
            var input = new ContactFilter2D();
            var settings = new JsonSerializerSettings {
                Formatting = Formatting.None,
                Converters = new List<JsonConverter> {
                    new ContactFilter2DConverter()
                }
            };

            var serializer = JsonSerializer.Create(settings);

            // Act
            string result = Serialize(input, serializer);

            // Assert
            var jobj = JObject.Parse(result);

            Assert.IsNull(jobj["isFiltering"], "Serialized: " + result);
        }

        [Test]
        public void WithoutConverterItAlsoSerializesIsFiltering()
        {
            // Arrange
            var input = new ContactFilter2D();
            var settings = new JsonSerializerSettings {
                Formatting = Formatting.None,
                Converters = new List<JsonConverter>(),
            };

            var serializer = JsonSerializer.Create(settings);

            // Act
            string result = Serialize(input, serializer);

            // Assert
            var jobj = JObject.Parse(result);

            Assert.IsNotNull(jobj["isFiltering"], "Serialized: " + result);
        }
    }
}
#endif
