using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib
{
    public class History
    {
        public List<double> Memory { get; private set; } = new List<double>();
        string histNumInput;
        string histResult;
        int listedCount;

        public List<double> GetListed(string numInput)
        {
            histNumInput = numInput;
            //
            // --------- CHECK here why the GetList() is still ZERO??
            //
            List<double> listed = xcalculatorProgram.GetList();
            listedCount = listed.Count;
            return listed;            
        }
        public void Validating()
        {
            if (histNumInput == "h")
            {
                if (listedCount == 0)
                {
                    // Ask the user to type the first number.
                    Console.Write("History is Empty Please type again: ");
                    histNumInput = Console.ReadLine();
                }
                else
                {
                    histResult = xcalculatorProgram.UseHistory(histNumInput);
                    histNumInput = histResult;
                }
            }
        }

        public void Add(double result)
        {
            Memory.Add(result);
        }

        public void Clear()
        {
            Memory.Clear();
        }
    }
}
