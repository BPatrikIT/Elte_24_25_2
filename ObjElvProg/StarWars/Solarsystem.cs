namespace HF9
{
    class Solarsystem
    {
        public List<Planet> planets;

        public Solarsystem()
        {
            planets = new List<Planet>();
        }

        public List<Planet> Defenseless()
        {
            List<Planet> defenseless = new List<Planet>();
            foreach (var planet in planets)
            {
                if (planet.ShipCount() == 0)
                    defenseless.Add(planet);
            }
            return defenseless;
        }

        public (bool, Starship) MaxFireP()
        {
            Starship maxShip = null;
            double maxFire = -1;
            foreach (var planet in planets)
            {
                (bool exists, double fireP, Starship ship) = planet.MaxFireP();
                if (exists && fireP > maxFire)
                {
                    maxFire = fireP;
                    maxShip = ship;
                }
            }
            if (maxShip == null)
                return (false, null);
            return (true, maxShip);
        }
    }
}
