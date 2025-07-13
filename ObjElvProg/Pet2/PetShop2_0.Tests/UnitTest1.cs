using Xunit;
using PetShop2_0;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class PetShopQueryTests : IDisposable
{
    private PetShop _shop;
    private List<PetKeeper> _partners;
    private List<Pet> _pets;
    private List<Bill> _bills;

    public class DataLoader
    {
        public static void LoadData(string filePath,
            out PetShop petShop,
            out List<PetKeeper> partners,
            out List<Pet> pets,
            out List<Bill> bills)
        {
            petShop = null;
            partners = new List<PetKeeper>();
            pets = new List<Pet>();
            bills = new List<Bill>();

            var petDict = new Dictionary<string, Pet>();
            var keeperDict = new Dictionary<string, PetKeeper>();

            string[] lines = File.ReadAllLines(filePath);
            foreach (string rawLine in lines)
            {
                string line = rawLine.Trim();
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                if (line.StartsWith("PetShop:"))
                {
                    var parts = line.Substring(8).Split(",");
                    petShop = new PetShop
                    {
                        Name = parts[0].Trim(),
                        Address = parts[1].Trim(),
                        IdNumber = parts[2].Trim(),
                        OwnedPets = new List<Pet>(),   // kezdetben üres lista
                        Partners = new List<PetKeeper>() // üres lista
                    };
                    keeperDict[petShop.IdNumber] = petShop;
                }
                else if (line.StartsWith("Partner:"))
                {
                    var parts = line.Substring(8).Split(",");
                    var partner = new PetKeeper
                    {
                        Name = parts[0].Trim(),
                        Address = parts[1].Trim(),
                        IdNumber = parts[2].Trim(),
                        OwnedPets = new List<Pet>(),
                        Bills = new List<Bill>()
                    };
                    partners.Add(partner);
                    keeperDict[partner.IdNumber] = partner;

                    petShop?.Partners.Add(partner);
                }
                else if (line.StartsWith("Pet:"))
                {
                    var parts = line.Substring(4).Split(",");
                    string type = parts[0].Trim();
                    string id = parts[1].Trim();
                    string colorName = parts[2].Trim();
                    int age = int.Parse(parts[3]);
                    int value = int.Parse(parts[4]);

                    Color color = new Color(GetStrategyFromName(colorName));

                    Pet pet = type switch
                    {
                        "Hamster" => new Hamster(id, color, age, value),
                        "Finch" => new Finch(id, color, age, value),
                        "Tarantula" => new Tarantula(id, color, age, value),
                        _ => throw new Exception("Unknown pet type")
                    };

                    pets.Add(pet);
                    petDict[id] = pet;

                    // PetShop kezdetben birtokolja az összes állatot
                    petShop?.OwnedPets.Add(pet);
                }
                else if (line.StartsWith("Bill:"))
                {
                    var parts = line.Substring(5).Split(",");
                    var participants = parts[0].Split("->");
                    var sellerId = participants[0].Trim();
                    var buyerId = participants[1].Trim();
                    string petID = parts[1].Trim();
                    DateTime date = DateTime.Parse(parts[2].Trim(), CultureInfo.InvariantCulture);
                    int price = int.Parse(parts[3].Trim());

                    var seller = keeperDict[sellerId];
                    var buyer = keeperDict[buyerId];
                    var pet = petDict[petID];

                    var bill = new Bill
                    {
                        Seller = seller,
                        Buyer = buyer,
                        Pet = pet,
                        Date = date,
                        Price = price
                    };

                    bills.Add(bill);
                    bill.TransferOwnership();
                }
            }
        }
        private static IMultiplierStrategy GetStrategyFromName(string name) => name switch
        {
            "Red" => new RedMultiplier(),
            "Blue" => new BlueMultiplier(),
            "Green" => new GreenMultiplier(),
            "Yellow" => new YellowMultiplier(),
            _ => throw new ArgumentException($"Unknown color: {name}")
        };
    }

    public PetShopQueryTests()
    {
        string path = "testData.csv";
        DataLoader.LoadData(path, out _shop, out _partners, out _pets, out _bills);
    }

    public void Dispose() { }

    [Fact]
    public void TestHasYellowFinch()
    {
        var keeper = _partners.First(p => p.Name == "Szabó Anna");

        bool hasYellowFinch = keeper.HasSpecificPet(new Color(new YellowMultiplier()), typeof(Finch));

        Assert.False(hasYellowFinch);
    }

    [Fact]
    public void TestHamsterCount()
    {
        var keeper = _partners.FirstOrDefault(p => p.Name == "Tóth Eszter");
        int count = keeper?.CountPetsOfType(typeof(Hamster)) ?? 0;

        Assert.Equal(0, count);
    }

    [Fact]
    public void TestBillCountFromShop()
    {
        var keeper = _partners.First(p => p.Name == "Nagy László");
        int billCount = keeper.CountBillsFrom(_shop);

        Assert.Equal(1, billCount);
    }

    [Fact]
    public void TestMostValuableTarantula()
    {
        var mostValuablePet = _shop.GetMostExpensiveSoldPetOfType(typeof(Tarantula));

        Assert.NotNull(mostValuablePet);
        Assert.Equal("T002", mostValuablePet.PetID);
    }

    [Fact]
    public void TestPartnerCount()
    {
        int count = _shop.GetPartnerCount();
        Assert.Equal(10, count);
    }

    [Fact]
    public void TestOwnerHasPet()
    {
        var keeper = _partners.First(p => p.Name == "Balogh Zoltán");
        var pet = _pets.First(p => p.PetID == "H003");

        bool owns = keeper.HasSpecificPet(pet.Color, pet.GetType());

        Assert.True(owns);
    }

    [Fact]
    public void TestProfit()
    {
        DateTime from = new DateTime(2024, 5, 1);
        DateTime to = new DateTime(2024, 5, 10);

        int profit = _shop.CalculateProfit(from, to);

        Assert.Equal(1710, profit);
    }
}
