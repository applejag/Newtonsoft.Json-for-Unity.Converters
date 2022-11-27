using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.Collections;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// Array of values used to pass around through the converters via the
    /// PartialConverter type <see cref="PartialConverter{T, TInner}"/>.
    /// </summary>
    /// <typeparam name="TInner">Type of the values in this array.</typeparam>
    public struct ValuesArray<TInner> : IReadOnlyList<TInner>, IDisposable
        where TInner : struct
    {
        private NativeArray<TInner> _array;

        public int Length => _array.Length;

        int IReadOnlyCollection<TInner>.Count => _array.Length;

        /// <summary>
        /// Gets or sets the value at a given index. If array contains a nullable
        /// type, this indexer may return <c>null</c>.
        /// </summary>
        /// <param name="index">The index of which value get or set.</param>
        /// <returns>Value in the given index.</returns>
        [MaybeNull]
        public TInner this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        /// <summary>
        /// Creates a new array as a shallow copy from an existing array.
        /// </summary>
        /// <param name="array">Array to copy values from.</param>
        public ValuesArray(TInner[] array, Allocator allocator)
        {
            _array = new NativeArray<TInner>(array, allocator);
        }

        /// <summary>
        /// Creates a new blank array with all values set to <c>default(<typeparamref name="TInner"/>)</c>
        /// </summary>
        /// <param name="capacity">Size of the array.</param>
        public ValuesArray(int capacity, Allocator allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory)
        {
            _array = new NativeArray<TInner>(capacity, allocator, options);
        }

        /// <summary>
        /// Useful for nullable value types (T?). Will try to return the value
        /// at specified index casted to the generic type <typeparamref name="T"/>.
        /// If it's an invalid cast, or the value is null, then will instead
        /// return the default value for the type <c>default(<typeparamref name="T"/>)</c>.
        /// </summary>
        /// <typeparam name="T">Wanted return type. If value at index cannot be casted to this type then method will return <c>default(<typeparamref name="T"/>)</c></typeparam>
        /// <param name="index">Index of where to look in the array.</param>
        /// <returns>The value at specified index, or default value for type given by generic type paramter <typeparamref name="T"/>.</returns>
        /// <exception cref="IndexOutOfRangeException">Index is outside the bounds of the inner array.</exception>
        [return: MaybeNull]
        public T GetAsTypeOrDefault<T>(int index)
            where T : struct
        {
            return _array[index] as T? ?? default;
        }

        /// <summary>
        /// Useful for nullable value types (T?). Will try to return the value
        /// at specified index casted to the generic type <typeparamref name="T"/>.
        /// If it's an invalid cast, or the value is null, then will instead
        /// return the value given by the fallback parameter <paramref name="fallback"/>.
        /// </summary>
        /// <typeparam name="T">Wanted return type. If value at index cannot be casted to this type then method will return value of fallback parameter <paramref name="fallback"/>.</typeparam>
        /// <param name="index">Index of where to look in the array.</param>
        /// <param name="fallback">Fallback value that will be returned if value cannot be casted or is null.</param>
        /// <returns>The value at specified index, or value of fallback parameter <paramref name="fallback"/>.</returns>
        /// <exception cref="IndexOutOfRangeException">Index is outside the bounds of the inner array.</exception>
        [return: NotNullIfNotNull("fallback")]
        public T GetAsTypeOrDefault<T>(int index, [AllowNull] T fallback)
            where T : struct
        {
            return _array[index] as T? ?? fallback;
        }

        public IEnumerator<TInner> GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            _array.Dispose();
        }
    }
}
