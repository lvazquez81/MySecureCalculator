using System.ServiceModel;

namespace MutualAuthCalculatorService
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        string GetVersion();

        [OperationContract]
        double Add(double value1, double value2);

        [OperationContract]
        double Substract(double value1, double value2);

        [OperationContract]
        double Multiply(double value1, double value2);

        [OperationContract]
        double Divide(double value1, double value2);
    }
}
