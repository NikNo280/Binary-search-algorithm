using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTask
{
    /// <summary>
    /// Class for basic array operations.
    /// </summary>
    public static class ArrayExtension 
    {
        public static int? BinarySearch<T>(T[] source, T value, IComparer<T> comparer = null)
        {
            if (source is null || value is null)
            {
                throw new ArgumentNullException(nameof(source), "source or value is null");
            }

            if (source.Length == 0)
            {
                return null;
            }

            if (!(comparer is null))
            {
                return Search<T>(source, value, comparer, 0, source.Length);
            }
            else if (!(Comparer<T>.Default is null))
            {
                return Search<T>(source, value, Comparer<T>.Default, 0, source.Length);
            }
            else
            {
                throw new ArgumentException($"Comparer<T>.Default is null");
            }
        }

        /// <summary>
        /// Implements binary search, see https://en.wikipedia.org/wiki/Binary_search_algorithm.
        /// </summary>
        /// <typeparam name="T">Source type.</typeparam>
        /// <param name="source">Source sorted array.</param>
        /// <param name="value">Value to search.</param>
        /// <returns>
        /// The position of an element with a given value in sorted array.
        /// If element is not found returns null.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <example>
        /// source = {1, 3, 4, 6, 8, 9, 11}, value = 11 => 6,
        /// source = {1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 634}, value = 144 => 9,
        /// source = {1, 3, 4, 6, 8, 9, 11}, value = 0 => null,
        /// source = {1, 3, 4, 6, 8, 9, 11}, value = 14 => null.
        /// source = { }, value = 14 => null.
        /// </example>
        public static int? Search<T>(T[] source, T value, IComparer<T> comparer, int left, int right)
        {
            if (left >= right)
            {
                return null;
            }

            int mid = (left + right) / 2;
            int resultCompare = comparer.Compare(value, source[mid]);
            if (resultCompare == 0)
            {
                return (int?)mid;
            }
            else if (resultCompare == 1)
            {
                return Search(source, value, comparer, mid + 1, right);
            }
            else
            {
                return Search(source, value, comparer, left, mid);
            }
        }
    }
}
