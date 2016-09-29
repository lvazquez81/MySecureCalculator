using System;
using System.Text;

namespace MyCalculatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var myService = new CalculatorService.CalculatorProxy.CalculatorClient();

            try
            {
                Console.WriteLine("Calculator Service Test\r\n");

                Console.WriteLine("Calling Calculator service...\r\n");

                double result = myService.Add(1, 1);

                Console.WriteLine(string.Format("Add: 1 + 1 = {0}{1}", result, Environment.NewLine));
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
