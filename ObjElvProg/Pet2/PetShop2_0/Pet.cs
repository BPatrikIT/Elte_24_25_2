using System;

namespace PetShop2_0
{
    public abstract class Pet
    {
        public string PetID { get; set; }
        public Color Color { get; set; }
        public int Age { get; set; }
        public int IdeologicalValue { get; set; }

        protected Pet(string petID, Color color, int age, int ideologicalValue)
        {
            PetID = petID;
            Color = color;
            Age = age;
            IdeologicalValue = ideologicalValue;
        }

        public abstract double Accept(IVisitor visitor);

        public int GetIdeologicalValue()
        {
            return IdeologicalValue;
        }

        public Color GetColor()
        {
            return Color;
        }
    }

    public class Hamster : Pet
    {
        public Hamster(string petID, Color color, int age, int ideologicalValue)
            : base(petID, color, age, ideologicalValue) { }

        public override double Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class Finch : Pet
    {
        public Finch(string petID, Color color, int age, int ideologicalValue)
            : base(petID, color, age, ideologicalValue) { }

        public override double Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class Tarantula : Pet
    {
        public Tarantula(string petID, Color color, int age, int ideologicalValue)
            : base(petID, color, age, ideologicalValue) { }

        public override double Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
