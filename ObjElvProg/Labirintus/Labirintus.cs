using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirintus
{
    internal class Labirintus
    {
        private int n, m;
        Tartalom[,] terkep;

        public Labirintus(Tartalom[,] terkep)
        {
            this.terkep = terkep;
            n = terkep.GetLength(0);
            m = terkep.GetLength(1);
        }

        public void Elhelyez(Pozicio p, Tartalom t)
        {
            terkep[p.getX(), p.getY()] = t;
        }

        public Tartalom Kemlel(Pozicio poz, Pozicio irany)
        {
            
        }
    }
}
