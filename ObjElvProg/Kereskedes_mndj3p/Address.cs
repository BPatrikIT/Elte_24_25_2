using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kereskedes_mndj3p
{
    internal class Address
    {
        string country;
        string city;
        string street;
        int houseNumber;
        int floor;
        int door;
        int postalCode;

        public Address(string country, string city, string street, int houseNumber, int floor, int door, int postalCode)
        {
            this.country = country;
            this.city = city;
            this.street = street;
            this.houseNumber = houseNumber;
            this.floor = floor;
            this.door = door;
            this.postalCode = postalCode;
        }

        public Address(string country, string city, string street, int houseNumber, int postalCode)
        {
            this.country = country;
            this.city = city;
            this.street = street;
            this.houseNumber = houseNumber;
            this.postalCode = postalCode;
        }
    }
}
