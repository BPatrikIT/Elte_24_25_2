using System;

namespace PetShop2_0
{
    public interface IMultiplierStrategy
    {
        double GetMultiplier();
    }

    public class RedMultiplier : IMultiplierStrategy
    {
        public double GetMultiplier() => 1.2;

        public override bool Equals(object obj) => obj is RedMultiplier;

        public override int GetHashCode() => typeof(RedMultiplier).GetHashCode();
    }

    public class BlueMultiplier : IMultiplierStrategy
    {
        public double GetMultiplier() => 1.5;

        public override bool Equals(object obj) => obj is BlueMultiplier;

        public override int GetHashCode() => typeof(BlueMultiplier).GetHashCode();
    }

    public class GreenMultiplier : IMultiplierStrategy
    {
        public double GetMultiplier() => 1.0;

        public override bool Equals(object obj) => obj is GreenMultiplier;

        public override int GetHashCode() => typeof(GreenMultiplier).GetHashCode();
    }

    public class YellowMultiplier : IMultiplierStrategy
    {
        public double GetMultiplier() => 1.2;

        public override bool Equals(object obj) => obj is YellowMultiplier;

        public override int GetHashCode() => typeof(YellowMultiplier).GetHashCode();
    }
}
