public class Bill {
    public PetKeeper Seller { get; }
    public PetKeeper Buyer { get; }
    public Pet Pet { get; }
    public DateTime Date { get; }
    public int Price { get; }

    public Bill(PetKeeper seller, PetKeeper buyer, Pet pet, DateTime date, int price) {
        Seller = seller;
        Buyer = buyer;
        Pet = pet;
        Date = date;
        Price = price;
    }

    public void TransferOwnership() {
        Seller.OwnedPets.Remove(Pet);
        Buyer.OwnedPets.Add(Pet);
        Seller.Bills.Add(this);
        Buyer.Bills.Add(this);
    }
}