using CountingLibrary.Interfaces;

namespace CountingLibrary
{
    public class FizzBuzz : IFizzBuzz
    {
        private readonly int upperBound;
        private readonly List<IModulo> moduli;

        public FizzBuzz(int upperBound, IEnumerable<IModulo> moduli = null)
        {
            this.moduli = (moduli ?? new List<IModulo>()).OrderByDescending(x => x.NumberOfModulusOperations).ToList();
            this.upperBound = upperBound;
        }

        /// <summary>
        /// Generates a sequence of numbers and strings based on supplied modulo operations
        /// </summary>
        public IEnumerable<string> Execute()
        {
            for (int i = 1; i <= upperBound; i++)
            {
                var moduloTestsDidNotPass = true;
                foreach (var modulo in moduli)
                {
                    if (modulo.EvaluateForEvenDivisibility(i, out string output))
                    {
                        moduloTestsDidNotPass = false;
                        yield return output;
                        break;
                    }
                }

                if (moduloTestsDidNotPass)
                {
                    yield return i.ToString();
                }
            }
        }
    }
}