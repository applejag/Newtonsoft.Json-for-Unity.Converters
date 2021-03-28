using System;
using System.Reflection;
using RandomState = UnityEngine.Random.State;
using Newtonsoft.Json.UnityConverters.Helpers;

namespace Newtonsoft.Json.UnityConverters.Random
{
    public class RandomStateConverter : PartialConverter<RandomState>
    {
        // If field does not exist it should invalidate the converter for
        // the entirety of the programs lifetime. Which is fine in this case.
        private static readonly FieldInfo _s0Field = typeof(RandomState).GetFieldInfoOrThrow("s0");
        private static readonly FieldInfo _s1Field = typeof(RandomState).GetFieldInfoOrThrow("s1");
        private static readonly FieldInfo _s2Field = typeof(RandomState).GetFieldInfoOrThrow("s2");
        private static readonly FieldInfo _s3Field = typeof(RandomState).GetFieldInfoOrThrow("s3");

        protected override void ReadValue(ref RandomState value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name) {
                case "s0":
                    _s0Field.SetValueDirectRef(ref value, reader.ReadAsInt32() ?? 0);
                    break;
                case "s1":
                    _s1Field.SetValueDirectRef(ref value, reader.ReadAsInt32() ?? 0);
                    break;
                case "s2":
                    _s2Field.SetValueDirectRef(ref value, reader.ReadAsInt32() ?? 0);
                    break;
                case "s3":
                    _s3Field.SetValueDirectRef(ref value, reader.ReadAsInt32() ?? 0);
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, RandomState value, JsonSerializer serializer)
        {
            writer.WritePropertyName("s0");
            writer.WriteValue(_s0Field.GetValue(value));
            writer.WritePropertyName("s1");
            writer.WriteValue(_s1Field.GetValue(value));
            writer.WritePropertyName("s2");
            writer.WriteValue(_s2Field.GetValue(value));
            writer.WritePropertyName("s3");
            writer.WriteValue(_s3Field.GetValue(value));
        }
    }
}
