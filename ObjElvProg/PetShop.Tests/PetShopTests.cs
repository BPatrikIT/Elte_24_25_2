using Xunit;
using PetShop;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class PetShopQueryTests : IDisposable
{
    private PetMarket _shop;
    private List<PetKeeper> _partners;
    private List<Pet> _pets;
    private List<Bill> _bills;

    public class DataLoader
    {
        //Test Data Structure

        /*
        PetShop: Kisállat Mennyország, Váci út 1., PS001
        Partner: Kovács János, Kossuth u. 10., ID123
        Partner: Szabó Anna, Petőfi S. u. 22., ID124
        Pet: Hamster, H001, Brown, 2, 100
        Pet: Finch, F002, Yellow, 1, 200
        Pet: Tarantula, T003, Black, 4, 500
        Bill: Kisállat Mennyország -> Kovács János, H001, 2024-05-01, 120
        Bill: Kovács János -> Szabó Anna, H001, 2024-05-10, 130
        */
        public static void LoadData(string filePath,
            out PetMarket petShop,
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
                    petShop = new PetMarket(parts[0].Trim(), parts[1].Trim(), parts[2].Trim());
                    keeperDict[petShop.Name] = petShop;
                }
                else if (line.StartsWith("Partner:"))
                {
                    var parts = line.Substring(8).Split(",");
                    var partner = new PetKeeper(parts[0].Trim(), parts[1].Trim(), parts[2].Trim());
                    partners.Add(partner);
                    keeperDict[partner.Name] = partner;

                    petShop?.Partners.Add(partner);
                }

                else if (line.StartsWith("Pet:"))
                {
                    var parts = line.Substring(4).Split(",");
                    string type = parts[0].Trim();
                    string id = parts[1].Trim();
                    string colorStr = parts[2].Trim();
                    int age = int.Parse(parts[3]);
                    int value = int.Parse(parts[4]);

                    Color color = Enum.Parse<Color>(colorStr);
                    Pet pet = type switch
                    {
                        "Hamster" => new Hamster(id, color, age, value),
                        "Finch" => new Finch(id, color, age, value),
                        "Tarantula" => new Tarantula(id, color, age, value),
                        _ => throw new Exception("Unknown pet type")
                    };
                    pets.Add(pet);
                    petDict[id] = pet;
                }
                else if (line.StartsWith("Bill:"))
                {
                    var parts = line.Substring(5).Split(",");
                    var participants = parts[0].Split("->");
                    var sellerName = participants[0].Trim();
                    var buyerName = participants[1].Trim();
                    string petID = parts[1].Trim();
                    DateTime date = DateTime.Parse(parts[2].Trim(), CultureInfo.InvariantCulture);
                    int price = int.Parse(parts[3].Trim());

                    var seller = keeperDict[sellerName];
                    var buyer = keeperDict[buyerName];
                    var pet = petDict[petID];

                    var bill = new Bill(seller, buyer, pet, date, price);
                    bills.Add(bill);

                    seller.Bills.Add(bill);
                    buyer.Bills.Add(bill);
                    buyer.OwnedPets.Add(pet);
                    seller.OwnedPets.Remove(pet);
                }
            }
        }
    }

    public PetShopQueryTests()
    {
        string path = "testData.csv";
        DataLoader.LoadData(path, out _shop, out _partners, out _pets, out _bills);
    }

    public void Dispose()
    {
    }

    [Fact]
    public void TestHasYellowFinch()
    {
        var keeper = _partners.First(p => p.Name == "Szabó Anna");
        bool hasYellowFinch = keeper.OwnedPets.OfType<Finch>().Any(f => f.Color == Color.Yellow);
        Assert.False(hasYellowFinch);
    }

    [Fact]
    public void TestHamsterCount()
    {
        var keeper = _partners.First(p => p.Name == "Tóth Eszter");
        int count = keeper.OwnedPets.OfType<Hamster>().Count();
        Assert.Equal(0, count);
    }

    [Fact]
    public void TestBillCountFromShop()
    {
        var keeper = _partners.First(p => p.Name == "Nagy László");
        int billCount = keeper.Bills.Count(b => b.Seller == _shop);
        Assert.Equal(1, billCount);
    }

    [Fact]
    public void TestMostExpensiveTarantulaSale()
    {
        var mostExpensiveBill = _bills
            .Where(b => b.Pet is Tarantula && b.Seller == _shop)
            .MaxBy(b => b.Price);

        Assert.Equal("T002", mostExpensiveBill?.Pet.PetID);
        Assert.Equal(360, mostExpensiveBill?.Price);
    }

    [Fact]
    public void TestPartnerCount()
    {
        int count = _shop.Partners.Count;
        Assert.Equal(10, count);
    }

    [Fact]
    public void TestOwnerHasPet()
    {
        var keeper = _partners.First(p => p.Name == "Balogh Zoltán");
        var pet = _pets.First(p => p.PetID == "H003");
        bool owns = keeper.OwnedPets.Contains(pet);
        Assert.True(owns);
    }

    [Fact]
    public void TestProfit()
    {
        DateTime from = new DateTime(2024, 5, 1);
        DateTime to = new DateTime(2024, 5, 10);

        int income = _shop.Bills
            .Where(b => b.Date >= from && b.Date <= to && b.Seller == _shop)
            .Sum(b => b.Price);

        int cost = _shop.Bills
            .Where(b => b.Date >= from && b.Date <= to && b.Buyer == _shop)
            .Sum(b => b.Price);

        int profit = income - cost;
        Assert.Equal(1710, profit);
    }
}
