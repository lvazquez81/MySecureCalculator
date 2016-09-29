namespace SecureCalculatorService
{
    public class SecureCalculator : ICalculator
    {
        public string GetVersion()
        {
            return "Calculator 2.0 - Secure with Certificate ";
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
