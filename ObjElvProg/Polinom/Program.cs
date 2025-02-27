namespace Polinom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Polinom test = new Polinom(1, 2, 3);
                Console.WriteLine(test.Value(2));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
    }
}
