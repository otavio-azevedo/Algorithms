namespace Algorithms
{
    /// <summary>
    /// Finds the position of a target value within a sorted array;
    /// Each iteration looks to a new halve, comparing the middle element (guessValue) with the desired keyValue;
    /// https://www.c-sharpcorner.com/blogs/binary-search-implementation-using-c-sharp1
    /// https://www.youtube.com/watch?v=MFhxShGxHWc
    /// </summary>
    public static class BinarySearch
    {
        public static int InterativeApproach(int[] inputArray, int keyValue)
        {
            int startIndex = 0;
            int endIndex = inputArray.Length - 1;

            while (startIndex <= endIndex)
            {
                int middleIndex = (startIndex + endIndex) / 2;
                int guessValue = inputArray[middleIndex];

                if (guessValue == keyValue)
                {
                    return middleIndex; //found index
                }
                else if (guessValue > keyValue)
                {
                    endIndex = middleIndex - 1; //aim the left sub-array halve on next iteration
                }
                else
                {
                    startIndex = middleIndex + 1; //aim the right sub-array halve on next iteration
                }
            }

            return default;
        }

        public static object? RecursiveApproach(int[] inputArray, int keyValue, int min, int max)
        {
            if (min > max)
            {
                return default;
            }
            else
            {
                int middleIndex = (min + max) / 2;
                int guessValue = inputArray[middleIndex];
                if (keyValue == guessValue)
                {
                    return middleIndex; //found index
                }
                else if (guessValue > keyValue)
                {
                    return RecursiveApproach(inputArray, keyValue, min, middleIndex - 1); //aim the left sub-array halve on next iteration
                }
                else
                {
                    return RecursiveApproach(inputArray, keyValue, middleIndex + 1, max); //aim the right sub-array halve on next iteration
                }
            }
        }
    }
}