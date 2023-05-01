using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodingChallenge
{
    public static class Tools
    {
        private static readonly char[] AcceptedChars = { ' ', '*', '#' };
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

        public static string OldPhonePad(string input)
        {
            return ConvertToPhoneDigits(input).ToUpper();
        }

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

        private static string RemoveInvalidCharacters(string input)
        {
            return new string(input.Where(c => char.IsDigit(c) || AcceptedChars.Contains(c)).ToArray());
        }

        private static string[] SplitToRepeatingCharacters(string input)
        {
            string pattern = @"(\d)\1*|#|\*";
            return (Regex.Matches(input, pattern).Cast<Match>().Select(m => m.Value).ToArray());
        }

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