using static Allatok.Allat;

namespace Allatok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Allat allat = new Allat();
            Tehen tehen = new Tehen();
            Csirke csirke = new Csirke();

            Console.WriteLine("Tehen labainak szama: " + tehen.GetLabak());
            Console.WriteLine("Csirke labainak szama: " + csirke.GetLabak());
            Console.WriteLine("Tehen beszel: ");
            tehen.Beszel();
            Console.WriteLine("Csirke beszel: ");
            csirke.Beszel();

            Allat tehenAllat = new Tehen();
            Console.WriteLine(tehenAllat.Beszel());
        }
    }
}
