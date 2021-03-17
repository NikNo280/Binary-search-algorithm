using System;
using NUnit.Framework;
using static BinarySearchTask.ArrayExtension;

#pragma warning disable CA1707

namespace BinarySearchTask.Tests
{
    public class ArrayExtensionTests
    {
        [Test]
        public void BinarySearch_Int32_SourceArrayIsNull_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => BinarySearch(null, 1), "Source array cannot be null.");

        [TestCase(new[] { 6 }, 6, ExpectedResult = 0)]
        [TestCase(new[] { 1, 3, 4, 6, 8, 9, 11 }, 6, ExpectedResult = 3)]
        [TestCase(new[] { 1, 3, 4, 6, 8, 9, 11 }, 1, ExpectedResult = 0)]
        [TestCase(new[] { 1, 3, 4, 6, 8, 9, 11 }, 11, ExpectedResult = 6)]
        [TestCase(new[] { 1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 634 }, 144, ExpectedResult = 9)]
        [TestCase(new[] { 1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377 }, 21, ExpectedResult = 5)]
        public int BinarySearch_Int32_ReturnIndexOfValueInArray(int[] source, int value)
        {
            return BinarySearch(source, value).Value;
        }

        [TestCase(new[] { 6 }, 7, ExpectedResult = null)]
        [TestCase(new[] { 1, 3, 4, 6, 8, 9, 11 }, 0, ExpectedResult = null)]
        [TestCase(new[] { 1, 3, 4, 6, 8, 9, 11 }, 14, ExpectedResult = null)]
        [TestCase(new[] { 1, 3, 4, 6, 8, 9, 11 }, 11, ExpectedResult = 6)]
        [TestCase(new int[] { }, 144, ExpectedResult = null)]
        [TestCase(new[] { 1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377 }, 21, ExpectedResult = 5)]
        public int? BinarySearch_Int32_ReturnNull(int[] source, int value)
        {
            return BinarySearch(source, value);
        }

        [TestCase(new[] { 6.124 }, 6.124, ExpectedResult = 0)]
        [TestCase(new[] { 1.1253, 3.6543, 4.532, 6.124, 8.546, 9.125, 11.152 }, 6.124, ExpectedResult = 3)]
        [TestCase(new[] { 1.586, 3.421, 4d, 6.123, 8.124, 9.124, 11d }, 1.586, ExpectedResult = 0)]
        [TestCase(new[] { 1.765, 3.6345, 4.346, 6.867, 8.2, 9.4, 11.999 }, 11.999, ExpectedResult = 6)]
        [TestCase(new[] { 1.124, 3.1, 5.623, 8.124, 13.124, 21.124, 34.5612, 55.263, 89.124, 144.123, 233.125, 377.6532, 634.5347 }, 144.123, ExpectedResult = 9)]
        [TestCase(new[] { 1.1245, 3.568, 5.235, 8.235, 13.253, 21.777, 34.124, 55.142, 89.5674, 144.523, 233.51, 377.124 }, 21.777, ExpectedResult = 5)]
        public int BinarySearch_Double_ReturnIndexOfValueInArray(double[] source, double value)
        {
            return BinarySearch(source, value).Value;
        }

        [TestCase(new[] { 6.6 }, 7.1, ExpectedResult = null)]
        [TestCase(new[] { 1.6, 3.8, 4.1, 6.412, 8.77, 9.85, 11.00 }, 1.0, ExpectedResult = null)]
        [TestCase(new[] { 1.21, 3.745, 4.475, 6.1243, 8.241, 9.124, 11.412 }, 14.13, ExpectedResult = null)]
        [TestCase(new[] { 1.123, 3.124, 4.124, 6.789, 8.124, 9.124, 11.69 }, 11.69, ExpectedResult = 6)]
        [TestCase(new double[] { }, 144.657, ExpectedResult = null)]
        [TestCase(new[] { 1.123, 3.123, 5.65765, 8.123, 13.123, 21.235, 34.214, 55.124, 89.214, 144.657, 233.532, 377.235 }, 21.235, ExpectedResult = 5)]
        public int? BinarySearch_Double_ReturnNull(double[] source, double value)
        {
            return BinarySearch(source, value);
        }
    }
}
