using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petShop
{
    internal class Address
    {
        private string country;
        private int streetNumber;
        private string street;
        private int floor;
        private int doorNumber;
        private string city;
        private string zipCode;

        public Address(int streetNumber, string street, string city, string zipCode, int floor = 0, int doorNumber = 0, string country = "")
        {
            this.country = country;
            this.streetNumber = streetNumber;
            this.street = street;
            this.floor = floor;
            this.doorNumber = doorNumber;
            this.city = city;
            this.zipCode = zipCode;
        }

        public override string ToString()
        {
            string address = $"{streetNumber} {street}, {city}, {zipCode}";
            if (doorNumber == 0)
            {
                if (!string.IsNullOrEmpty(country))
                {
                    address += $", Country: {country}";
                }
            }
            else
            {
                address += $", Floor: {floor}, Door: {doorNumber}, Country: {country}";
            }      
            return address;
        }
    }
}
