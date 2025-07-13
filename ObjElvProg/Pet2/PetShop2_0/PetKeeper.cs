using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop2_0
{
    public class PetKeeper
    {
        public string Name { get; set; }
        public string IdNumber { get; set; }
        public string Address { get; set; }
        public List<Pet> OwnedPets { get; set; } = new List<Pet>();
        public List<Bill> Bills { get; set; } = new List<Bill>();

        public bool OwnsPet(Pet pet)
        {
            return OwnedPets.Contains(pet);
        }

        public bool OwnsPetByID(string petID)
        {
            return OwnedPets.Any(p => p.PetID == petID);
        }

        public int CountBillsFrom(PetKeeper partner)
        {
            return Bills.Count(b => b.Seller == partner || b.Buyer == partner);
        }

        public bool HasSpecificPet(Color color, Type petType)
        {
            return OwnedPets.Any(p => p.Color == color && p.GetType() == petType);
        }

        public int CountPetsOfType(Type petType)
        {
            return OwnedPets.Count(p => p.GetType() == petType);
        }

        public List<Bill> GetAllTransactionsWith(PetKeeper partner)
        {
            return Bills.Where(b => b.Seller == partner || b.Buyer == partner).ToList();
        }
    }
}
