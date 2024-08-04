using Algorithms;

namespace Tests
{
    public class FrequencyCounterTests
    {
        [Theory]
        [InlineData("", "", false)]
        [InlineData("aaz", "zza", false)]
        [InlineData("anagram", "nagaram", true)]
        [InlineData("rat", "car", false)]
        [InlineData("qwerty", "qeywrt", true)]

        public void ValidateAnagramTest(string word1, string word2, bool expectedResult)
        {
            var result = FrequencyCounter.ValidateAnagram(word1, word2);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new int[] { 1 }, false)]
        [InlineData(new int[] { 1, 2 }, false)]
        [InlineData(new int[] { 1, 2, 1 }, true)]

        public void AreThereDuplicatesTests(int[] numbers, bool expectedResult)
        {
            var result = FrequencyCounter.AreThereDuplicates(numbers);
            Assert.Equal(expectedResult, result);
        }

       

        
    }
}