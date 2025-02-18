namespace UFO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pont a = new Pont(10, 2, 3);
            Pont b = new Pont(5, 2, 5);
            Pont c = new Pont(0, 2, 5);
            Pont d = new Pont(1, 2, 5);
            Pont e = new Pont(-3, 2, 5);
            Pont f = new Pont(1, 3, 5);

            Console.WriteLine(a.Tavolsag(b));
            Console.WriteLine(Pont.Tavolsag(a, b));

            List<Pont> pontok = new List<Pont>();
            pontok.Add(a);
            pontok.Add(b);
            pontok.Add(c);
            pontok.Add(d);
            pontok.Add(e);
            pontok.Add(f);

            Gomb g = new Gomb(f, 5);

            int db = 0;

            for (int i = 0; i < pontok.Count; i++)
            {
                if (g.Tartalmazza(pontok[i]))
                {
                    db++;
                }
            }
            Console.WriteLine(db);
        }
    }
}
