namespace PetShop2_0
{
    public class ValueCalculatorVisitor : IVisitor
    {
        public double Visit(Hamster h)
        {
            return h.IdeologicalValue * h.Color.GetMultiplier();
        }

        public double Visit(Finch f)
        {
            return f.IdeologicalValue * f.Color.GetMultiplier();
        }

        public double Visit(Tarantula t)
        {
            return t.IdeologicalValue;
        }
    }
}
