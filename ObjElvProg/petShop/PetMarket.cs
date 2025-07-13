using System.Collections.Generic;

namespace PetShop
{
    public class PetMarket : PetKeeper
    {
        public List<PetKeeper> Partners { get; }

        public PetMarket(string name, string address, string id)
            : base(name, address, id)
        {
            Partners = new List<PetKeeper>();
        }
    }
}
