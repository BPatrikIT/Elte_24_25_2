namespace petShop
{
    class Bill
    {
        protected string billNumber;
        protected string petId;
        protected string petType;
        protected string sellerId;
        protected string buyerId;
        protected DateTime date;
        protected int price;

        public Bill(string billNumber, string petId, string petType, string sellerId, string buyerId, DateTime date, int price)
        {
            this.billNumber = billNumber;
            this.petId = petId;
            this.petType = petType;
            this.sellerId = sellerId;
            this.buyerId = buyerId;
            this.date = date;
            this.price = price;
        }
    }
}
