using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace CalculatorLib
{
    public class CalculatorProgram
    {
        JsonWriter writer;
        private int _calUsageCount = 0;
        //private string _histNum;
        private double _returnSelectHist;
        History history = new History();

        public CalculatorProgram()
        {
            //StreamWriter logFile = File.CreateText("calculatorlog.json");
            //logFile.AutoFlush = true;
            //writer = new JsonTextWriter(logFile);
            //writer.Formatting = Formatting.Indented;
            //writer.WriteStartObject();
            //writer.WritePropertyName("Operations");
            //writer.WriteStartArray();
        }

        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.
            //writer.WriteStartObject();
            //writer.WritePropertyName("Operand1");
            //writer.WriteValue(num1);
            //writer.WritePropertyName("Operand2");
            //writer.WriteValue(num2);
            //writer.WritePropertyName("Operation");
            // Use a switch statement to do the math.
            switch (op)
            {
                case "z":
                    break;
                case "a":
                    result = num1 + num2;
                    //calResults.Add(result);
                    //writer.WriteValue("Add");
                    break;
                case "s":
                    result = num1 - num2;
                    history.Add(result);
                    calResults.Add(result);
                    //writer.WriteValue("Subtract");
                    break;
                case "m":
                    result = num1 * num2;
                    calResults.Add(result);
                    //writer.WriteValue("Multiply");
                    break;
                case "r":
                    result = Math.Sqrt(num1);
                    calResults.Add(result);
                    //writer.WriteValue("SquareRoot");
                    break;
                case "p":
                    result = num1 * 10;
                    calResults.Add(result);
                    //writer.WriteValue("PowerOf");
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        calResults.Add(result);
                        //writer.WriteValue("Divide");
                    }
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            //writer.WritePropertyName("Result");
            //writer.WriteValue(result);
            //writer.WriteEndObject();

            // increment the Calculator usage, used with the Cal_Usage Method.
            _calUsageCount++;
            return result;
        }
        public void Finish()
        {
            //writer.WriteEndArray();
            //writer.WriteEndObject();
            //writer.Close();
        }
        public int Cal_Usage()
        {
            return _calUsageCount;
        }
        public void EndHistory()
        {
            Console.WriteLine("\n<---- History ---->\n");
            PrintList();
            Console.WriteLine("\n<----------------->\n");
        }
        public void ClearHistory()
        {
            history.Clear();
        }

        public List<double> GetHistory()
        {
            return history.Memory;
        }

        public void PrintList()
        {
            int i = 1;
            if (calResults.Count != 0)
            {
                foreach (double calResult in calResults)
                {
                    Console.WriteLine(i + ". " + calResult);
                    i++;
                }
            }
            else
            {
                Console.WriteLine("List is empty");
            }
        }
        // a method to allow to use historical results for further calculations
        public String UseHistory(string histNum)
        {
            PrintList();
            Console.Write("Please make a selection: ");
            int histNumber = int.Parse(Console.ReadLine());
            SelectHist(histNumber - 1);
            return Convert.ToString(_returnSelectHist);
        }
        // just to perform selection of specific calResults[item in the <LIST>]
        public double SelectHist(int histNumber)
        {
            try
            {
                _returnSelectHist = calResults[histNumber];
                return _returnSelectHist;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }

}