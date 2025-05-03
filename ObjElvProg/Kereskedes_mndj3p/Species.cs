using System;

namespace Kereskedes_mndj3p
{
    internal abstract class Species
    {
        private readonly string _name;

        // Added a backing field for color
        private readonly string _color;

        // Constructor to initialize color and name
        protected Species(string color, string name)
        {
            _color = color;
            _name = name;
        }

        // Property to expose color
        public string Color => _color;

        // Changed ideologicalValue to a property
        public abstract int IdeologicalValue { get; }

        // Abstract method for realValue calculation
        public abstract int CalculateRealValue();

        // Added a method to get the name of the species
        public string GetSpeciesName()
        {
            // Changed to use the protected property instead of the private field
            return base.GetType().Name;
        }
    }

    internal class Hamster : Species
    {
        // Constructor to pass color and name to base class
        public Hamster(string color) : base(color, "Hamster") { }

        // Correctly implemented the property
        public override int IdeologicalValue => 4000;

        public override int CalculateRealValue()
        {
            switch (Color.ToLower())
            {
                case "white":
                    return 1 * IdeologicalValue;
                case "black":
                    return 2 * IdeologicalValue;
                case "brown":
                    return 3 * IdeologicalValue;
                case "yellow":
                    return 4 * IdeologicalValue;
                default:
                    return 0; // Default case if color doesn't match
            }
        }

    }

    internal class Finch : Species
    {
        // Constructor to pass color and name to base class
        public Finch(string color) : base(color, "Finch") { }

        // Correctly implemented the property
        public override int IdeologicalValue => 2000;

        public override int CalculateRealValue()
        {
            switch (Color.ToLower())
            {
                case "white":
                    return 1 * IdeologicalValue;
                case "black":
                    return 2 * IdeologicalValue;
                case "brown":
                    return 3 * IdeologicalValue;
                case "yellow":
                    return 4 * IdeologicalValue;
                default:
                    return 0; // Default case if color doesn't match
            }
        }
    }

    internal class Tarantula : Species
    {
        // Constructor to pass color and name to base class
        public Tarantula() : base("black", "Tarantula") { }

        // Correctly implemented the property
        public override int IdeologicalValue => 8000;

        public override int CalculateRealValue()
        {
            return IdeologicalValue;
        }
    }
}
