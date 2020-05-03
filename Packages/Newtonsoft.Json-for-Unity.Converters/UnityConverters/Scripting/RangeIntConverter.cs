using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Scripting
{
    public class RangeIntConverter : PartialIntConverter<RangeInt>
    {
        private static readonly string[] _memberNames = { "start", "length" };

        public RangeIntConverter() : base(_memberNames)
        {
        }

        protected override RangeInt CreateInstanceFromValues(ValuesArray<int> values)
        {
            return new RangeInt(values[0], values[1]);
        }

        protected override int[] ReadInstanceValues(RangeInt instance)
        {
            return new[] { instance.start, instance.length };
        }
    }
}
