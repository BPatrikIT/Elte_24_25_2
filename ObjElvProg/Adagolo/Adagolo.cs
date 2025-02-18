using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adagolo
{
    internal class Adagolo
    {
        private double max;
        private double adag;
        private double akt;

        public Adagolo(double max, double adag)
        {

            if (! (max > 0 && adag > 0))
            {
                throw new ArgumentException("Max vagy Adag nem volt pozitiv.");
            }

            this.max = max;
            this.adag = adag;
            this.akt = 0.0;
        }

        public void nyom()
        {
            this.akt = Math.Max(this.akt - this.adag, 0.0);
        }
        public void Feltolt()
        {
            this.akt = this.max;
        }

        public bool Ures()
        {
            return akt == 0.0;
        }

    }
}
