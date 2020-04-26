using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Newtonsoft.Json.UnityConverters
{
    public readonly struct ValuesArray<T> : IReadOnlyList<T>
    {
        private readonly T[] _array;

        public int Count => _array.Length;

        [MaybeNull]
        public T this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        public ValuesArray(T[] array)
        {
            _array = array;
        }

        public ValuesArray(int capacity)
        {
            _array = new T[capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IReadOnlyList<T>)_array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IReadOnlyList<T>)_array).GetEnumerator();
        }

        public override bool Equals(object? obj)
        {
            return obj is ValuesArray<T> array &&
                   EqualityComparer<T[]>.Default.Equals(_array, array._array);
        }

        public override int GetHashCode()
        {
            return -1325016561 + EqualityComparer<T[]>.Default.GetHashCode(_array);
        }

        public static bool operator ==(ValuesArray<T> left, ValuesArray<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ValuesArray<T> left, ValuesArray<T> right)
        {
            return !(left == right);
        }
    }
}
