using System.Text;

namespace AssignmentIS
{
    public class OldPhone
    {/// <summary>
     /// The dictionary mapping each keypad character to its corresponding letters.
     /// </summary>
        private static Dictionary<char, string> KeyPadMapping = GetKeyPadMapping();

        /// <summary>
        /// Converts the input text to its old phone keypad equivalent.
        /// </summary>
        /// <param name="input">The input text containing numbers (2-9), a space between numbers, and ending with '#'.</param>
        /// <returns>The converted output based on old phone keypad mapping.</returns>
        public static string OldPhonePad(string input)
        {
            var output = new StringBuilder();
            char currentInput = '\0';
            int currentCount = 0;
            var actionKeys = new List<char> { '*', '#', ' ' };

            foreach (char ch in input)
            {
                if (actionKeys.Contains(ch))
                {
                    if (currentCount > 0)
                    {
                        output.Append(GetCharFromKeypad(currentCount, currentInput));
                        currentCount = 0;
                    }

                    // Handles special actions based on the action key.
                    if (ch == '*')
                    {
                        if (output.Length > 0) output.Remove(output.Length - 1, 1);
                    }
                    else if (ch == '#')
                    {
                        break; // Stops processing at the end character '#'
                    }
                }
                else
                {
                    if (currentCount > 0 && ch != currentInput)
                    {
                        output.Append(GetCharFromKeypad(currentCount, currentInput));
                        currentCount = 0;
                    }
                    currentInput = ch;
                    currentCount++;
                }
            }
            return output.ToString();
        }

        /// <summary>
        /// Retrieves the character from the keypad mapping based on the current count and input character.
        /// </summary>
        /// <param name="currentCount">The count of consecutive occurrences of the input character.</param>
        /// <param name="currentInput">The current input character being processed.</param>
        /// <returns>The character from the keypad mapping based on the current count and input character.</returns>
        private static char GetCharFromKeypad(int currentCount, char currentInput)
        {
            var currentKeypad = KeyPadMapping[currentInput];
            var len = currentKeypad.Length;
            var index = (currentCount - 1) % len;
            return currentKeypad[index];
        }

        /// <returns>A dictionary mapping each keypad character to its corresponding letters.</returns>
        private static Dictionary<char, string> GetKeyPadMapping()
        {
            Dictionary<char, string> keypad = new Dictionary<char, string>
            {
                { '2', "ABC" },
                { '3', "DEF" },
                { '4', "GHI" },
                { '5', "JKL" },
                { '6', "MNO" },
                { '7', "PQRS" },
                { '8', "TUV" },
                { '9', "WXYZ" }
            };
            return keypad;
        }
    }
}
