using CountingLibrary;

namespace ClearMeasureInterview
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FizzBuzzPortable fizzBuzz = new(100);
            FizzBuzzPortable fizzBuzz = new(int.MaxValue);

            foreach (var item in fizzBuzz.Execute())
            {
                Console.WriteLine(item);
            }
        }
    }
}