namespace Adagolo
{
    internal class Program
    {
        struct SAdagolo
        {
            public double max;
            public double adag;
            public double akt;
        }
        static void Main(string[] args)
        {
            Adagolo s = new Adagolo(100.0, 30.0);
            Console.WriteLine(s.Ures());
            s.Feltolt();
            Console.WriteLine(s.Ures());

            s.nyom();
            s.nyom();
            s.nyom();
            Console.WriteLine(s.Ures());
            s.nyom();
            Console.WriteLine(s.Ures());


        }
    }
}
