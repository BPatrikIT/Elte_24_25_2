public abstract class Pet {
    public string PetID { get; }
    public Color Color { get; }
    public int Age { get; }
    public int IdeologicalValue { get; }

    public Pet(string petID, Color color, int age, int ideologicalValue) {
        PetID = petID;
        Color = color;
        Age = age;
        IdeologicalValue = ideologicalValue;
    }

    public abstract double Accept(IVisitor visitor);

    public PetKeeper GetCurrentOwner(List<Bill> bills) =>
        bills.Where(b => b.Pet == this)
             .OrderByDescending(b => b.Date)
             .Select(b => b.Buyer)
             .FirstOrDefault() ?? throw new InvalidOperationException("No current owner found for this pet.");
}