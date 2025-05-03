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
        private List<string> partners = new List<string>();
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

        public string IdNumber
        {
            get { return idNumber; }
            set { idNumber = value; }
        }

        public List<Bill> Bills
        {
            get { return bills; }
            set { bills = value; }
        }

        public bool Shop
        {
            get { return shop; }
            set { shop = value; }
        }

        public List<Animal> Animals
        {
            get { return animals; }
            set { animals = value; }
        }

        public List<string> Partners
        {
            get { return partners; }
            set { partners = value; }
        }

        public (Animal expensiveAnimal, bool haveAnimal, Bill bill) mostExpensiveAnimal(List<AnimalKeeper> animalKeepers, Species spec)
        {
            Animal expensiveAnimal = null;
            int maxPrice = 0;
            Bill bill = null;

            bool haveAnimal = false;
            for (int i = 0; i < bills.Count(); i++)
            {
                if (bills[i].SellerIDNumber == this.idNumber && bills[i].Price > maxPrice)
                {
                    bool foundAnimal = false;
                    for (int j = 0; j < animalKeepers.Count(); j++)
                    {
                        for (int k = 0; k < animalKeepers[j].Animals.Count(); k++)
                        {
                            if (animalKeepers[j].Animals[k].AnimalID == bills[i].AnimalID)
                            {
                                foundAnimal = true;
                                if (animalKeepers[j].Animals[k].Species.GetSpeciesName() == spec.GetSpeciesName())
                                {
                                    haveAnimal = true;
                                    maxPrice = bills[i].Price;
                                    expensiveAnimal = animalKeepers[j].Animals[k];
                                    bill = bills[i];
                                }
                                break;
                            }
                        }
                        if (foundAnimal)
                        {
                            break;
                        }
                    }
                }
            }

            return (expensiveAnimal, haveAnimal, bill);
        }
    }
}
