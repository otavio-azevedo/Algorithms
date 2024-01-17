using Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ArraysAndStringsManipulationTests
    {
        [Fact]
        public void URLifyTest()
        {
            string str = "Mr John Smith    ";
            int realLength = 13;

            var result = ArraysAndStringsManipulation.URLify(str.ToCharArray(), realLength);

            Assert.Equal("Mr%20John%20Smith", result);
        }

        [Theory]
        [InlineData("aab", true)]
        [InlineData("racecar", true)]
        [InlineData("abc", false)]
        public void PalindromePermutationTest(string input, bool expectedResult)
        {
            var result = ArraysAndStringsManipulation.PalindromePermutation(input);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("A man, a plan, a canal: Panama", true)]
        [InlineData("racecar", true)]
        [InlineData("race a car", false)]
        public void IsPalindromeTest(string input, bool expectedResult)
        {
            var result = ArraysAndStringsManipulation.IsPalindrome(input);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("pale", "bale", true)]
        [InlineData("pale", "ple", true)]
        [InlineData("ple", "pale", true)]
        [InlineData("pale", "pale", true)]
        [InlineData("pale", "bake", false)]
        public void OneAway(string inputA, string inputB, bool expectedResult)
        {
            var result = ArraysAndStringsManipulation.OneEditAway(inputA, inputB);
            Assert.Equal(expectedResult, result);
        }
    }
}
