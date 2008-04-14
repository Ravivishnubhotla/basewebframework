using System;
using System.Runtime.InteropServices;

namespace Powerasp.Enterprise.Core.Maths
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Complex
    {
        private const double T = 1.5707963268;
        private static readonly double[] ChebyshevConst;
        private double _real;
        private double _image;
        public double Real
        {
            get
            {
                return this._real;
            }
            set
            {
                this._real = value;
            }
        }
        public double Image
        {
            get
            {
                return this._image;
            }
            set
            {
                this._image = value;
            }
        }
        public Complex(double real, double image)
        {
            this._real = real;
            this._image = image;
        }

        public double Abs()
        {
            Complex complex = new Complex(Math.Abs(this.Real), Math.Abs(this.Image));
            if (complex.Real == 0.0)
            {
                return complex.Image;
            }
            if (complex.Image == 0.0)
            {
                return complex.Real;
            }
            if (complex.Real > complex.Image)
            {
                return (complex.Real * Math.Sqrt(1.0 + ((complex.Image / complex.Real) * (complex.Image / complex.Real))));
            }
            return (complex.Image * Math.Sqrt(1.0 + ((complex.Real / complex.Image) * (complex.Real / complex.Image))));
        }

        public Complex Pow(double x)
        {
            double num2;
            if ((this.Real == 0.0) || (this.Image == 0.0))
            {
                return new Complex(0.0, 0.0);
            }
            if (this.Real == 0.0)
            {
                if (this.Image > 0.0)
                {
                    num2 = 1.5707963268;
                }
                else
                {
                    num2 = -1.5707963268;
                }
            }
            else if (this.Real > 0.0)
            {
                num2 = Math.Atan(this.Image / this.Real);
            }
            else if (this.Image >= 0.0)
            {
                num2 = Math.Atan(this.Image / this.Real) + 3.1415926535897931;
            }
            else
            {
                num2 = Math.Atan(this.Image / this.Real) - 3.1415926535897931;
            }
            double num = Math.Exp(x * Math.Log(Math.Sqrt((this.Real * this.Real) + (this.Image * this.Image))));
            return new Complex(num * Math.Cos(x * num2), num * Math.Sin(x * num2));
        }

        public override int GetHashCode()
        {
            return this.Real.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return (this == ((Complex) obj));
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Real + b.Real, a.Image + b.Image);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Real - b.Real, a.Image - b.Image);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex((a.Real * b.Real) - (a.Image * b.Image), (a.Real * b.Image) + (a.Image * b.Real));
        }

        public static Complex operator /(Complex a, Complex b)
        {
            double num;
            double num2;
            if (a.Abs() >= b.Abs())
            {
                num = b.Image / b.Real;
                num2 = b.Real + (num * b.Image);
                return new Complex((a.Real + (a.Image * num)) / num2, (a.Image - (a.Real * num)) / num2);
            }
            num = b.Real / b.Image;
            num2 = b.Image + (num * b.Real);
            return new Complex(((a.Real * num) + a.Image) / num2, ((a.Image * num) - a.Real) / num2);
        }

        public static bool operator !=(Complex a, Complex b)
        {
            if (a.Real == b.Real)
            {
                return (a.Image != b.Image);
            }
            return true;
        }

        public static bool operator ==(Complex a, Complex b)
        {
            return ((a.Real == b.Real) && (a.Image == b.Image));
        }

        static Complex()
        {
            ChebyshevConst = new double[] { 1.13031820798497, 0.04433684984866, 0.00054292631191, 3.19843646E-06, 1.103607E-08, 2.498E-11 };
        }
    }
}