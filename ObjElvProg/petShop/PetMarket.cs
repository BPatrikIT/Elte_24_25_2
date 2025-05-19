public class PetMarket : PetKeeper
{
    public HashSet<PetKeeper> Partners { get; } = new();

    public PetMarket(string name, string address, string idNumber) : base(name, address, idNumber) { }

    public Pet? GetMostValuablePetOfType(Type petType) =>
        OwnedPets.Where(p => p.GetType() == petType)
                 .OrderByDescending(p => p.Accept(new ValueCalculatorVisitor()))
                 .FirstOrDefault();

    public int GetPartnerCount() => Partners.Count;

    public List<Bill> GetBillsInPeriod(DateTime start, DateTime end) =>
        Bills.Where(b => b.Date >= start && b.Date <= end).ToList();

    public int CalculateProfit(DateTime start, DateTime end)
    {
        int income = Bills
            .Where(b => b.Seller == this && b.Date >= start && b.Date <= end)
            .Sum(b => b.Price);

        int expense = Bills
            .Where(b => b.Buyer == this && b.Date >= start && b.Date <= end)
            .Sum(b => b.Price);

        return income - expense;
    }
}
