using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allatok
{
    abstract class Allat
    {
        protected int labak;

        public int GetLabak()
        {
            return labak;
        }

        abstract public string Beszel();

        public class Tehen : Allat
        {
            public Tehen()
            {
                labak = 4;
            }

            public override string Beszel()
            {
                Console.WriteLine("Múúú");
                return "Múúú";
            }
        }

        public class Csirke : Allat
        {
            public Csirke()
            {
                labak = 2;
            }

            public override string Beszel()
            {
                Console.WriteLine("Kot-kot");
                return "Kot-kot";
            }
        }
    }
}
