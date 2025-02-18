using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFO
{
    internal class Pont
    {
        private double x, y, z;

        public Pont(double a, double b, double c)
        {
            this.x = a;
            this.y = b;
            this.z = c;
        }

        public double Tavolsag(Pont q)
        {
            return Math.Sqrt(Math.Pow(this.x - q.x, 2) + Math.Pow(this.y - q.y, 2) + Math.Pow(this.z - q.z, 2));
        }

        public static double Tavolsag(Pont p, Pont q)
        {
            return Math.Sqrt(Math.Pow(p.x - q.x, 2) + Math.Pow(p.y - q.y, 2) + Math.Pow(p.z - q.z, 2));
        }
    }
}
