namespace petShop
{
    class PetKeeper
    {
        protected string name;
        protected Address address;
        protected string idNumber;
        protected List<Bill> bills;

        public PetKeeper(string name, Address address, string idNumber)
        {
            this.name = name;
            this.address = address;
            this.idNumber = idNumber;
            this.bills = new List<Bill>();
        }
    }

    class PetShop : PetKeeper
    {
        protected List<string> partners;
        public PetShop(string name, Address address, string idNumber) : base(name, address, idNumber)
        {
            this.partners = new List<string>();
        }
    }
}
