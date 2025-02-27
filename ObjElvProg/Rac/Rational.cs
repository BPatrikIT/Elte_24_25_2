using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HF1
{
    internal class Rational
    {
        private int n, d;

        public Rational(int n, int d)
        {
            if (d == 0)
            {
                throw new ArgumentException("d cannot be 0");
            }

            this.n = n;
            this.d = d;
        }

        public static Rational Add(Rational a, Rational b)
        {
            return new Rational(a.n * b.d + b.n * a.d, a.d * b.d);
        }

        public static Rational operator +(Rational a, Rational b)
        {
            return Add(a, b);
        }

        public static Rational Substract(Rational a, Rational b)
        {
            return new Rational(a.n * b.d - b.n * a.d, a.d * b.d);
        }

        public static Rational operator -(Rational a, Rational b)
        {
            return Substract(a, b);
        }

        public static Rational Multiply(Rational a, Rational b)
        {
            return new Rational(a.n * b.n, a.d * b.d);
        }

        public static Rational operator *(Rational a, Rational b)
        {
            return Multiply(a, b);
        }

        public static Rational Divide(Rational a, Rational b)
        {
            return new Rational(a.n * b.d, a.d * b.n);
        }

        public static Rational operator /(Rational a, Rational b)
        {
            return Divide(a, b);
        }

        public override string ToString()
        {
            return n + "/" + d;
        }



    }
}
