using System.Net;

namespace MutualAuthCalculatorService
{
    public class MutualAuthCalculator : ICalculator
    {
        public MutualAuthCalculator()
        {
        }
        
        public string GetVersion()
        {
            return "Calculator 3.0 - Mutual Authentication ";
        }

        public double Add(double value1, double value2)
        {
            return value1 + value2;
        }

        public double Substract(double value1, double value2)
        {
            return value1 - value2;
        }

        public double Multiply(double value1, double value2)
        {
            return value1 * value2;
        }

        public double Divide(double value1, double value2)
        {
            return value1 / value2;
        }
    }
}