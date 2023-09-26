namespace CountingLibrary
{
    public class FizzBuzzPortable
    {
        private readonly string firstName = "Jonathan";
        private readonly string lastName = "Markman";
        private int upperBound;

        public FizzBuzzPortable(int upperBound)
        {
            this.upperBound = upperBound;
        }

        public IEnumerable<string> Execute()
        {
            for (int i = 1; i <= upperBound; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    yield return $"{firstName} {lastName}";
                }
                else if (i % 3 == 0)
                {
                    yield return firstName;
                }
                else if (i % 5 == 0)
                {
                    yield return lastName;
                }
                else
                {
                    yield return i.ToString();
                }
            }
        }
    }
}