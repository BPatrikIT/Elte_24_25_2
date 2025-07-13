public interface IMultiplierStrategy
{
    double GetMultiplier();
}

public class YellowMultiplier : IMultiplierStrategy
{
    public double GetMultiplier() => 1.5;
}

public class WhiteMultiplier : IMultiplierStrategy
{
    public double GetMultiplier() => 1.2;
}

public class BlackMultiplier : IMultiplierStrategy
{
    public double GetMultiplier() => 1.0;
}

public class BrownMultiplier : IMultiplierStrategy
{
    public double GetMultiplier() => 0.8;
}