using CountingLibrary.Interfaces;

namespace CountingLibrary
{
    public class FizzBuzzPortable : IFizzBuzzPortable
    {
        private readonly int upperBound;
        private readonly IEnumerable<IFizzBuzzModulo> modulos;

        public FizzBuzzPortable(int upperBound, IEnumerable<IFizzBuzzModulo> modulos = null)
        {
            this.modulos = modulos ?? new List<IFizzBuzzModulo>()
            {
                new FizzBuzzModulo("Jonathan", 3),
                new FizzBuzzModulo("Markman", 5),
                new FizzBuzzModulo("Jonathan Markman", 3, 5)
            }.OrderByDescending(x => x.NumberOfModulusOperations);

            this.upperBound = upperBound;
        }

        public IEnumerable<string> Execute()
        {
            for (int i = 1; i <= upperBound; i++)
            {
                var moduloTestsDidNotPass = true;
                foreach (var modulo in modulos)
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