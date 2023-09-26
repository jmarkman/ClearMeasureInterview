using CountingLibrary;

namespace ClearMeasureInterview
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FizzBuzz fizzBuzz = new(int.MaxValue);

            foreach (var item in fizzBuzz.Execute())
            {
                Console.WriteLine(item);
            }
        }
    }
}