using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventoryManagement
{
    [System.Serializable]
    class PhysicalProduct : Product, Istock
    {
        public float shipping;
        private int stock;

        public PhysicalProduct(string name, float price, float shipping)
        {
            this.name = name;
            this.price = price;
            this.shipping = shipping;
          
        }

        public void Display()//displays info about the product.
        {

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Shipping cost: {shipping}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Remaining in stock: {stock}");
            Console.WriteLine("===================================");
        }

        public void StockPlacement()//add items to stock
        {
            Console.WriteLine($"Stock Placement {name}");
            Console.WriteLine("How many do you want to add? : ");
            int splacement = int.Parse(Console.ReadLine());
            stock += splacement;
            Console.WriteLine("Stock placement registered.");
            Console.ReadLine();

        }

        public void StockRemoval()//remove items to stock
        {

            Console.WriteLine($"Stock Removal {name}");
            Console.WriteLine("How many do you want to remove? : ");
            int sremoval = int.Parse(Console.ReadLine());
            stock -= sremoval;
            Console.WriteLine("Stock removal registered.");
            Console.ReadLine();
        }
    }
}
