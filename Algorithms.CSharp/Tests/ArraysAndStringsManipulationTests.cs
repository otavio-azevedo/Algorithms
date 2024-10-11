using Algorithms;
using Algorithms.OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ArraysAndStringsManipulationTests
    {
        [Theory]
        [InlineData("abc", true)]
        [InlineData("abbc", false)]

        public void IsUniqueTests(string input, bool expectedResult)
        {
            var result = ArraysAndStringsManipulation.IsUnique(input);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("sstar", "ratss", true)]
        [InlineData("star", "rats", true)]
        [InlineData("star", "arts", true)]
        [InlineData("star", "rass", false)]
        [InlineData("staa", "ssta", false)]

        public void CheckPermutation(string word1, string word2, bool expectedResult)
        {
            var result = ArraysAndStringsManipulation.CheckPermutation(word1, word2);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("Mr John Smith    ", 13, "Mr%20John%20Smith")]
        [InlineData("Hello World  ", 11, "Hello%20World")]
        public void URLifyTest(string input, int realLength, string expectedResult)
        {
            var result = ArraysAndStringsManipulation.URLify(input.ToCharArray(), realLength);
            Assert.Equal(expectedResult.ToCharArray(), result);
        }

        [Theory]
        [InlineData("aab", true)]
        [InlineData("racecar", true)]
        [InlineData("abc", false)]
        public void IsPalindromePermutationTest(string input, bool expectedResult)
        {
            var result = ArraysAndStringsManipulation.IsPalindromePermutation(input);
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

        [Theory]
        [InlineData("xabcdey", "ab*de", 1)]
        [InlineData("juliasamanthantajulia", "ant", 8)]
        public void FirstOccurrence(string inputA, string inputB, int expectedResult)
        {
            var result = ArraysAndStringsManipulation.FirstOccurrence(inputA, inputB);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void NumIslandsTest()
        {
            char[][] grid = new char[][] {
            new char[] { '1', '1', '0', '0' },
            new char[] { '1', '1', '0', '0' },
            new char[] { '0', '0', '1', '1' },
            new char[] { '0', '0', '1', '1' }
            };

            var result = ArraysAndStringsManipulation.NumIslands(grid);
            Assert.Equal(2, result);
        }
    }
}
