using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    class Invoice
    {
        public string CustomerName { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();

        public int GetTotal()
        {
            return Items.Sum(item => item.Price);
        }
    }

    class Item
    {
        public string Code { get; set; }
        public int Price { get; set; }
    }

    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the input file path.");
            return;
        }

        string filePath = args[0];
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        int totalRevenue = 0;
        foreach (string line in File.ReadLines(filePath))
        {
            var parts = line.Split(' ');
            if (parts.Length < 2) continue;

            Invoice invoice = new Invoice { CustomerName = parts[0] };
            for (int i = 1; i < parts.Length - 1; i += 2)
            {
                invoice.Items.Add(new Item { Code = parts[i], Price = int.Parse(parts[i + 1]) });
            }
            totalRevenue += invoice.GetTotal();
        }

        Console.WriteLine(totalRevenue);
    }
}
