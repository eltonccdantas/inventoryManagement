using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventoryManagement
{
    [System.Serializable]
    class Course : Product, Istock
    {
        public string author;
        private int vacancies;

        public Course(string name, float price, string author)
        {
            this.name = name;
            this.price = price;
            this.author = author;
            
        }

        public void Display()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"By {author}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Remaining vacancies: {vacancies}");
            Console.WriteLine("===================================");

        }

        public void StockPlacement()
        {

            Console.WriteLine($"Add vacancies {name}");
            Console.WriteLine("How many do you want to add? : ");
            int vacanciesadded = int.Parse(Console.ReadLine());
            vacancies += vacanciesadded;
            Console.WriteLine("Vacancies added successfully.");
            Console.ReadLine();
        }

        public void StockRemoval()
        {

            Console.WriteLine($"Remove vacancies {name}");
            Console.WriteLine("How many do you want to remove? : ");
            int vacanciesadded = int.Parse(Console.ReadLine());
            vacancies -= vacanciesadded;
            Console.WriteLine("Vacancies removed successfully.");
            Console.ReadLine();
        }
    }
}
