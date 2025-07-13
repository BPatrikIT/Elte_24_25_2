using System.Collections.Generic;

namespace PetShop
{
    public class PetKeeper
    {
        public string Name { get; }
        public string Address { get; }
        public string ID { get; }
        public List<Pet> OwnedPets { get; }
        public List<Bill> Bills { get; }

        public PetKeeper(string name, string address, string id)
        {
            Name = name;
            Address = address;
            ID = id;
            OwnedPets = new List<Pet>();
            Bills = new List<Bill>();
        }
    }
}
