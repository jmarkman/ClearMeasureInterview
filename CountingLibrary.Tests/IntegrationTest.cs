using CountingLibrary.Interfaces;
using FluentAssertions;

namespace CountingLibrary.Tests
{
    public class IntegrationTest
    {
        [Test]
        public void Should_Satisfy_Basic_FizzBuzz_Implementation()
        {
            // Arrange
            var upperBound = 100;
            var expectedWords = new string[] { "Jonathan", "Markman", "Jonathan Markman" };
            var moduloExpressions = new List<IModulo>()
            {
                new Modulo("Jonathan Markman", 3, 5),
                new Modulo("Jonathan", 3),
                new Modulo("Markman", 5)
            };
            var subject = new FizzBuzz(upperBound, moduloExpressions);

            // Act
            var result = subject.Execute();

            // Assert
            result.Should().HaveCount(upperBound);
            var numbersFromResult = result.Where(x => int.TryParse(x, out int _)).Select(y => Convert.ToInt32(y));
            var wordsFromResult = result.Where(x => !int.TryParse(x, out int _));

            numbersFromResult.Should().AllSatisfy(x =>
            {
                x.Should().Match(x => x % 3 != 0);
                x.Should().Match(x => x % 5 != 0);
                x.Should().Match(x => x % 3 != 0 && x % 5 != 0);
            });

            wordsFromResult.Should().Contain(expectedWords);
        }

        [Test]
        public void Should_Support_Multiple_Modulo_Statements()
        {
            // Arrange
            var upperBound = 100;
            var expectedWords = new string[] { "Foo", "Bar", "Baz", "Ping", "Pong" };
            var moduloExpressions = new List<IModulo>()
            {
                new Modulo("Foo", 3),
                new Modulo("Ping", 4),
                new Modulo("Bar", 5),
                new Modulo("Pong", 22),
                new Modulo("Baz", 29)
            };
            var subject = new FizzBuzz(upperBound, moduloExpressions);

            // Act
            var result = subject.Execute();

            // Assert
            result.Should().HaveCount(upperBound);
            var numbersFromResult = result.Where(x => int.TryParse(x, out int _)).Select(y => Convert.ToInt32(y));
            var wordsFromResult = result.Where(x => !int.TryParse(x, out int _));

            numbersFromResult.Should().AllSatisfy(x =>
            {
                x.Should().Match(x => x % 3 != 0);
                x.Should().Match(x => x % 4 != 0);
                x.Should().Match(x => x % 5 != 0);
                x.Should().Match(x => x % 22 != 0);
                x.Should().Match(x => x % 29 != 0);
            });

            wordsFromResult.Should().Contain(expectedWords);
        }

        [Test]
        public void Should_Support_Multiple_Modulo_Statements_With_More_Than_Two_Moduli()
        {
            // Arrange
            var upperBound = 100;
            var expectedWords = new string[] { "Foo" };
            var moduloExpressions = new List<IModulo>()
            {
                new Modulo("Foo", 3, 5, 15)
            };
            var subject = new FizzBuzz(upperBound, moduloExpressions);

            // Act
            var result = subject.Execute();

            // Assert
            result.Should().HaveCount(upperBound);
            var numbersFromResult = result.Where(x => int.TryParse(x, out int _)).Select(y => Convert.ToInt32(y));
            var wordsFromResult = result.Where(x => !int.TryParse(x, out int _));

            numbersFromResult.Should().AllSatisfy(x => {
                x.Should().Match(x => !(x % 3 == 0 && x % 5 == 0 && x % 15 == 0));
            });

            wordsFromResult.Should().Contain(expectedWords);            
        }
    }
}
