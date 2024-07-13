using AssignmentIS;

namespace AssigenmentISTests
{
    public class OldPhoneTest
    {
        [Fact]
        public void ShouldReturnValidOutputOnValidInput()
        {
            var inputOutputList = new List<(string, string)>
            {
                ("33#", "E"),
                ("227*#", "B"),
                ("4433555 555666#", "HELLO"),
                ("8 88777444666*664#", "TURING"),
                ("8****88777555#", "URL"),
                ("3344**2 6 7 **#", "A"),
                ("444777666 66777766633389277733#", "IRONSOFTWARE"),
            };

            VerifyInputOutputList(inputOutputList);
        }

        [Fact]
        public void ShouldReturnValidEmptyOutputOnValidInput()
        {
            var inputOutputList = new List<(string, string)>
            {
                ("#", ""),
                ("**#", ""),
                ("*3*#", ""),
                ("3344**2 6 *7 **#", ""),
            };

            VerifyInputOutputList(inputOutputList);
        }

        [Fact]
        public void ShouldReturnValidOutputOnValidInputWithCycle()
        {
            var inputOutputList = new List<(string, string)>
            {
                ("2222#", "A"),
                ("222233333444444#", "AEI")
            };

            VerifyInputOutputList(inputOutputList);
        }

        private void VerifyInputOutputList(List<(string, string)> inputOutputList)
        {
            // Iterate through each input-output pair and verify the output.
            foreach (var inputOutput in inputOutputList)
            {
                var actual = OldPhone.OldPhonePad(inputOutput.Item1); // Get the actual output from the method.
                var expected = inputOutput.Item2; // Retrieve the expected output from the test data.
                Assert.Equal(expected, actual); // Compare actual and expected outputs using Assert.Equal method.
            }
        }
    }
}