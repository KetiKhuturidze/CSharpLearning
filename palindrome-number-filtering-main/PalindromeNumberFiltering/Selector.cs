using System.Collections.Concurrent;

namespace PalindromeNumberFiltering;

/// <summary>
/// A static class containing methods for filtering palindrome numbers from a collection of integers.
/// </summary>
public static class Selector
{
    /// <summary>
    /// Retrieves a collection of palindrome numbers from the given list of integers using sequential filtering.
    /// </summary>
    /// <param name="numbers">The list of integers to filter.</param>
    /// <returns>A collection of palindrome numbers.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input list 'numbers' is null.</exception>
    public static IList<int> GetPalindromeInSequence(IList<int>? numbers)
    {
        if (numbers == null)
        {
            throw new ArgumentNullException(nameof(numbers));
        }

        var palindromeNumbers = new List<int>();

        foreach (var number in numbers)
        {
            if (IsPalindrome(number))
            {
                palindromeNumbers.Add(number);
            }
        }

        return palindromeNumbers.ToArray();
    }

    /// <summary>
    /// Retrieves a collection of palindrome numbers from the given list of integers using parallel filtering.
    /// </summary>
    /// <param name="numbers">The list of integers to filter.</param>
    /// <returns>A collection of palindrome numbers.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input list 'numbers' is null.</exception>
    public static IList<int> GetPalindromeInParallel(IList<int> numbers)
    {
        if (numbers == null)
        {
            throw new ArgumentNullException(nameof(numbers));
        }

        var palindromeNumbers = new ConcurrentBag<int>();

        _ = Parallel.ForEach(numbers, number =>
        {
            if (IsPalindrome(number))
            {
                palindromeNumbers.Add(number);
            }
        });

        return palindromeNumbers.ToList();
    }

    /// <summary>
    /// Checks whether the given integer is a palindrome number.
    /// </summary>
    /// <param name="number">The integer to check.</param>
    /// <returns>True if the number is a palindrome, otherwise false.</returns>
    public static bool IsPalindrome(int number)
    {
        if (number < 0)
        {
            return false;
        }
        else if (number < 10)
        {
            return true;
        }

        int length = GetLength(number);
        int divider = (int)Math.Pow(10, length - 1);

        return IsPositiveNumberPalindrome(number, divider);
    }

    private static bool IsPositiveNumberPalindrome(int number, int divider)
    {
        if (number < 10)
        {
            return true;
        }

        int leading = number / divider;
        int trailing = number % 10;

        if (leading != trailing)
        {
            return false;
        }

        number %= divider;
        number /= 10;

        return IsPositiveNumberPalindrome(number, divider / 100);
    }

    /// <summary>
    /// Gets the number of digits in the given integer.
    /// </summary>
    /// <param name="number">The integer to count digits for.</param>
    /// <returns>The number of digits in the integer.</returns>
    private static byte GetLength(int number)
    {
        int n = Math.Abs(number).ToString().Length;

        switch (n)
        {
            case 1: return 1;
            case 2: return 2;
            case 3: return 3;
            case 4: return 4;
            case 5: return 5;
            case 6: return 6;
            case 7: return 7;
            case 8: return 8;
            case 9: return 9;
            default: return 10;
        }
    }
}
