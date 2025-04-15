using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kereskedes_mndj3p
{
    internal class AnimalKeeper
    {
        private string name;
        private Address adress;
        private string idNumber;
        private bool shop;
        private List<Bill> bills = new List<Bill>();
        private List<Animal> animals = new List<Animal>();
        public AnimalKeeper(string name, Address adress, string idNumber, bool shop)
        {
            this.name = name;
            this.adress = adress;
            this.idNumber = idNumber;
            this.shop = shop;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Bill> Bills
        {
            get { return bills; }
            set { bills = value; }
        }

        public List<Animal> Animals
        {
            get { return animals; }
            set { animals = value; }
        }
    }
}
