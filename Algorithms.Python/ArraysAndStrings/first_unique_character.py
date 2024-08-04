# First Unique Character in a String:
# Given a string, find the first non-repeating character in it and return its index. If it does not exist, return -1.

def first_unique_character(word: str):
    dictionary = {}

    # iterate counting frequencies
    for char in word:
        # add or update entries on dictionary
        dictionary[char] = dictionary.get(key=char, default=0) + 1

    # iterate to find first first unique character
    for index, char in enumerate(word):
        if dictionary[char] == 1:
            return index

    # if no unique, return -1
    return -1


# Tests
result = first_unique_character("abbc")
print("Success" if result == 0 else "Fail")
