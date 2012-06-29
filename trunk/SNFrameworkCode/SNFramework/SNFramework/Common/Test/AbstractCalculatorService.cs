using System;
using System.Threading;

namespace Legendigital.Framework.Common.Test
{
    public class AbstractCalculatorService : ICalculator
    {
 

        public double Add(double n1, double n2)
        {
            Thread.Sleep(1*1000);
            return n1 + n2;
        }

        public double Subtract(double n1, double n2)
        {
            Thread.Sleep(1 * 1000);
            return n1 - n2;

        }

        public double Multiply(double n1, double n2)
        {
            Thread.Sleep(1 * 1000);
            return n1 * n2;

        }

        public double Divide(double n1, double n2)
        {
            Thread.Sleep(1 * 1000);
            return n1 / n2;

        }

        public OperationResult Power(BinaryOperationArgs args)
        {            
            // do something
            return new OperationResult( Math.Pow(args.X, args.Y) );
        }

        public virtual string GetName()
        {
            return "AAAAA";
        }
    }
}