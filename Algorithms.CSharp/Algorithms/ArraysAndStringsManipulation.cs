using System.Globalization;
using System.Text.Json;

namespace Algorithms
{
    public static class ArraysAndStringsManipulation
    {
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

                if (dictCharCounter[n] < 0)
                    return false;
            }

            return true;
        }

        ///<summary>
        ///URLify: Write a method to replace all spaces in a string with '%20'. You may assume that the string
        ///has sufficient space at the end to hold the additional characters, and that you are given the "true"
        ///length of the string.
        /// </summary>
        public static char[] URLify(char[] charArray, int realLength)
        {
            int index = charArray.Length;

            for (int i = realLength - 1; i >= 0; i--)
            {
                // Replace spaces (' ') for %20
                if (charArray[i] == ' ')
                {
                    charArray[index - 1] = '0';
                    charArray[index - 2] = '2';
                    charArray[index - 3] = '%';
                    index = index - 3;
                }
                // Move char's to right
                else
                {
                    charArray[index - 1] = charArray[i];
                    index--;
                }
            }

            return charArray;
        }

        ///<summary>
        /// Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palin-
        /// drome.A palindrome is a word or phrase that is the same forwards and backwards.A permutation
        /// is a rearrangement of letters.The palindrome does not need to be limited to just dictionary words.
        /// </summary>
        public static bool IsPalindromePermutation(string input)
        {
            // Array to store char frequencies, considering ASCII
            var asciiChars = new int[128];

            // Store char and frequencies
            for (int i = 0; i < input.Length; i++)
            {
                asciiChars[input[i]]++;
            }

            // Check the number of odds, 
            int countOdds = 0;
            for (int i = 0; i < 128; i++)
            {
                // oddNumber  % 2 = 1
                // evenNumber % 2 = 0
                countOdds += asciiChars[i] % 2;
            }

            // If countOdds > 1, isn't a palindrome.
            // Only 1 character can have an odd frequency.
            return countOdds <= 1;
        }

        ///<summary>
        /// A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing 
        /// all non-alphanumeric characters,
        /// it reads the same forward and backward. Alphanumeric characters include letters and numbers.
        /// Given a string s, return true if it is a palindrome, or false otherwise.
        /// </summary>
        public static bool IsPalindrome(string input)
        {
            // Convert string to lower case
            input = input.ToLower();

            // Remove non-alphanumeric characters
            var charList = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char character = input[i];

                // Check if is letter or digit
                if ((character >= 'a' && character <= 'z') ||
                    (character >= '0' && character <= '9'))
                {
                    charList.Add(character);
                }
            }

            // Check if is a valid Palindrome
            for (int i = 0; i < charList.Count / 2; i++)
            {
                // Iterate until the middle, comparing chars from left to right
                if (charList[i] != charList[charList.Count - 1 - i])
                {
                    return false;
                }
            }

            return true;

        }

        ///<summary>
        /// One Away: There are three types of edits that can be performed on strings: insert a character,
        /// remove a character, or replace a character.Given two strings, write a function to check if they are
        /// one edit (or zero edits) away.
        /// </summary>
        public static bool OneEditAway(string inputA, string inputB)
        {
            static bool OneEditReplace(string inputA, string inputB)
            {
                bool foundDifference = false;

                for (int i = 0; i < inputA.Length; i++)
                {
                    if (inputA[i] != inputB[i])
                    {
                        // If foundDifference == true
                        // Means that this is the second difference
                        // Then, return false
                        if (foundDifference)
                            return false;

                        foundDifference = true;
                    }
                }

                return true;
            }

            static bool OneEditInsert(string s1, string s2)
            {
                int index1 = 0;
                int index2 = 0;

                while (index2 < s2.Length && index1 < s1.Length)
                {
                    if (s1[index1] != s2[index2])
                    {
                        if (index1 != index2)
                        {
                            return false;
                        }
                        index2++;
                    }
                    else
                    {
                        index1++;
                        index2++;
                    }
                }
                return true;
            }

            //If both strings contains same length
            if (inputA.Length == inputB.Length)
                return OneEditReplace(inputA, inputB);
            //If inputA is smaller than inputB
            else if (inputA.Length + 1 == inputB.Length)
                return OneEditInsert(inputA, inputB);
            //If inputA is greater than inputB
            else if (inputA.Length - 1 == inputB.Length)
                return OneEditInsert(inputB, inputA);

            return true;
        }


        /// <summary>
        /// Complete the 'firstOccurrence' function below.
        /// The function is expected to return an INTEGER.
        /// </summary>
        public static int FirstOccurrence(string s, string x)
        {
            if (string.IsNullOrEmpty(x))
                return -1;

            // Iterate only until where makes sense
            // e.g: xabcdey | ab*de
            // e.g: xab | ab*de
            for (int i = 0; i < s.Length + 1 - x.Length; i++)
            {
                for (int j = 0; j < x.Length; j++)
                {
                    if (s[i + j] != x[j] && x[j] != '*')
                        break;

                    if (j == x.Length - 1)
                        return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.
        ///An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically.You may assume all four edges of the grid are all surrounded by water.
        /// </summary>
        /// <returns>Number of islands</returns>
        public static int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0) return 0;

            int numIslands = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            HashSet<(int, int)> visited = new HashSet<(int, int)>();  // HashSet to store visited cells

            // Helper method to perform DFS without modifying the grid
            void DFS(char[][] grid, int row, int col)
            {
                // Base cases: if out of bounds
                if (row < 0 || row >= rows || col < 0 || col >= cols || 
                    grid[row][col] == '0' || // at water
                    visited.Contains((row, col))) // already visited
                {
                    return;
                }

                // Mark the current cell as visited by adding its coordinates to the HashSet
                visited.Add((row, col));

                // Explore all four directions
                DFS(grid, row - 1, col); // up
                DFS(grid, row + 1, col); // down
                DFS(grid, row, col - 1); // left
                DFS(grid, row, col + 1); // right
            }

            // Traverse the entire grid
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    // Whenever a new piece of land is found and it hasn't been visited, increment the number of islands
                    if (grid[row][col] == '1' && !visited.Contains((row, col)))
                    {
                        numIslands++;
                        
                        // Perform DFS to mark the entire island as visited
                        DFS(grid, row, col);
                    }
                }
            }

            return numIslands;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Roman number</returns>
        public static string IntToRoman(int num)
        {
            if (num <= 0 || num >= 4000)
            {
                throw new ArgumentOutOfRangeException("Input must be between 1 and 3999.");
            }

            // Mapping of values to Roman numerals (including subtractive forms)
            var romanMapping = new Dictionary<int, string>
            {
                { 1000, "M" },
                { 900, "CM" },// added
                { 500, "D" },
                { 400, "CD" },// added
                { 100, "C" },
                { 90, "XC" },// added
                { 50, "L" },
                { 40, "XL" },// added
                { 10, "X" },
                { 9, "IX" },// added
                { 5, "V" },
                { 4, "IV" },// added
                { 1, "I" }
            };

            var result = new System.Text.StringBuilder();

            // Iterate through the dictionary keys following descending order
            foreach (var key in romanMapping.Keys)
            {
                while (num >= key)
                {
                    result.Append(romanMapping[key]);
                    num -= key; // Subtract the value from num
                }
            }

            return result.ToString();
        }
    }
}
