using FluentAssertions;

namespace CountingLibrary.Tests
{
    public class FizzBuzzTests
    {
        [Test]
        public void Should_Return_Sequence_With_Length_Equal_To_Upper_Bound()
        {
            // Arrange
            var expectedCount = 15;
            var subject = CreateSubject();

            // Act
            var result = subject.Execute();

            // Assert
            result.Should().NotBeEmpty();
            result.Should().HaveCount(expectedCount);
        }

        [Test]
        public void Should_Return_Empty_Collection_If_Upper_Bound_Is_Less_Than_Zero()
        {
            // Arrange
            var boundaryLessThanZero = -1;
            var subject = CreateSubject(boundaryLessThanZero);

            // Act
            var result = subject.Execute();

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void Should_Return_Empty_Collection_If_Upper_Bound_Is_Equal_To_Zero()
        {
            // Arrange
            var boundaryEqualToZero = 0;
            var subject = CreateSubject(boundaryEqualToZero);

            // Act
            var result = subject.Execute();

            // Assert
            result.Should().BeEmpty();
        }

        /// <summary>
        /// Running a test like this with in32.MaxValue will cause the host
        /// machine to allocate way more than 4gb of RAM for a sequence of
        /// numbers stored as strings.
        /// </summary>
        [Test]
        public void Should_Support_Upper_Bound_To_Absurd_Size()
        {
            // Arrange
            var largeValue = 3000000;
            var subject = CreateSubject(largeValue);

            // Act
            var result = subject.Execute();

            // Assert
            result.Should().NotBeEmpty();
            result.Count().Should().Be(largeValue);
        }

        [Test]
        public void Should_Return_Integer_Sequence_With_No_Modifications_If_No_Modulo_Operations_Provided()
        {
            // Arrange
            var expected = new string[] { "1", "2", "3", "4", "5" };
            var upperBound = 5;
            var subject = CreateSubject(upperBound);

            // Act
            var result = subject.Execute();

            // Asert
            result.Should().Equal(expected);
        }

        private FizzBuzz CreateSubject(int boundary = 15) => new FizzBuzz(boundary);
    }
}