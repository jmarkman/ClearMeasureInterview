namespace CountingLibrary.Tests
{
    public class ModuloTests
    {
        [Test]
        public void Should_Throw_Exception_If_Output_Argument_Is_Null()
        {
            // Arrange
            Action subject = () => CreateSubject(null, 3);

            // Act
            // Assert
            subject.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Should_Throw_Exception_If_Modulus_Argument_Is_Not_Provided()
        {
            // Arrange
            Action subject = () => CreateSubject();

            // Act
            // Assert
            subject.Should().Throw<ArgumentException>();
        }

        [Test]
        public void Should_Return_True_If_Input_Is_Evenly_Divisible_By_Modulus()
        {
            // Arrange
            var inputThatIsDivisibleByThree = 12;
            var subject = CreateSubject(moduli: 3);

            // Act
            var result = subject.EvaluateForEvenDivisibility(inputThatIsDivisibleByThree, out _);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void Should_Have_Out_Var_Set_To_Provided_Output_If_Even_Divisibility_Check_Succeeds()
        {
            // Arrange
            var input = 12;
            var expectedOutput = "Fizz";
            var subject = CreateSubject(expectedOutput, 3);

            // Act
            var result = subject.EvaluateForEvenDivisibility(input, out var output);

            // Assert
            result.Should().BeTrue();
            output.Should().Be(expectedOutput);
        }

        [Test]
        public void Should_Have_Out_Var_Set_To_Empty_String_If_Even_Divisibility_Check_Fails()
        {
            // Arrange
            var input = 5;
            var subject = CreateSubject(moduli: 3);

            // Act
            var result = subject.EvaluateForEvenDivisibility(input, out var output);

            // Assert
            result.Should().BeFalse();
            output.Should().BeEmpty();
        }

        private Modulo CreateSubject(string message = "Test", params int[] moduli) => new Modulo(message, moduli);
    }
}
