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

        public void ValidAnagramTest(string word1, string word2, bool expectedResult)
        {
            var result = FrequencyCounter.ValidateAnagram(word1, word2);
            Assert.Equal(expectedResult, result);
        }
    }
}