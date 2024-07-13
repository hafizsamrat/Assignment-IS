# ASSIGNMENT-IS

This program converts input from an old phone keypad into the corresponding text message. 
Each numeric key on the old phone keypad maps to multiple alphabetical letters, and pressing a key multiple times cycles through its letters.


## Implementation Steps

1. **Main Program (`Program.cs`)**:
   - Reads input from the console until an empty line is entered.
   - The input string consists of numbers (2-9), spaces between numbers, and ends with `#`.
   - Calls the `OldPhonePad(string input)` method from the `OldPhone.cs` class to process the input and print the result.

2. **OldPhone Class (`OldPhone.cs`)**:
   - Contains the `OldPhonePad(string input)` method which:
	 - Prepare old phone keypad mapping with input digits for alphabetical letters.
		```
		{ '2', "ABC" },
		{ '3', "DEF" },
		{ '4', "GHI" },
		{ '5', "JKL" },
		{ '6', "MNO" },
		{ '7', "PQRS" },
		{ '8', "TUV" },
		{ '9', "WXYZ" }
		```
	 - Iterates through the input characters:
       - Counts consecutive occurrences of the same key.
       - Retrieves the correct letters from the keypad mapping based on the current count and input character using `GetCharFromKeypad` method.
		 - Handles cycling through letters on repeated same key presses without a pause (`2222` -> `A -> B -> C -> A`).
       - `*` acts as a backspace, removing the last character if any.
	   - `#` indicates the end of input processing and send the prepared text.

3. **Unit Tests (`OldPhoneTest.cs`)**:
   - Contains Xunit tests to verify the functionality of the `OldPhonePad` method with various input scenarios.
   - Tests cover:
     - Normal input conversions (`33#`, `227*#`, `4433555 555666#`).
     - Handling of backspace characters (`*`).
     - Cycling through multiple characters on the same key (`2222#`, `222233333444444#`).
     - Edge cases (`#`, `**#`, `*3*#`).

## Running the Program

To run the program:
1. Ensure you have a C# development environment set up.
2. Clone or download the project files.
3. Open the solution in your IDE (e.g., Visual Studio).
4. Build and run the `Program.cs` file.
5. Enter inputs directly into the console and observe the converted outputs.

## Test Cases

- Ensure the correctness of the conversion logic across various input scenarios.
- Validate handling of backspace and cyclic key presses.
- Verify edge cases such as empty inputs, cycles and backspaces on empty result.

## Example Usage
```
string input = "227*#"; 
var result = OldPhone.OldPhonePad(input);
Console.WriteLine($"Output: {result}"); // Prints "B"
```

