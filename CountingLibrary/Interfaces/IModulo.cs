namespace CountingLibrary.Interfaces
{
    public interface IModulo
    {
        int NumberOfModulusOperations { get; }
        bool EvaluateForEvenDivisibility(int input, out string output);
    }
}
