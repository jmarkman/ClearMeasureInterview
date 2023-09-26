namespace CountingLibrary.Interfaces
{
    public interface IFizzBuzzModulo
    {
        int NumberOfModulusOperations { get; }
        bool EvaluateForEvenDivisibility(int input, out string output);
    }
}
