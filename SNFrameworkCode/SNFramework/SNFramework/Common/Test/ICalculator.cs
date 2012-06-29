using System;
using System.ServiceModel;

namespace Legendigital.Framework.Common.Test
{
    [Serializable]
    public class BinaryOperationArgs
    {
        private double x;
        private double y;

        public BinaryOperationArgs(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get { return x; }
        }

        public double Y
        {
            get { return y; }
        }
    }

    [Serializable]
    public class OperationResult
    {
        private double result;

        public OperationResult(double result)
        {
            this.result = result;
        }

        public double Result
        {
            get { return result; }
        }
    }

    [ServiceContract(Namespace = "http://Legendigital.Framework.Common.Test")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract]
        double Subtract(double n1, double n2);
        [OperationContract]
        double Multiply(double n1, double n2);
        [OperationContract]
        double Divide(double n1, double n2);
        [OperationContract]
        string GetName();
        [OperationContract]
        OperationResult Power(BinaryOperationArgs args);
    }
}
