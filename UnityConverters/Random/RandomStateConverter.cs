using System;
using System.Reflection;
using RandomState = UnityEngine.Random.State;

namespace Newtonsoft.Json.UnityConverters.Random
{
    public class RandomStateConverter : PartialIntConverter<RandomState>
    {
        private static readonly string[] _memberNames = { "s0", "s1", "s2", "s3" };

        // If field does not exist it should invalidate the converter for
        // the entirety of the programs lifetime. Which is fine in this case.
        private static readonly FieldInfo _s0Field = GetFieldInfoOrThrow("s0");
        private static readonly FieldInfo _s1Field = GetFieldInfoOrThrow("s1");
        private static readonly FieldInfo _s2Field = GetFieldInfoOrThrow("s2");
        private static readonly FieldInfo _s3Field = GetFieldInfoOrThrow("s3");

        public RandomStateConverter()
            : base(_memberNames)
        {
        }

        protected override RandomState CreateInstanceFromValues(ValuesArray<int> values)
        {
            var state = new RandomState();

#if ENABLE_IL2CPP
            object boxed = state;
            _s0Field.SetValue(boxed, values[0]);
            _s1Field.SetValue(boxed, values[1]);
            _s2Field.SetValue(boxed, values[2]);
            _s3Field.SetValue(boxed, values[3]);
            return (RandomState)boxed;
#else
            TypedReference reference = __makeref(state);
            _s0Field.SetValueDirect(reference, values[0]);
            _s1Field.SetValueDirect(reference, values[1]);
            _s2Field.SetValueDirect(reference, values[2]);
            _s3Field.SetValueDirect(reference, values[3]);
            return state;
#endif
        }

        protected override int[] ReadInstanceValues(RandomState instance)
        {
            return new[] {
                (int)(_s0Field.GetValue(instance) ?? 0),
                (int)(_s1Field.GetValue(instance) ?? 0),
                (int)(_s2Field.GetValue(instance) ?? 0),
                (int)(_s3Field.GetValue(instance) ?? 0),
            };
        }
    }
}
