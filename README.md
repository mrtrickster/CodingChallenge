# CodingChallenge
<h1>Old Phone Keypad Solution</h1>
The Tools class provides a static method OldPhonePad to convert an input string of digits or their repetitions to the corresponding letters on a traditional mobile phone pad. The keypad buttons are mapped to corresponding letters, and the user can enter a message by pressing the buttons. The "*" symbol deletes the last letter entered.
<h3>ConvertToPhoneDigits:</h3> Converts a string of numeric characters to a string of letters. This method uses a lookup table to translate the digits to the corresponding letters.
<h3>SplitToRepeatingCharacters:</h3> Splits a string into substrings of repeating digits or accepted symbols ("*", "#", " ").
<h3>RemoveInvalidCharacters:</h3> Removes all characters from the input string that are not digits or accepted symbols.
<h3>ConvertToCharFromRepeatingDigits:</h3> Converts a substring of repeating digits to the corresponding letter on the phone keypad.

<h2>Installation</h2>
The class is provided as a C# file that can be added to your C# project. You can copy and paste the code into a new file in your project, or download the file from the repository.

<h2>Usage</h2>
To use the OldPhonePad method, first import the CodingChallenge namespace that contains the Tools class. Then call the method and pass a string of digits as an argument.

<h2>Testing</h2>
Unit tests for the OldPhonePad method are provided in the TestTools.cs file in this repository.

<h2>Contributing</h2>
Contributions to this repository are welcome. If you find any issues or have suggestions for improvements, please create an issue or pull request.

<h2>License</h2>
This solution is licensed under the MIT license. See the LICENSE file for more information.
