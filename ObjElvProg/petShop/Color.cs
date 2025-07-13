public class Color
{
    private IMultiplierStrategy strategy;

    public Color(IMultiplierStrategy strategy)
    {
        this.strategy = strategy;
    }

    public double GetMultiplier() => strategy.GetMultiplier();
}