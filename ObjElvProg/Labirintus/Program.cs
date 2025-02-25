namespace Labirintus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pozicio p = new Pozicio(7, 0);
            Pozicio le = new Pozicio(0, 1);
            Console.WriteLine(Pozicio.Osszeadas(p, le));
            Console.WriteLine(p + le);
        }
    }
}
