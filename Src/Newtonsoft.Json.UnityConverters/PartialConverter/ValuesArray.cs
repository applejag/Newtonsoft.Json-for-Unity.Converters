using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Newtonsoft.Json.UnityConverters
{
    public readonly struct ValuesArray<TInner> : IReadOnlyList<TInner>, IEquatable<ValuesArray<TInner>>
    {
        private readonly TInner[] _array;

        public int Count => _array.Length;

        [MaybeNull]
        public TInner this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        public ValuesArray(TInner[] array)
        {
            _array = array;
        }

        public ValuesArray(int capacity)
        {
            _array = new TInner[capacity];
        }

        [return: MaybeNull]
        public TInner Get(int index)
        {
            return _array[index];
        }

        [return: MaybeNull]
        public T GetAsTypeOrDefault<T>(int index)
            where T : struct
        {
            return _array[index] as T? ?? default;
        }

        [return: NotNullIfNotNull("fallback")]
        public T GetAsTypeOrDefault<T>(int index, [AllowNull] T fallback)
            where T : struct
        {
            return _array[index] as T? ?? fallback;
        }

        public IEnumerator<TInner> GetEnumerator()
        {
            return ((IReadOnlyList<TInner>)_array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IReadOnlyList<TInner>)_array).GetEnumerator();
        }

        public bool Equals(ValuesArray<TInner> other)
        {
            return _array == other._array;
        }

        public override bool Equals(object? obj)
        {
            return obj is ValuesArray<TInner> array &&
                   EqualityComparer<TInner[]>.Default.Equals(_array, array._array);
        }

        public override int GetHashCode()
        {
            return -1325016561 + EqualityComparer<TInner[]>.Default.GetHashCode(_array);
        }

        public static bool operator ==(ValuesArray<TInner> left, ValuesArray<TInner> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ValuesArray<TInner> left, ValuesArray<TInner> right)
        {
            return !(left == right);
        }
    }
}
