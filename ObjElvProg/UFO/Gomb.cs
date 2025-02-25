using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFO
{
    internal class Gomb
    {
        private Pont c;
        private double r;

        public Gomb(Pont c, double r)
        {
            if (r < 0)
            {
                throw new ArgumentException("Radius must be non-negative");
            }
            this.c = c;
            this.r = r;
        }

        public bool Tartalmazza(Pont p)
        {
            return this.c.Tavolsag(p) <= this.r;
        }
    }
}
