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
    }
}