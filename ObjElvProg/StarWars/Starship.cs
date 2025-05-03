// Starship.cs

namespace HF9
{
    class Starship
    {
        protected string name;
        protected int shield;
        protected int armor;
        protected int guardian;
        protected Planet? planet;

        public Starship(string name, int shield, int armor, int guardian)
        {
            this.name = name;
            this.shield = shield;
            this.armor = armor;
            this.guardian = guardian;
            this.planet = null;
        }

        public int GetShield()
        {
            return shield;
        }

        public void StaysAtPlanet(Planet p)
        {
            if (planet != null)
            {
                planet.Leaves(this);
            }
            planet = p;
            planet.Defends(this);
        }

        public void LeavesPlanet()
        {
            if (planet == null)
                throw new Exception("No planet to leave");
            planet.Leaves(this);
            planet = null;
        }

        public virtual double FireP()
        {
            return 0.0;
        }
    }
}