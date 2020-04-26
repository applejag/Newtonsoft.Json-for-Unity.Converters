using System;
using System.Linq;
using System.Reflection;
using Random = UnityEngine.Random;

namespace Newtonsoft.Json.UnityConverters
{
    public class RandomStateConverter : PartialIntConverter<Random.State>
    {
        private static readonly string[] _memberNames = { "s0", "s1", "s2", "s3" };

        private static readonly FieldInfo[] _fieldInfos = _memberNames
            .Select(o => typeof(Random.State).GetField(o, BindingFlags.NonPublic | BindingFlags.Instance))
            .ToArray();

        public RandomStateConverter()
            : base(_memberNames)
        {
        }

        protected override Random.State CreateInstanceFromValues(ValuesArray<int> values)
        {
            var state = new Random.State();

            TypedReference reference = __makeref(state);
            _fieldInfos[0].SetValueDirect(reference, values[0]);
            _fieldInfos[1].SetValueDirect(reference, values[1]);
            _fieldInfos[2].SetValueDirect(reference, values[2]);
            _fieldInfos[3].SetValueDirect(reference, values[3]);

            return state;
        }

        protected override int[] ReadInstanceValues(Random.State instance)
        {
            return new [] {
                (int)_fieldInfos[0].GetValue(instance),
                (int)_fieldInfos[1].GetValue(instance),
                (int)_fieldInfos[2].GetValue(instance),
                (int)_fieldInfos[3].GetValue(instance),
            };
        }
    }
}
