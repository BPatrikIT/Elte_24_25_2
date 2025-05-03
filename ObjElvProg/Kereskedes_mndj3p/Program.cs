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
            
            var animalCount = howManyAnimal();
            if (animalCount.animalCount > 0)
            {
                Console.WriteLine($"{animalCount.KeeperName} has {animalCount.animalCount} {animalCount.SpeciesName}(s).");
            }
            else
            {
                Console.WriteLine($"{animalCount.KeeperName} has no {animalCount.SpeciesName}.");
            }
            
            var billCount = howManyBillsHas();
            if (billCount.billCount > 0)
            {
                Console.WriteLine($"{billCount.KeeperName} has {billCount.billCount} bills from {billCount.animalShopName}.");
            }
            else
            {
                Console.WriteLine($"{billCount.KeeperName} has no bill(s) from {billCount.animalShopName}.");
            }
            
            var partnerCount = howManyPartnersHas();
            if (partnerCount.partnerCount > 0)
            {
                Console.WriteLine($"{partnerCount.animalShopName} has {partnerCount.partnerCount} partner(s).");
            }
            else
            {
                Console.WriteLine($"{partnerCount.animalShopName} has no partner(s).");
            }

            var animalKeeperHasAnimalResult = animalKeeperHasAnimal();
            if (animalKeeperHasAnimalResult.animalKeeperHasAnimal)
            {
                Console.WriteLine($"{animalKeeperHasAnimalResult.animalKeeperName} has the animal with ID {animalKeeperHasAnimalResult.animalID}.");
            }
            else
            {
                Console.WriteLine($"{animalKeeperHasAnimalResult.animalKeeperName} does not have the animal with ID {animalKeeperHasAnimalResult.animalID}.");
            }
            
            var profit = profitCalculation();
            if (profit.profit > 0)
            {
                Console.WriteLine($"{profit.animalKeeperName} has a profit of {profit.profit}Ft.");
            }
            else if (profit.profit < 0)
            {
                Console.WriteLine($"{profit.animalKeeperName} has a loss of {Math.Abs(profit.profit)}Ft.");
            }
            else
            {
                Console.WriteLine($"{profit.animalKeeperName} has no profit or loss.");
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
            NagyMancsokAllatker.Partners.Add(KissPeter.IdNumber);

            tempBill = new Bill("H123", "ABC123456", "XYZ987654", "04/01/2025", 3000);
            NagyMancsokAllatker.Bills.Add(tempBill);
            KovacsBela.Bills.Add(tempBill);
            KovacsBela.Animals.Add(tempAnimal);
            NagyMancsokAllatker.Partners.Add(KovacsBela.IdNumber);

            tempBill = new Bill("P456", "ABC123456", "QWE543210", "04/05/2025", 7000);
            Species finch = new Finch("yellow");
            tempAnimal = new Animal("P456", finch, "yellow", 3);
            NagyMancsokAllatker.Bills.Add(tempBill);
            NagyAnna.Bills.Add(tempBill);
            NagyAnna.Animals.Add(tempAnimal);
            NagyMancsokAllatker.Partners.Add(NagyAnna.IdNumber);

            tempBill = new Bill("T789", "ABC123456", "QWE543210", "04/10/2025", 10000);
            Species tarantula = new Tarantula();
            tempAnimal = new Animal("T789", tarantula, "black", 1);
            NagyMancsokAllatker.Bills.Add(tempBill);
            NagyAnna.Bills.Add(tempBill);
            NagyAnna.Animals.Add(tempAnimal);
            NagyMancsokAllatker.Partners.Add(NagyAnna.IdNumber);
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

            var animalCount = howManyAnimal("Nagy Anna", "finch");
            if (animalCount.animalCount > 0)
            {
                Console.WriteLine($"{animalCount.KeeperName} has {animalCount.animalCount} {animalCount.SpeciesName}(s).");
            }
            else
            {
                Console.WriteLine($"{animalCount.KeeperName} has no {animalCount.SpeciesName}.");
            }

            var billCount = howManyBillsHas("Nagy Anna", "Nagy Mancsok Kisállatkereskedés");
            if (billCount.billCount > 0)
            {
                Console.WriteLine($"{billCount.KeeperName} has {billCount.billCount} bills from {billCount.animalShopName}.");
            }
            else
            {
                Console.WriteLine($"{billCount.KeeperName} has no bill(s) from {billCount.animalShopName}.");
            }

            initMostExpensiveAnimal();

            var partnerCount = howManyPartnersHas("Nagy Mancsok Kisállatkereskedés");
            if (partnerCount.partnerCount > 0)
            {
                Console.WriteLine($"{partnerCount.animalShopName} has {partnerCount.partnerCount} partner(s).");
            }
            else
            {
                Console.WriteLine($"{partnerCount.animalShopName} has no partner(s).");
            }

            var animalKeeperHasAnimalResult = animalKeeperHasAnimal("Nagy Anna", "H123");
            if (animalKeeperHasAnimalResult.animalKeeperHasAnimal)
            {
                Console.WriteLine($"{animalKeeperHasAnimalResult.animalKeeperName} has the animal with ID {animalKeeperHasAnimalResult.animalID}.");
            }
            else
            {
                Console.WriteLine($"{animalKeeperHasAnimalResult.animalKeeperName} does not have the animal with ID {animalKeeperHasAnimalResult.animalID}.");
            }

            var profit = profitCalculation("Nagy Mancsok Kisállatkereskedés");
            if (profit.profit > 0)
            {
                Console.WriteLine($"{profit.animalKeeperName} has a profit of {profit.profit}Ft.");
            }
            else if (profit.profit < 0)
            {
                Console.WriteLine($"{profit.animalKeeperName} has a loss of {Math.Abs(profit.profit)}Ft.");
            }
            else
            {
                Console.WriteLine($"{profit.animalKeeperName} has no profit or loss.");
            }
        }

        //Check if the name is an Animal Shop
        static bool isAnimalShop(string name)
        {
            bool isAnimalShop = false;
            for (int i = 0; i < animalKeepers.Count(); i++)
            {
                if (animalKeepers[i].Name.ToLower() == name.ToLower())
                {
                    isAnimalShop = animalKeepers[i].Shop;
                }
            }
            return isAnimalShop;
        }

        //Animal search method
        static bool animalSearch(string animalKeeperName, string animalName, string animalColor)
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
            string? animalKeeperName = Console.ReadLine();
            if (string.IsNullOrEmpty(animalKeeperName))
            {
                Console.WriteLine("Animal Keeper name cannot be empty.");
                return haveAnimal;
            }
            Console.WriteLine("Which animal do you want to find?");
            string? animalName = Console.ReadLine();
            if (string.IsNullOrEmpty(animalName))
            {
                Console.WriteLine("Animal name cannot be empty.");
                return haveAnimal;
            }
            Console.WriteLine("What is the color of the animal?");
            string? animalColor = Console.ReadLine();
            if (string.IsNullOrEmpty(animalColor))
            {
                Console.WriteLine("Animal color cannot be empty.");
                return haveAnimal;
            }

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

        //How many animal of a given species does an animal keeper have?
        static (int animalCount, string KeeperName, string SpeciesName) howManyAnimal(string animalKeeperName, string animalName)
        {
            int animalCount = 0;
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
                    if (animalKeepers[animalKeeperIndex].Animals[i].Species.GetSpeciesName().ToLower() == animalName.ToLower())
                    {
                        animalCount++;
                    }
                }
            }
            return (animalCount, animalKeeperName, animalName);
        }
        static (int animalCount, string KeeperName, string SpeciesName) howManyAnimal()
        {
            int animalCount = 0;
            int animalKeeperIndex = -1;

            Console.WriteLine("Who you want to check?");
            string? animalKeeperName = Console.ReadLine();
            if (string.IsNullOrEmpty(animalKeeperName))
            {
                Console.WriteLine("Animal Keeper name cannot be empty.");
                return (animalCount, animalKeeperName ?? string.Empty, string.Empty);
            }
            Console.WriteLine("Which animal do you want to find?");
            string? animalName = Console.ReadLine();
            if (string.IsNullOrEmpty(animalName))
            {
                Console.WriteLine("Animal name cannot be empty.");
                return (animalCount, animalKeeperName, string.Empty);
            }

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
                    if (animalKeepers[animalKeeperIndex].Animals[i].Species.GetSpeciesName().ToLower() == animalName.ToLower())
                    {
                        animalCount++;
                    }
                }
            }
            return (animalCount, animalKeeperName, animalName);
        }

        //Have many bills do an animal keeper have from the same Animal Shop?
        static (int billCount, string KeeperName, string animalShopName) howManyBillsHas(string KeeperName, string animalShopName)
        {
            int billCount = 0;
            int animalKeeperIndex = -1;
            int animalShopIndex = -1;

            if (isAnimalShop(KeeperName))
            {
                Console.WriteLine("Animal Keeper name cannot be an Animal Shop name.");
                return (billCount, KeeperName, animalShopName);
            }
            if (!isAnimalShop(animalShopName))
            {
                Console.WriteLine("Animal Shop name cannot be an Animal Keeper name.");
                return (billCount, KeeperName, animalShopName);
            }

            for (int i = 0; i < animalKeepers.Count; i++)
            {
                if (animalKeepers[i].Name.ToLower() == KeeperName.ToLower())
                {
                    animalKeeperIndex = i;
                    continue;
                }
                if (animalKeepers[i].Name.ToLower() == animalShopName.ToLower())
                {
                    animalShopIndex = i;
                    continue;
                }
                if (animalShopIndex > -1 && animalKeeperIndex > -1)
                {
                    break;
                }
            }
            if (animalKeeperIndex == -1)
            {
                Console.WriteLine("Animal Keeper was not found in the database.");
            }
            else if (animalShopIndex == -1)
            {
                Console.WriteLine("Animal Shop was not found in the database.");
            }
            else
            {
                Debug.WriteLine("Animal Keeper found: " + animalKeepers[animalKeeperIndex].Name);
                for (int i = 0; i < animalKeepers[animalKeeperIndex].Bills.Count; i++)
                {
                    if (animalKeepers[animalKeeperIndex].Bills[i].SellerIDNumber.ToLower() == animalKeepers[animalShopIndex].IdNumber.ToLower())
                    {
                        billCount++;
                    }
                    if (animalKeepers[animalKeeperIndex].Bills[i].BuyerIDNumber.ToLower() == animalKeepers[animalShopIndex].IdNumber.ToLower())
                    {
                        billCount++;
                    }
                }
            }
            return (billCount, KeeperName, animalShopName);
        }
        static (int billCount, string KeeperName, string animalShopName) howManyBillsHas()
        {
            int billCount = 0;
            int animalKeeperIndex = -1;
            int animalShopIndex = -1;

            Console.WriteLine("Who you want to check?");
            string? KeeperName = Console.ReadLine();
            if (string.IsNullOrEmpty(KeeperName))
            {
                Console.WriteLine("Animal Keeper name cannot be empty.");
                return (billCount, KeeperName ?? string.Empty, string.Empty);
            }
            Console.WriteLine("Which Animal Shop do you want to check?");
            string? animalShopName = Console.ReadLine();
            if (string.IsNullOrEmpty(animalShopName))
            {
                Console.WriteLine("Animal Shop name cannot be empty.");
                return (billCount, KeeperName, string.Empty);
            }

            if (isAnimalShop(KeeperName))
            {
                Console.WriteLine("Animal Keeper name cannot be an Animal Shop name.");
                return (billCount, KeeperName, animalShopName);
            }
            if (!isAnimalShop(animalShopName))
            {
                Console.WriteLine("Animal Shop name cannot be an Animal Keeper name.");
                return (billCount, KeeperName, animalShopName);
            }

            for (int i = 0; i < animalKeepers.Count; i++)
            {
                if (animalKeepers[i].Name.ToLower() == KeeperName.ToLower())
                {
                    animalKeeperIndex = i;
                    continue;
                }
                if (animalKeepers[i].Name.ToLower() == animalShopName.ToLower())
                {
                    animalShopIndex = i;
                    continue;
                }
                if (animalShopIndex > -1 && animalKeeperIndex > -1)
                {
                    break;
                }
            }
            if (animalKeeperIndex == -1)
            {
                Console.WriteLine("Animal Keeper was not found in the database.");
            }
            else if (animalShopIndex == -1)
            {
                Console.WriteLine("Animal Shop was not found in the database.");
            }
            else
            {
                Debug.WriteLine("Animal Keeper found: " + animalKeepers[animalKeeperIndex].Name);
                for (int i = 0; i < animalKeepers[animalKeeperIndex].Bills.Count; i++)
                {
                    if (animalKeepers[animalKeeperIndex].Bills[i].SellerIDNumber.ToLower() == animalKeepers[animalShopIndex].IdNumber.ToLower())
                    {
                        billCount++;
                    }
                    if (animalKeepers[animalKeeperIndex].Bills[i].BuyerIDNumber.ToLower() == animalKeepers[animalShopIndex].IdNumber.ToLower())
                    {
                        billCount++;
                    }
                }
            }
            return (billCount, KeeperName, animalShopName);
        }

        static Animal findBill(Bill bill)
        {
            Animal tempAnimal = null;
            string animalID = null;
            for (int i = 0; i < animalKeepers.Count; i++)
            {
                for (int j = 0; j < animalKeepers[i].Bills.Count; j++)
                {
                    if (animalKeepers[i].Bills[j].SellerIDNumber == bill.SellerIDNumber)
                    {
                        animalID = animalKeepers[i].Bills[j].AnimalID;
                        break;
                    }
                }
            }

            for (int i = 0; i < animalKeepers.Count(); i++)
            {
                bool foundAnimal = false;
                for (int j = 0; j < animalKeepers[i].Animals.Count(); j++)
                {
                    if (animalKeepers[i].Animals[j].AnimalID == animalID)
                    {
                        tempAnimal = animalKeepers[i].Animals[j];
                        foundAnimal = true;
                        break;
                    }
                }
                if (foundAnimal)
                {
                    break;
                }
            }
            return tempAnimal;
        }
        //Which is the most expensive taratntulla?
        static void initMostExpensiveAnimal()
        {
            AnimalKeeper tempAnimalKeeper = animalKeepers[0];
            Tarantula tempAnimal = new Tarantula();
            var mostExpensiveANimalVar = tempAnimalKeeper.mostExpensiveAnimal(animalKeepers, tempAnimal);

            if (!isAnimalShop(tempAnimalKeeper.Name))
            {
                Console.WriteLine("The provided animal keeper is not an animal shop.");
            }
            else if (!mostExpensiveANimalVar.haveAnimal)
            {
                Console.WriteLine($"The selected animal shop ({tempAnimalKeeper.Name}) did not sell any " + tempAnimal.GetSpeciesName());
            }
            else
            {
                Animal animal = findBill(mostExpensiveANimalVar.bill);
                Console.WriteLine($"The most expensive {mostExpensiveANimalVar.expensiveAnimal.Species.GetSpeciesName()} was sold at {mostExpensiveANimalVar.bill.Price} price from {tempAnimalKeeper.Name}.");
            }
        }

        //Have many partners does an Animal Shop have?
        static (int partnerCount, string animalShopName) howManyPartnersHas(string animalShopName)
        {
            int partnerCount = 0;
            int animalKeeperIndex = -1;

            if (!isAnimalShop(animalShopName))
            {
                Console.WriteLine("Animal Shop name cannot be an Animal Keeper name.");
                return (partnerCount, animalShopName);
            }

            for (int i = 0; i < animalKeepers.Count; i++)
            {
                if (animalKeepers[i].Name.ToLower() == animalShopName.ToLower())
                {
                    animalKeeperIndex = i;
                    break;
                }
            }
            if (animalKeeperIndex == -1)
            {
                Console.WriteLine("Animal Shop was not found in the database.");
            }
            else
            {
                Debug.WriteLine("Animal Shop found: " + animalKeepers[animalKeeperIndex].Name);
                partnerCount = animalKeepers[animalKeeperIndex].Partners.Count;
            }
            return (partnerCount, animalShopName);
        }
        static (int partnerCount, string animalShopName) howManyPartnersHas()
        {
            int partnerCount = 0;
            int animalKeeperIndex = -1;
            Console.WriteLine("Which Animal Shop do you want to check?");
            string? animalShopName = Console.ReadLine();
            if (string.IsNullOrEmpty(animalShopName))
            {
                Console.WriteLine("Animal Shop name cannot be empty.");
                return (partnerCount, animalShopName ?? string.Empty);
            }
            if (!isAnimalShop(animalShopName))
            {
                Console.WriteLine("Animal Shop name cannot be an Animal Keeper name.");
                return (partnerCount, animalShopName);
            }
            for (int i = 0; i < animalKeepers.Count; i++)
            {
                if (animalKeepers[i].Name.ToLower() == animalShopName.ToLower())
                {
                    animalKeeperIndex = i;
                    break;
                }
            }
            if (animalKeeperIndex == -1)
            {
                Console.WriteLine("Animal Shop was not found in the database.");
            }
            else
            {
                Debug.WriteLine("Animal Shop found: " + animalKeepers[animalKeeperIndex].Name);
                partnerCount = animalKeepers[animalKeeperIndex].Partners.Count;
            }
            return (partnerCount, animalShopName);
        }

        //Does an Animal Keeper have a specific Animal?
        static (string animalKeeperName, string animalID, bool animalKeeperHasAnimal) animalKeeperHasAnimal(string animalKeeperName, string animalID)
        {
            bool animalKeeperHasAnimal = false;
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
                    if (animalKeepers[animalKeeperIndex].Animals[i].AnimalID.ToLower() == animalID.ToLower())
                    {
                        animalKeeperHasAnimal = true;
                        break;
                    }
                }
            }
            return (animalKeeperName, animalID, animalKeeperHasAnimal);
        }
        static (string animalKeeperName, string animalID, bool animalKeeperHasAnimal) animalKeeperHasAnimal()
        {
            bool animalKeeperHasAnimal = false;
            int animalKeeperIndex = -1;
            Console.WriteLine("Who you want to check?");
            string? animalKeeperName = Console.ReadLine();
            if (string.IsNullOrEmpty(animalKeeperName))
            {
                Console.WriteLine("Animal Keeper name cannot be empty.");
                return (animalKeeperName ?? string.Empty, string.Empty, animalKeeperHasAnimal);
            }
            Console.WriteLine("What is the ID of the animal?");
            string? animalID = Console.ReadLine();
            if (string.IsNullOrEmpty(animalID))
            {
                Console.WriteLine("Animal ID cannot be empty.");
                return (animalKeeperName, animalID ?? string.Empty, animalKeeperHasAnimal);
            }
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
                    if (animalKeepers[animalKeeperIndex].Animals[i].AnimalID.ToLower() == animalID.ToLower())
                    {
                        animalKeeperHasAnimal = true;
                        break;
                    }
                }
            }
            return (animalKeeperName, animalID, animalKeeperHasAnimal);
        }

        //Profit calculation
        static (string animalKeeperName, int profit) profitCalculation(string  animalKeeperName)
        {
            int profit = 0;

            if (isAnimalShop(animalKeeperName))
            {
                int animalKeeperIndex = -1;
                for (int i = 0; i < animalKeepers.Count(); i++)
                {
                    if (animalKeepers[i].Name == animalKeeperName)
                    {
                        animalKeeperIndex = i;
                        break;
                    }
                }
                if (animalKeeperIndex == -1)
                {
                    Console.WriteLine("The Animal Shop is not found.");
                    return (animalKeeperName, profit);
                }

                Debug.WriteLine("Animal Shop found: " + animalKeepers[animalKeeperIndex].Name);

                for (int i = 0; i < animalKeepers[animalKeeperIndex].Bills.Count(); i++)
                {
                    if (animalKeepers[animalKeeperIndex].Bills[i].SellerIDNumber == animalKeepers[animalKeeperIndex].IdNumber)
                    {
                        profit += animalKeepers[animalKeeperIndex].Bills[i].Price;
                    }
                    else
                    {
                        profit -= animalKeepers[animalKeeperIndex].Bills[i].Price;
                    }
                }

            } else
            {
                Console.WriteLine("Animal Shop name cannot be an Animal Keeper name.");
                return (animalKeeperName, profit);
            }
            return (animalKeeperName, profit);
        }
        static (string animalKeeperName, int profit) profitCalculation()
        {
            int profit = 0;
            Console.WriteLine("Which Animal Shop do you want to check?");
            string? animalKeeperName = Console.ReadLine();
            if (string.IsNullOrEmpty(animalKeeperName))
            {
                Console.WriteLine("Animal Shop name cannot be empty.");
                return (animalKeeperName ?? string.Empty, profit);
            }
            if (isAnimalShop(animalKeeperName))
            {
                int animalKeeperIndex = -1;
                for (int i = 0; i < animalKeepers.Count(); i++)
                {
                    if (animalKeepers[i].Name == animalKeeperName)
                    {
                        animalKeeperIndex = i;
                        break;
                    }
                }
                if (animalKeeperIndex == -1)
                {
                    Console.WriteLine("The Animal Shop is not found.");
                    return (animalKeeperName, profit);
                }
                Debug.WriteLine("Animal Shop found: " + animalKeepers[animalKeeperIndex].Name);
                for (int i = 0; i < animalKeepers[animalKeeperIndex].Bills.Count(); i++)
                {
                    if (animalKeepers[animalKeeperIndex].Bills[i].SellerIDNumber == animalKeepers[animalKeeperIndex].IdNumber)
                    {
                        profit += animalKeepers[animalKeeperIndex].Bills[i].Price;
                    }
                    else
                    {
                        profit -= animalKeepers[animalKeeperIndex].Bills[i].Price;
                    }
                }
            }
            else
            {
                Console.WriteLine("Animal Shop name cannot be an Animal Keeper name.");
                return (animalKeeperName, profit);
            }
            return (animalKeeperName, profit);
        }
    }
}
