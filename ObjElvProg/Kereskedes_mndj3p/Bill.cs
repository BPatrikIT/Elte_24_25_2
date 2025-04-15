using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kereskedes_mndj3p
{
    internal class Bill
    {
        private string animalID;
        private string sellerIDNumber;
        private string buyerIDNumber;
        private DateTime dateTime;
        private int price;

        public Bill(string animalID, string sellerIDNumber, string buyerIDNumber, string date, int price)
        {
            this.animalID = animalID;
            this.sellerIDNumber = sellerIDNumber;
            this.buyerIDNumber = buyerIDNumber;
            this.dateTime = DateTime.Parse(date);
            this.price = price;
        }
    }
}
