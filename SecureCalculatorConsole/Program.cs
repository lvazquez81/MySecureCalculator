using System;
using System.Text;

namespace SecureCalculatorService
{
    class Program
    {
        static void Main(string[] args)
        {
            var myService = new CalculatorProxy.CalculatorClient();

            try
            {
                Console.WriteLine("Calculator Service Test\r\n");

                double value1 = 1;
                double value2 = 2;

                string calcVersion = myService.GetVersion();
                Console.WriteLine(string.Format("Version: {0}\r\n", myService.GetVersion()));

                double resultSum = myService.Add(value1, value2);
                Console.WriteLine(string.Format("Add:\t\t\t{0} + {1} = {2}\r\n", value1, value2, resultSum));

                //double resultSubs = myService.Substract(value1, value2);
                //Console.WriteLine(string.Format("Substract:\t\t{0} - {1} = {2}\r\n", value1, value2, resultSubs));

                //double resultMult = myService.Multiply(value1, value2);
                //Console.WriteLine(string.Format("Multiply:\t\t{0} * {1} = {0}\r\n", value1, value2, resultMult));

                //double resultDiv = myService.Divide(value1, value2);
                //Console.WriteLine(string.Format("Divide:\t\t\t{0} / {1} = {0}\r\n", value1, value2, resultDiv));
            }
            catch (Exception ex)
            {
                var error = new StringBuilder();

                error.AppendFormat("Error: {0}\r\n", ex.Message);

                Exception innerEx = ex.InnerException;

                while (innerEx != null)
                {
                    error.AppendFormat("--- Error detail: {0}.\r\n", innerEx.Message);
                    innerEx = innerEx.InnerException;
                }

                Console.WriteLine(error.ToString());
            }
            finally
            {
                Console.WriteLine("Press any key to end.");
                Console.ReadKey();
            }
        }
    }
}
