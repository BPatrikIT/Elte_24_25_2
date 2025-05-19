public class ValueCalculatorVisitor : IVisitor {
    public double Visit(Hamster h) => h.IdeologicalValue * h.Color.GetMultiplier();
    public double Visit(Finch f) => f.IdeologicalValue * f.Color.GetMultiplier();
    public double Visit(Tarantula t) => t.IdeologicalValue;
}