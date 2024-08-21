# A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing
# all non-alphanumeric characters, it reads the same forward and backward.
# Alphanumeric characters include letters and numbers.
# Given a string s, return true if it is a palindrome, or false otherwise.

def is_palindrome(input: str) -> bool:

    # first, convert input to lower case
    input = input.lower()

    l = 0
    r = len(input) - 1

    # appling two pointers approach
    while l < r:
        if not input[l].isalnum():  # if isn't alphanumeric, skip
            l += 1
        elif not input[r].isalnum():  # if isn't alphanumeric, skip
            r -= 1
        elif input[l] == input[r]:
            l += 1
            r -= 1
        else:
            return False

    return True


# ----------------------------------------------------------------
#  Tests
# ----------------------------------------------------------------

result = is_palindrome("A man, a plan, a canal: Panama")
print("Success" if result == True else "Fail")

result = is_palindrome("racecar")
print("Success" if result == True else "Fail")

result = is_palindrome("raceacar")
print("Success" if result == False else "Fail")
