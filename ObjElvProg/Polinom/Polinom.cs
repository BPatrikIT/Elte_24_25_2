using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinom
{
    internal class Polinom
    {
        private double a, b, c;
        public Polinom(double x, double y, double z)
        {
            if (x == 0)
            {
                throw new ArgumentException("X cannot be 0");
            }
            
            this.a = x;
            this.b = y;
            this.c = z;
        }

        public double Value(double x)
        {
            return a * Math.Pow(x, 2) + b * x + c;
        }
    }
}
