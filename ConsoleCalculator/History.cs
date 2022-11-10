using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CalculatorLib;

namespace HistoryName
{
    public class History
    {
        CalculatorProgram xcalculatorProgram = new CalculatorProgram();        
        string histNumInput;
        string histResult;
        int listedCount;
        public object GetListed(string numInput)
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
    }
}
