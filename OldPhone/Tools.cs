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
        /// An array of accepted characters that includes spaces, asterisks, and hash signs.
        /// </summary>
        private static readonly char[] AcceptedChars = { ' ', '*', '#', '_' };
        /// <summary>
        /// An array of strings that contains the mapping of digits to letters based on an old phone keypad mapping.
        /// </summary>
        private static readonly string[] Letters = { " ", "&\'(", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

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
            return ConvertToPhoneLetters(input).ToUpper();
        }

        /// <summary>
        /// Converts the input string to a string of letters based on the old phone keypad mapping.
        /// </summary>
        private static string ConvertToPhoneLetters(string input)
        {
            var substrings = SplitToRepeatingCharacters(RemoveInvalidCharacters(RemoveCharactersAfterHash(input)));
            return substrings
                .Select(ConvertToCharFromRepeatingDigits)
                .Aggregate(string.Empty, (current, letter) =>
                    letter switch
                    {
                        '*' when current.Length > 0 => current[0..^1],
                        '#' => current,
                        '_' => current + ' ',
                        _ => current + letter
                    });
            
        }

        /// <summary>
        /// Removes all characters from the input string after the first occurrence of the '#' character.
        /// </summary>
        private static string RemoveCharactersAfterHash(string input)
        {
            var index = input.IndexOf('#');
            return index == -1 ? input : input.Substring(0, index);
        }

        /// <summary>
        /// Removes any characters that are not digits, spaces, asterisks,
        /// or hash signs from the input string.
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
            string pattern = @"(\d)\1*|#|_|\*";
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