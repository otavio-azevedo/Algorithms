# Check Permutation: Given two strings, write a method to decide if one is a permutation of the other.
# A permutation of a word is a rearrangement of its letters in any possible order. For a given word, all permutations are the possible ways you can arrange its characters.

def check_permutation(str1: str, str2: str) -> bool:

    if len(str1) != len(str2):
        return False

    dict_char_counter = {}

    # count frequencies of each character on first str
    # adding to dict_char_counter
    for character in str1:
        dict_char_counter[character] = dict_char_counter.get(character, 0) + 1

    # compare frequencies of each word
    for character in str2:

        # if any character doesn't exist
        # it isn't a permutation
        if character not in dict_char_counter:
            return False
        else:
            dict_char_counter[character] -= 1

            # if the frequencies doesn't match
            # it isn't a permutation
            if dict_char_counter[character] < 0:
                return False

    return True


# ----------------------------------------------------------------
#  Tests
# ----------------------------------------------------------------
result = check_permutation("star", "rats")
print("Success" if result == True else "Fail")

result = check_permutation("star", "ratss")
print("Success" if result == False else "Fail")
