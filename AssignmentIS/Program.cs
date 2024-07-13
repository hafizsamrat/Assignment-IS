using AssignmentIS;

public class Program
{
    public static void Main(String[] args)
    {
        string input;

        // Continuously reads input from the console until an empty line is entered.
        // Input will contain numbers (2 to 9), a space between numbers and '#' in the end.
        while (!string.IsNullOrEmpty(input = Console.ReadLine()))
        {
            // Calls the OldPhonePad method to process the input and get the old phone pad result.
            var result = OldPhone.OldPhonePad(input);
            Console.WriteLine($"Output: {result}");
        }
    }
}