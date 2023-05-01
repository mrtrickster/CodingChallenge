using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodingChallenge
{
    public class Tools
    {
        private static char[] _acceptedChars = { ' ', '*', '#' };
        private static char[][] _letters = {
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

        public static String OldPhonePad(string input)
        {
            string result = "";
            string filteredInput = FilterAcceptedCharacters(input);
            var substrings = SplitToRepeatingCharacters(filteredInput);
            foreach (string substring in substrings)
            {
                char letter = RepeatingCharactersToChar(substring);
                switch (letter.ToString())
                {
                    case "*":
                        if (result.Length > 0)
                        {
                            result = result.Substring(0, result.Length - 1);
                        }
                        break;
                    case "#":
                        break;
                    default:
                        result += letter;
                        break;
                }
            }
            return result;
        }

        private static string FilterAcceptedCharacters(string input)
        {
            string filteredInput = new string(input.Where(
                c => char.IsDigit(c) || Array.IndexOf(_acceptedChars, c) != -1
            ).ToArray());

            return filteredInput;
        }

        private static string[] SplitToRepeatingCharacters(string input)
        {
            string pattern = @"(\d)\1*|#|\*";
            return (Regex.Matches(input, pattern).Cast<Match>().Select(m => m.Value).ToArray());
        }

        private static char RepeatingCharactersToChar(string input)
        {
            char c = input[0];
            if (char.IsDigit(c))
            {
                int i = (int)Char.GetNumericValue(c);
                return _letters[i][input.Length - 1];
            }
            else return c;
        }
    }
}
