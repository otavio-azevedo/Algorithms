using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Algorithms
{
    public static class ArraysAndStringsManipulation
    {
        ///<summary>
        ///URLify: Write a method to replace all spaces in a string with '%20'. You may assume that the string
        ///has sufficient space at the end to hold the additional characters, and that you are given the "true"
        ///length of the string.
        /// </summary>
        public static string URLify(char[] charArray, int realLength)
        {
            int spaceCount = 0;
            int index = 0;
            int i = 0;

            //Counting space ocurrences
            for (i = 0; i < realLength; i++)
            {
                if (charArray[i] == ' ')
                    spaceCount++;
            }

            if (realLength < charArray.Length)
                charArray[realLength] = '\0';
            
            index = charArray.Length;

            
            for (i = realLength - 1; i >= 0; i--)
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

            return new string(charArray);
        }

    }
}