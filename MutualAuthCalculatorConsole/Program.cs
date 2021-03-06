﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MutualAuthCalculatorService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback =
                delegate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors sslError)
                {
                    // Ignoring certificate name missmatch with service.
                    return (sslError == SslPolicyErrors.None || sslError == SslPolicyErrors.RemoteCertificateNameMismatch);
                };

            CallCalculatorOperation();
        }

        private static void CallCalculatorOperation()
        {
            var myService = new CalculatorProxy.CalculatorClient();

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
                    error.AppendFormat("---> {0}\r\n", innerEx.Message);
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

        private static void CallGetOperation()
        {
            var myService = new CalculatorProxy.CalculatorClient();

            try
            {
                Console.WriteLine("Calculator Service Test\r\n");

                string version = myService.GetVersion();

                Console.WriteLine(string.Format("Calculator service: {0}\r\n", version));
            }
            catch (Exception ex)
            {
                var error = new StringBuilder();

                error.AppendFormat("Error: {0}\r\n", ex.Message);

                Exception innerEx = ex.InnerException;

                while (innerEx != null)
                {
                    error.AppendFormat("---> {0}\r\n", innerEx.Message);
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
