using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop2_0
{
    public class PetShop : PetKeeper
    {
        public List<PetKeeper> Partners { get; set; } = new List<PetKeeper>();

        public Pet GetMostExpensiveSoldPetOfType(Type petType)
        {
            var bill = Bills
                .Where(b => b.Pet.GetType() == petType && b.Seller == this)
                .OrderByDescending(b => b.Price)
                .FirstOrDefault();

            return bill?.Pet;
        }

        public int GetPartnerCount()
        {
            return Partners.Count;
        }

        public List<Bill> GetBillsInPeriod(DateTime start, DateTime end)
        {
            return Bills.Where(b => b.Date >= start && b.Date <= end).ToList();
        }

        public int CalculateProfit(DateTime start, DateTime end)
        {
            int income = Bills.Where(b => b.Seller == this && b.Date >= start && b.Date <= end)
                              .Sum(b => b.Price);

            int expense = Bills.Where(b => b.Buyer == this && b.Date >= start && b.Date <= end)
                               .Sum(b => b.Price);

            return income - expense;
        }
    }
}
