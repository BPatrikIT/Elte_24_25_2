using System;

namespace PetShop
{
    public class Hamster : Pet
    {
        public Hamster(string petID, Color color, int age, int value)
            : base(petID, color, age, value) { }
    }
}
