using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Custom Newtonsoft.Json converter <see cref="JsonConverter"/> for the Unity byte based Color type <see cref="Color32"/>.
    /// </summary>
    public class Color32Converter : PartialByteConverter<Color32>
    {
        public Color32Converter()
            : base(ColorConverter._memberNames)
        {
        }

        protected override Color32 CreateInstanceFromValues(ValuesArray<byte> values)
        {
            return new Color32(values[0], values[1], values[2], values[3]);
        }

        protected override byte[] ReadInstanceValues(Color32 instance)
        {
            return new [] { instance.r, instance.g, instance.b, instance.a };
        }
    }
}
