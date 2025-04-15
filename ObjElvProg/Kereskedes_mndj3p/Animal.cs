using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kereskedes_mndj3p
{
    internal class Animal
    {
        private string animalID;
        private Species species;
        private string color;
        private int age;
        private int realValue;
        public Animal(string animalID, Species species, string color, int age)
        {
            this.animalID = animalID;
            this.species = species;
            this.color = color;
            this.age = age;
            this.realValue = species.CalculateRealValue();
        }

        public Species Species
        {
            get { return species; }
            set { species = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
    }
}
