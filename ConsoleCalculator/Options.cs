namespace ConsoleCalculator
{
    internal static class Options
    {

        public static void DisplayMainOptions()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("\tv - View History");
            Console.WriteLine("\to - Calculator");
            Console.WriteLine("\te - Exit");
            Console.Write("Your option?");
        }

        public static void DisplayOperatorOptions()
        {
            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.WriteLine("\tr - Square root - only 1st input is valid");
            Console.Write("Your option? ");
        }
    }
}