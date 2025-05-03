namespace HF9
{
    class Planet
    {
        public string name;
        private List<Starship> ships;

        public Planet(string name)
        {
            this.name = name;
            this.ships = new List<Starship>();
        }

        public void Defends(Starship s)
        {
            if (ships.Contains(s))
                throw new Exception("Ship already defends this planet");
            ships.Add(s);
        }

        public void Leaves(Starship s)
        {
            if (!ships.Contains(s))
                throw new Exception("Ship does not defend this planet");
            ships.Remove(s);
        }

        public int ShipCount()
        {
            return ships.Count;
        }

        public int ShieldSum()
        {
            int sum = 0;
            foreach (var ship in ships)
            {
                sum += ship.GetShield();
            }
            return sum;
        }

        public (bool, double, Starship) MaxFireP()
        {
            if (ships.Count == 0)
                return (false, 0, null);
            Starship maxShip = ships[0];
            double maxFire = maxShip.FireP();
            foreach (var ship in ships)
            {
                double fire = ship.FireP();
                if (fire > maxFire)
                {
                    maxFire = fire;
                    maxShip = ship;
                }
            }
            return (true, maxFire, maxShip);
        }

        public List<Starship> GetShips()
        {
            return ships;
        }
    }
}