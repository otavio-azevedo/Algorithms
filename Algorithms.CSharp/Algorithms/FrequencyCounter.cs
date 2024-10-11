using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Algorithms
{
    public static class FrequencyCounter
    {
        /// <summary>
        /// Given two strings, write a function to determine if the second string is an anagram of the first. 
        /// An anagram is a word, phrase, or name formed by rearranging the letters of another, such as cinema, formed from iceman.
        /// </summary>
        public static bool ValidateAnagram(string word1, string word2)
        {
            if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2))
                return false;

            if (word1.Length != word2.Length)
                return false;

            var frequencyCounter1 = new Dictionary<char, int>();
            var frequencyCounter2 = new Dictionary<char, int>();

            //count frequencies of each character on first word
            foreach (char val in word1)
            {
                if (frequencyCounter1.ContainsKey(val))
                {
                    frequencyCounter1[val]++;
                }
                else
                {
                    frequencyCounter1.Add(val, 1);
                }
            }

            //count frequencies of each character on second word
            foreach (char val in word2)
            {
                if (frequencyCounter2.ContainsKey(val))
                {
                    frequencyCounter2[val]++;
                }
                else
                {
                    frequencyCounter2.Add(val, 1);
                }
            }

            //compare each frequencies
            foreach (var entry in frequencyCounter1)
            {
                if (frequencyCounter2.TryGetValue(entry.Key, out int value))
                {
                    if (value != entry.Value)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }



        /// <summary>
        /// Implement a function called, areThereDuplicates which accepts a variable number of arguments, 
        /// and checks whether there are any duplicates among the arguments passed in. 
        /// </summary>
        public static bool AreThereDuplicates(int[] numbers)
        {
            if (numbers.Length <= 1)
                return false;

            var intSet = new HashSet<int>();

            foreach (char c in numbers)
            {
                if (intSet.Contains(c))
                    return true;

                intSet.Add(c);
            }

            return false;
        }

        /// <summary>
        ///Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        ///You may assume that each input would have exactly one solution, and you may not use the same element twice.
        ///You can return the answer in any order.
        /// </summary>
        public static int[] TwoSum(int[] nums, int target)
        {
            var numsDict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {

                // Calculate difference
                int difference = target - nums[i];

                //Check if the complement exists in the dictionary
                if (numsDict.TryGetValue(difference, out int diffIndex))
                {
                    //If it exists, return the current index and the index of the complement.
                    return new int[2] { diffIndex, i };
                }

                //If it doesn’t exist, add the current number and its index to the dictionary.
                numsDict.Add(nums[i], i);
            }

            return Array.Empty<int>();
        }


    }
}