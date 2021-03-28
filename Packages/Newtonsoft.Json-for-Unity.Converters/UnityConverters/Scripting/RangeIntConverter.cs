using Unity.Collections;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Scripting
{
    public class RangeIntConverter : PartialConverter<RangeInt>
    {
        protected override void ReadValue(ref RangeInt value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name) {
                case nameof(value.start):
                    value.start = reader.ReadAsInt32() ?? 0;
                    break;

                case nameof(value.length):
                    value.length = reader.ReadAsInt32() ?? 0;
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, RangeInt value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.start));
            writer.WriteValue(value.start);
            writer.WritePropertyName(nameof(value.length));
            writer.WriteValue(value.length);
        }
    }
}
