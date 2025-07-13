using System;

namespace PetShop
{
    public enum Color { Brown, Yellow, Black }

    public abstract class Pet
    {
        public string PetID { get; }
        public Color Color { get; }
        public int Age { get; }
        public int Value { get; }

        public Pet(string petID, Color color, int age, int value)
        {
            PetID = petID;
            Color = color;
            Age = age;
            Value = value;
        }
    }
}
