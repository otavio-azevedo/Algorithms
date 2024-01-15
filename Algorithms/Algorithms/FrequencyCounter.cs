using System.Collections;
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

        ///<summary>
        ///Check Permutation: Given two strings, write a method to decide if one is a permutation of the other.
        /// </summary>
        public static bool CheckPermutation(string word1, string word2)
        {
            if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2))
                return false;

            if (word1.Length != word2.Length)
                return false;

            //count frequencies of each character on first word
            var dictCharCounter = new Dictionary<char, int>();

            foreach (char n in word1)
            {
                if (dictCharCounter.ContainsKey(n))
                {
                    dictCharCounter[n]++;
                }
                else
                {
                    dictCharCounter.Add(n, 1);

                }
            }

            //compare frequencies of each word using dictCharCounter
            foreach (char n in word2)
            {
                if (!dictCharCounter.ContainsKey(n))
                    return false;

                dictCharCounter[n]--;

                if (dictCharCounter[n] != 0)
                    return false;
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
        /// Is Unique: Implement an algorithm to determine if a string has all unique characters.
        /// </summary>
        public static bool IsUnique(string input)
        {
            if (input.Length <= 1)
                return true;

            var charSet = new HashSet<char>();

            foreach (char c in input)
            {
                if (charSet.Contains(c))
                    return false;

                charSet.Add(c);
            }

            return true;
        }
    }
}