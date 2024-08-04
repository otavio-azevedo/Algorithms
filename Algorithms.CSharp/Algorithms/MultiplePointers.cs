using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class MultiplePointers
    {
        /// <summary>
        /// Write a function called sumZero which accepts a SORTED ARRAY of integers.
        /// The function should find the first pair where the sum is 0. 
        /// Return an array that includes both values that sum to zero or undefined 
        /// if a pair does not exist
        /// </summary>
        public static int[]? FindFirstSumZero(int[] numbers)
        {
            int leftIndex = 0;
            int rightIndex = numbers.Length - 1;

            while (leftIndex < rightIndex)
            {
                int sum = numbers[leftIndex] + numbers[rightIndex];

                if (sum == 0)
                {
                    return new int[] { numbers[leftIndex], numbers[rightIndex] };
                }
                else if (sum > 0)
                {
                    rightIndex--;
                }
                else
                {
                    leftIndex++;
                }
            }

            return default;
        }
       
        /// <summary>
        /// Implement a function called countUniqueValues, 
        /// which accepts a SORTED ARRAY, and counts the unique values in the array. 
        /// There can be negative numbers in the array, but it will always be sorted.
        /// </summary>
        public static int CountUniqueNumbers(int[] numbers)
        {
            if (numbers.Length == 0) return 0;

            int leftIndex = 0;
            
            for (int rightIndex = 0; rightIndex < numbers.Length; rightIndex++)
            {
                if (numbers[leftIndex] != numbers[rightIndex])
                {
                    leftIndex++;
                    numbers[leftIndex] = numbers[rightIndex];
                }
            }

            return leftIndex + 1;
        }
    }
}
