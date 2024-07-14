# Old Phone Keypad Converter

This program converts input from an old phone keypad into text messages. Each number key on an old phone represents multiple alphabetical letters, 
and pressing a key multiple times cycles through its letters.

## Implementation Overview

### Main Program (`Program.cs`)
- Reads input from the console until an empty line is entered.
- The input consists of numbers (2-9), spaces, and ends with `#`.
- Calls the `OldPhonePad(string input)` method from the `OldPhone.cs` class to process the input and print the result.

### OldPhone Class (`OldPhone.cs`)
- Contains the `OldPhonePad(string input)` method which:
  - Maps digits to their corresponding letters on the old phone keypad:
    ```csharp
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
    - Retrieves the correct letter based on the count and input character.
    - Handles cycling through letters on repeated key presses (e.g., `2222` -> `A -> B -> C -> A`).
    - `*` acts as a backspace, removing the last character if any.
    - `#` indicates the end of input processing and outputs the text.

### Unit Tests (`OldPhoneTest.cs`)
- Contains tests using Xunit to verify the functionality of the `OldPhonePad` method with various inputs.
- Tests cover:
  - Normal input conversions (e.g., `33#`, `227*#`, `4433555 555666#`).
  - Handling of backspace (`*`).
  - Cycling through multiple characters on the same key (e.g., `2222#`, `222233333444444#`).
  - Edge cases (`#`, `**#`, `*3*#`).

## Why Use StringBuilder?
- **Efficiency**: `StringBuilder` is more efficient for multiple modifications to a string. Strings in C# are immutable, meaning each modification creates a new string, which is inefficient. `StringBuilder` allows for efficient, mutable string operations.

## Complexity Analysis

### Time Complexity
- **Overall Time Complexity**: `O(N)`, where `N` is the length of the input string. Each character is processed once.

### Space Complexity
- **Output StringBuilder**: `O(N)`, to store the resulting output message.
- **Dictionary**: `O(1)`.

## Running the Program

1. Ensure you have a C# development environment set up.
2. Clone or download the project files.
3. Open the solution in your IDE (e.g., Visual Studio).
4. Build and run the `Program.cs` file.
5. Enter inputs directly into the console and observe the converted outputs.

## Example Usage
```csharp
string input = "227*#"; 
var result = OldPhone.OldPhonePad(input);
Console.WriteLine($"Output: {result}"); // Prints "B"
```