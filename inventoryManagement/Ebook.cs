using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventoryManagement
{
    [System.Serializable]
    class Ebook : Product, Istock
    {
        public string writer;
        private int sales;

        public Ebook(string name, float price, string writer)
        {
            this.name = name;
            this.price = price;
            this.writer = writer;
            
        }

        public void Display()
        {

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"By {writer}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Sales: {sales}");
            Console.WriteLine("===================================");
        }

        public void StockPlacement()
        {
            Console.WriteLine("This funcition is not avaliable to digital produtcs.");
            Console.ReadLine();
        }

        public void StockRemoval()
        {
            Console.WriteLine($"Add sales to the E-Book {name}");
            Console.WriteLine("How many do you want to add? : ");
            int sales = int.Parse(Console.ReadLine());
            sales += sales;
            Console.WriteLine("Added successfully.");
            Console.ReadLine();
        }
    }
}
