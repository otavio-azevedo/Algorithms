using Algorithms.BinarySearch;

namespace Tests
{
    public class BinarySearchTests
    {
        [Fact]
        public void BinarySearchIterativeTest()
        {
            int[] inputArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int key = 6;

            int result = BinarySearch.InterativeApproach(inputArray, key);

            Assert.Equal(5, result);
        }

        [Fact]
        public void BinarySearchRecursiveTest()
        {
            int[] inputArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int key = 6;

            var result = BinarySearch.RecursiveApproach(inputArray, key, 0, inputArray.Length - 1);

            Assert.Equal(5, result);
        }

    }
}