using System;
using System.Linq;
using System.Text.RegularExpressions;
/// <summary>
/// The OldPhone namespace contains the Tools class that is responsible
/// for converting an input string of digits or their repetitions
/// to a corresponding string of letters using an old phone keypad mapping.
/// </summary>
namespace OldPhone
{
    public static class Tools
    {
        /// <summary>
        /// An array of accepted characters that includes spaces, asterisks, and pound signs.
        /// </summary>
        private static readonly char[] AcceptedChars = { ' ', '*', '#' };
        /// <summary>
        /// A jagged array that contains the mapping of digits to letters based on an old phone keypad mapping.
        /// </summary>
        private static readonly char[][] Letters = {
            new char[]{ ' ' },
            new char[]{ '&', '\'', '(' },
            new char[]{ 'a', 'b', 'c' },
            new char[]{ 'd', 'e', 'f' },
            new char[]{ 'g', 'h', 'i' },
            new char[]{ 'j', 'k', 'l' },
            new char[]{ 'm', 'n', 'o' },
            new char[]{ 'p', 'q', 'r', 's' },
            new char[]{ 't', 'u', 'v' },
            new char[]{ 'w', 'x', 'y', 'z' }
        };

        /// <summary>
        /// Converts an input string of digits or their repetitions
        /// to a corresponding string of letters using an old phone keypad mapping.
        /// The input string may contain digits, spaces, asterisks, and pound signs.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <returns>A string of letters that corresponds to the input string
        /// according to an old phone keypad mapping.</returns>
        public static string OldPhonePad(string input)
        {
            return ConvertToPhoneDigits(input).ToUpper();
        }

        /// <summary>
        /// Converts the input string to a string of digits based on the old phone keypad mapping.
        /// </summary>
        private static string ConvertToPhoneDigits(string input)
        {
            var substrings = SplitToRepeatingCharacters(RemoveInvalidCharacters(input));
            return substrings
                .Select(ConvertToCharFromRepeatingDigits)
                .Aggregate(string.Empty, (current, letter) =>
                    letter switch
                    {
                        '*' => current.Length > 0 ? current[..^1] : current,
                        '#' => current,
                        _ => current + letter
                    });
            
        }

        /// <summary>
        /// Removes any characters that are not digits, spaces, asterisks,
        /// or pound signs from the input string.
        /// </summary>
        private static string RemoveInvalidCharacters(string input)
        {
            return new string(input.Where(c => char.IsDigit(c) || AcceptedChars.Contains(c)).ToArray());
        }

        /// <summary>
        /// Splits the input string into substrings of repeating digits
        /// or special characters, such as asterisks, spaces or pound signs.
        /// </summary>
        private static string[] SplitToRepeatingCharacters(string input)
        {
            string pattern = @"(\d)\1*|#|\*";
            return (Regex.Matches(input, pattern).Cast<Match>().Select(m => m.Value).ToArray());
        }

        /// <summary>
        /// Converts a substring of repeating digits to a corresponding letter
        /// based on the old phone keypad mapping.
        /// </summary>
        private static char ConvertToCharFromRepeatingDigits(string input)
        {
            char c = input[0];
            if (!char.IsDigit(c))
                return c;
            var i = (int)char.GetNumericValue(c);
            return Letters[i][input.Length - 1];
        }
    }
}