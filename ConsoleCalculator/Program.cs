using System;
using System.Security.Cryptography.X509Certificates;
using CalculatorLib;
using HistoryName;
using Newtonsoft.Json;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Display title as the C# console calculator app.
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            CalculatorProgram calculatorProgram = new CalculatorProgram();
            History history = new History();            

            while (!endApp)
            {
                // Declare variables and set to empty.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;
                string histResult;

                Console.WriteLine("What would you like to do?");
                Console.WriteLine("\tv - View History");
                Console.WriteLine("\to - Calculator");
                Console.WriteLine("\te - Exit");
                Console.Write("Your option?");
                string opt = Console.ReadLine();
                if (opt == "v")
                {
                    // Calling the History Method
                    calculatorProgram.EndHistory();
                    Console.Write("Do you want to clear the history? Press 'y' to clear the history:");
                    string clearHistory = Console.ReadLine();
                    if (clearHistory == "y")
                    {
                        calculatorProgram.ClearHistory();
                    }
                }
                else if (opt == "e")
                {
                    endApp = true;
                }
                else
                {
                    // ***************************************************************
                    // ************* TRY TO MOVE ALL CODE IN THIS else TO NEW*********
                    // CLASS until the coment/// Ask the user to choose an operator.**
                    // ***************************************************************
                    //
                    // Ask the user to type the first number.
                    Console.Write("Type a number, and then press Enter or press 'h' to use history: ");
                    numInput1 = Console.ReadLine();

                    //history.GetListed(numInput1);
                    //history.Validating();

                    List<double> calledList = calculatorProgram.GetList();

                    // using history input                  
                    if (numInput1 == "h")
                    {
                        if (calledList == null)
                        {
                            // Ask the user to type the first number.
                            Console.Write("Type a number, and then press Enter or press 'h' to use history: ");
                            numInput1 = Console.ReadLine();
                        }
                        else
                        {
                            histResult = calculatorProgram.UseHistory(numInput1);
                            numInput1 = histResult;
                        }
                    }

                    double cleanNum1 = 0;
                    while (!double.TryParse(numInput1, out cleanNum1))
                    {
                        Console.Write("This is not valid input. Please enter an integer value: ");
                        numInput1 = Console.ReadLine();
                    }

                    // Ask the user to type the second number.
                    Console.Write("Type another number, and then press Enter or press 'h' to use history: : ");
                    numInput2 = Console.ReadLine();

                    // using history input
                    if (numInput2 == "h")
                    {
                        histResult = calculatorProgram.UseHistory(numInput2);
                        numInput2 = histResult;
                    }

                    double cleanNum2 = 0;
                    while (!double.TryParse(numInput2, out cleanNum2))
                    {
                        Console.Write("This is not valid input. Please enter an integer value: ");
                        numInput2 = Console.ReadLine();
                    }
                    //double cleanNum1 = 0;
                    //double cleanNum2 = 0;
                    //userNumberInput.CalValidNumber();
                    //userNumberInput.CleanNumbers();

                    // Ask the user to choose an operator.
                    Console.WriteLine("Choose an operator from the following list:");
                    Console.WriteLine("\ta - Add");
                    Console.WriteLine("\ts - Subtract");
                    Console.WriteLine("\tm - Multiply");
                    Console.WriteLine("\td - Divide");
                    Console.WriteLine("\tr - Square root - only 1st input is valid");
                    Console.Write("Your option? ");

                    string op = Console.ReadLine();

                    try
                    {
                        result = calculatorProgram.DoOperation(cleanNum1, cleanNum2, op);
                        if (double.IsNaN(result))
                        {
                            Console.WriteLine("This operation will result in a mathematical error.\n");
                        }
                        else
                        {
                            Console.WriteLine("Your result: {0:0.##}\n", result);
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("The calculator is used for " + calculatorProgram.Cal_Usage() + " times.");
                            //Console.WriteLine("-----------------------------------");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                    }

                    Console.WriteLine("-----------------------------------\n");

                    // Wait for the user to respond before closing.
                    Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                    if (Console.ReadLine() == "n")
                    {
                        endApp = true;                        
                    }
                    Console.WriteLine("\n"); // Friendly linespacing.
                }
                
            }
            calculatorProgram.Finish();
            return;
        }
    }
}