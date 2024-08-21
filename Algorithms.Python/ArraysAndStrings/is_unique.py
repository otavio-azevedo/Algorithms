# Is Unique: Implement an algorithm to determine if a string has all unique characters.

def is_unique(text: str):

    list = []

    for character in text:
        if character in list:
            return False
        else:
            list.append(character)

    return True


# ----------------------------------------------------------------
#  Tests
# ----------------------------------------------------------------

# 1. "simple" word, with no duplicates expect True
result = is_unique("tes")
expected_result = True
print("Success" if result == expected_result else "Fail")

# 1. "simple" word, with no duplicates expect False
result = is_unique("tess")
expected_result = False
print("Success" if result == expected_result else "Fail")
