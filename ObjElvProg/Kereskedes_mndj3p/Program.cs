using System.Diagnostics;

namespace Kereskedes_mndj3p
{
    internal class Program
    {
        static List<AnimalKeeper> animalKeepers = new List<AnimalKeeper>();
        static void Main(string[] args)
        {
            testState1();
            //Automatic test methods
            testMethods1();

            //Manual test methods
            /*
            if (animalSerach())
            {
                Console.WriteLine("Animal found.");
            }
            else
            {
                Console.WriteLine("Animal not found.");
            }
            */
            Console.ReadKey();
        }

        //Test data for the program
        static void testState1()
        {
            Address tempAdress = new Address("Hungary", "Budapest", "Fő utca", 1, 1234);
            AnimalKeeper NagyMancsokAllatker = new AnimalKeeper("Nagy Mancsok Kisállatkereskedés", tempAdress, "ABC123456", true);
            tempAdress = new Address("Hungary", "Szeged", "Vár utca", 4, 2234);
            AnimalKeeper KissPeter = new AnimalKeeper("Kiss Péter", tempAdress, "RTY678901", false);
            tempAdress = new Address("Hungary", "Budapest", "Kis utca", 2, 12349, 2, 1);
            AnimalKeeper KovacsBela = new AnimalKeeper("Kovács Béla", tempAdress, "XYZ987654", false);
            tempAdress = new Address("Hungary", "Debrecen", "Kossuth utca", 3, 3234);
            AnimalKeeper NagyAnna = new AnimalKeeper("Nagy Anna", tempAdress, "QWE5443210", false);
            animalKeepers.Add(NagyMancsokAllatker);
            animalKeepers.Add(KissPeter);
            animalKeepers.Add(KovacsBela);
            animalKeepers.Add(NagyAnna);

            Bill tempBill = new Bill("H123", "RTY678901", "ABC123456", "03/15/2025", 3000);
            Species hamster = new Hamster("black");
            Animal tempAnimal = new Animal("H123", hamster, "black", 2);
            NagyMancsokAllatker.Bills.Add(tempBill);
            KissPeter.Bills.Add(tempBill);

            tempBill = new Bill("H123", "ABC123456", "XYZ987654", "04/01/2025", 3000);
            NagyMancsokAllatker.Bills.Add(tempBill);
            KovacsBela.Bills.Add(tempBill);
            KovacsBela.Animals.Add(tempAnimal);

            tempBill = new Bill("P456", "ABC123456", "QWE543210", "04/05/2025", 7000);
            Species finch = new Finch("yellow");
            tempAnimal = new Animal("P456", finch, "yellow", 3);
            NagyAnna.Bills.Add(tempBill);
            NagyAnna.Animals.Add(tempAnimal);
        }

        //Test methods
        //Van-e egy állattartónak adott színű pintye?
        static void testMethods1()
        {
            if (animalSearch("Nagy Anna", "finch", "yellow"))
            {
                Console.WriteLine("Animal found.");
            }
            else
            {
                Console.WriteLine("Animal not found.");
            }
        }

        //Animal search method
        static bool animalSearch(string  animalKeeperName, string animalName, string animalColor)
        {
            bool haveAnimal = false;
            int animalKeeperIndex = -1;
            for (int i = 0; i < animalKeepers.Count; i++)
            {
                if (animalKeepers[i].Name.ToLower() == animalKeeperName.ToLower())
                {
                    animalKeeperIndex = i;
                    break;
                }
            }

            if (animalKeeperIndex == -1)
            {
                Console.WriteLine("Animal Keeper was not found in the database.");
            }
            else
            {
                Debug.WriteLine("Animal Keeper found: " + animalKeepers[animalKeeperIndex].Name);
                for (int i = 0; i < animalKeepers[animalKeeperIndex].Animals.Count; i++)
                {
                    if (animalKeepers[animalKeeperIndex].Animals[i].Species.GetSpeciesName().ToLower() == animalName.ToLower() && animalKeepers[animalKeeperIndex].Animals[i].Color.ToLower() == animalColor.ToLower())
                    {
                        haveAnimal = true;
                        break;
                    }
                }
            }

            return haveAnimal;
        }
        static bool animalSerach()
        {
            bool haveAnimal = false;

            Console.WriteLine("Who you want to check?");
            string animalKeeperName = Console.ReadLine();
            Console.WriteLine("Which animal do you want to find?");
            string animalName = Console.ReadLine();
            Console.WriteLine("What is the color of the animal?");
            string animalColor = Console.ReadLine();

            int animalKeeperIndex = -1;
            for (int i = 0; i < animalKeepers.Count; i++)
            {
                if (animalKeepers[i].Name.ToLower() == animalKeeperName.ToLower())
                {
                    animalKeeperIndex = i;
                    break;
                }
            }

            if (animalKeeperIndex == -1)
            {
                Console.WriteLine("Animal Keeper was not found in the database.");
            }
            else
            {
                Debug.WriteLine("Animal Keeper found: " + animalKeepers[animalKeeperIndex].Name);
                for (int i = 0; i < animalKeepers[animalKeeperIndex].Animals.Count; i++)
                {
                    if (animalKeepers[animalKeeperIndex].Animals[i].Species.GetSpeciesName().ToLower() == animalName.ToLower() && animalKeepers[animalKeeperIndex].Animals[i].Color.ToLower() == animalColor.ToLower())
                    {
                        haveAnimal = true;
                        break;
                    }
                }
            }

            return haveAnimal;
        }
    }
}
