using Algorithms;

namespace Tests
{
    public class MultiplePointersTests
    {
        [Theory]
        [InlineData(new[] { -3, -2, -1, 0, 1, 2, 3 }, new[] { -3, 3 })]
        [InlineData(new[] { -3, -2, -1, 0, 1, 2 }, new[] { -2, 2 })]
        [InlineData(new[] { -3, -2, -1, 0 }, default)]
        public void FindFirstSumZeroTest(int[] numbers, int[]? expectedResult)
        {
            var result = MultiplePointers.FindFirstSumZero(numbers);
            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [InlineData(new[] { 1, 1, 2 }, 2)]
        [InlineData(new[] { 1, 2, 3, 4, 4, 4, 7, 7, 12, 12, 13 }, 7)]
        [InlineData(new int[] {}, 0)]
        public void CountUniqueNumbersTest(int[] numbers, int expectedResult)
        {
            var result = MultiplePointers.CountUniqueNumbers(numbers);
            Assert.Equal(expectedResult, result);
        }
    }
}
