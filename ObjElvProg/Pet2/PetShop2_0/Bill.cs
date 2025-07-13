using System;

namespace PetShop2_0
{
    public class Bill
    {
        public PetKeeper Seller { get; set; }
        public PetKeeper Buyer { get; set; }
        public Pet Pet { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }

        public void TransferOwnership()
        {
            Buyer.OwnedPets.Add(Pet);
            Seller.OwnedPets.Remove(Pet);

            Buyer.Bills.Add(this);
            Seller.Bills.Add(this);
        }
    }
}
