using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace inventoryManagement
{
    class Program
    {
        static List<Istock> products = new List<Istock>();
        enum Menu { List = 1, Add, Remove, In, Out, Quit }
        static void Main(string[] args)
        {
            Load();
            bool wannaQuit = false;
            while (wannaQuit == false)
            {

                Console.WriteLine("Inventory Management");
                Console.WriteLine("1 - List products\n2 - Add a product\n3 - Remove a product\n4 - Stock Placement\n5 - Stock Removal\n6 - Quit");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);
                
                if (opInt > 0 && opInt < 7)
                {

                    Menu option = (Menu)opInt;


                    switch (option)
                    {
                        case Menu.List:
                            List();
                            break;
                        case Menu.Add:
                            Registration();
                            break;
                        case Menu.Remove:
                            Remove();
                            break;
                        case Menu.In:
                            Placement();
                            break;
                        case Menu.Out:
                            Removal();
                            break;
                        case Menu.Quit:
                            wannaQuit = true;
                            break;

                    }//end of switch
                }//end of if
                
                else
                {
                    wannaQuit = true;
                }
                Console.Clear();
            }//end of while
        }// end of main

        static void List()
        {
            Console.WriteLine("List of products");
            int i = 0;
            foreach(Istock product in products)
            {
                Console.WriteLine("ID: " + i);
                product.Display();
                i++;
            }
            Console.ReadLine();
        }

        static void Remove()
        {
            List();
            Console.WriteLine("Type the ID you want to remove: ");
            int id = int.Parse(Console.ReadLine());
            if(id >= 0 && id < products.Count)
            {
                products.RemoveAt(id);
                Save();
            }
        }

        static void Placement()
        {
            List();
            Console.WriteLine("Type the ID you want to add: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < products.Count)
            {
                products[id].StockPlacement();
                Save();
            }
        }

        static void Removal()
        {
            List();
            Console.WriteLine("Type the ID you want to register a removal: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < products.Count)
            {
                products[id].StockRemoval();
                Save();
            }
        }

        static void Registration()
        {
            Console.WriteLine("Product registration");

            Console.WriteLine("1 - Phisical Product\n2 - Ebook\n3 - Course");
            string opStr = Console.ReadLine();
            int optionInt = int.Parse(opStr);
            switch (optionInt)
            {
                case 1:
                    PPRegistration();
                    break;
                case 2:
                    EbookRegistration();
                    break;
                case 3:
                    CourseRegistration();
                    break;

            }//end of switch
        }//end of registration



            static void PPRegistration()//Physical Product registration
            {
                Console.WriteLine("Physical Product Registration");
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Price: ");
                float price = float.Parse(Console.ReadLine());
                Console.WriteLine("Shipping: ");
                float shipping = float.Parse(Console.ReadLine());
                PhysicalProduct pp = new PhysicalProduct(name, price, shipping);
                products.Add(pp);
                Save();
            }

            static void EbookRegistration()//Ebook registration
            {
                Console.WriteLine("Ebook Registration");
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Price: ");
                float price = float.Parse(Console.ReadLine());
                Console.WriteLine("Writer: ");
                string writer = Console.ReadLine();

                Ebook eb = new Ebook(name, price, writer);
                products.Add(eb);
                Save();
                
            }

            static void CourseRegistration()//Ebook registration
            {
            Console.WriteLine("Course Registration");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Price: ");
            float price = float.Parse(Console.ReadLine());
            Console.WriteLine("Taught by: ");
            string teacher = Console.ReadLine();

            Ebook cs = new Ebook(name, price, teacher);
            products.Add(cs);
            Save();

            }

        static void Save()
        {
            FileStream stream = new FileStream("products.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, products);

            stream.Close();
        }

        static void Load()
        {
            FileStream stream = new FileStream("products.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
               products = (List<Istock>)encoder.Deserialize(stream);

                if(products == null)
                {
                    products = new List<Istock>();
                }
            }
            catch(Exception e)
            {
                products = new List<Istock>();
            }

            stream.Close();
        }

    }// end of class program
}
