public class PetKeeper {
    public string Name { get; }
    public string Address { get; }
    public string IdNumber { get; }
    public List<Bill> Bills { get; } = new();
    public List<Pet> OwnedPets { get; } = new();

    public PetKeeper(string name, string address, string idNumber) {
        Name = name;
        Address = address;
        IdNumber = idNumber;
    }

    public bool HasSpecificPet(Color color, Type petType) =>
        OwnedPets.Any(p => p.Color == color && p.GetType() == petType);

    public int CountPetsOfType(Type petType) =>
        OwnedPets.Count(p => p.GetType() == petType);

    public int CountBillsFrom(PetKeeper partner) =>
        Bills.Count(b => b.Seller == partner || b.Buyer == partner);

    public bool OwnsPet(Pet pet) => OwnedPets.Contains(pet);

    public bool OwnsPetByID(string petID) =>
        OwnedPets.Any(p => p.PetID == petID);

    public List<Bill> GetAllTransactionsWith(PetKeeper partner) =>
        Bills.Where(b => b.Seller == partner || b.Buyer == partner).ToList();
}