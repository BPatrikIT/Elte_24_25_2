using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop2_0
{
    public class Color
    {
        private IMultiplierStrategy strategy;

        public Color(IMultiplierStrategy strategy)
        {
            this.strategy = strategy;
        }

        public double GetMultiplier()
        {
            return strategy.GetMultiplier();
        }
    }
}
