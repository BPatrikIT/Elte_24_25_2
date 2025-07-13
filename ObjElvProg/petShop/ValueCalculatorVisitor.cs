public class ValueCalculatorVisitor : IVisitor
{
    public double Visit(Hamster h) => h.ideologicalValue * h.color.GetMultiplier();

    public double Visit(Finch f) => f.ideologicalValue * f.color.GetMultiplier();

    public double Visit(Tarantula t) => t.ideologicalValue;
}