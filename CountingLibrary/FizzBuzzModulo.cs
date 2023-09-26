using CountingLibrary.Interfaces;

namespace CountingLibrary
{
    public class FizzBuzzModulo : IFizzBuzzModulo
    {
        private readonly int[] modulus;
        private readonly string output;

        public int NumberOfModulusOperations => modulus.Length;

        public FizzBuzzModulo(string output, params int[] modulus)
        {
            this.modulus = modulus ?? throw new ArgumentNullException(nameof(modulus));
            this.output = output ?? throw new ArgumentNullException(nameof(output));
        }

        /// <summary>
        /// Determines if the input is evenly divisible by the moduli in this instance of
        /// the <see cref="FizzBuzzModulo"/> class.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns><see cref="true"/> if all modulo operations on the input return 0 
        /// (even division) and will assign the class instance's custom output to the out 
        /// variable. If all modulo operations do not result in even division, the out 
        /// variable will return an empty string.</returns>
        public bool EvaluateForEvenDivisibility(int input, out string output)
        {
            var allModuloOperationsTrue = modulus.All(x => input % x == 0);

            if (allModuloOperationsTrue)
            {
                output = this.output; 
                return true;
            }

            output = string.Empty;
            return false;
        }
    }
}
