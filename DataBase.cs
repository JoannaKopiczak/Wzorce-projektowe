using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep
{
    class DataBase
    {

        private List<IProduct> products = new List<IProduct>();

        private DataBase() { }
        private static DataBase _instance;

        public static DataBase GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataBase();
            }
            return _instance;
        }



        public  void Print()
        {
            Console.WriteLine("------------------------------------------------");

            if (products.Count == 0)
            {
                Console.WriteLine("Baza jest pusta");

            }
            else
            {

                foreach (IProduct p in products)
                    p.Print();
            }
            Console.WriteLine("------------------------------------------------");

        }

        public  int Count()
        {
            return products.Count();
        }
        public  void Print(string name)
        {
            Console.WriteLine("------------------------------------------------");
            if (products.Count == 0)
            {
                Console.WriteLine("Baza jest pusta");

            }
            else
            {
                List<IProduct> found = Select(name);
                if (found.Count == 0)
                {
                    Console.WriteLine("Nie znaleziono produktow");

                }
                else
                {


                    foreach (IProduct p in found)
                        p.Print();
                }
            }
            Console.WriteLine("------------------------------------------------");

        }


        public IProduct SelectOne(string name)
        {
            foreach (IProduct p in products)
            {
                if (p.Name.Equals(name))
                    return p;

            }
            return null;
        }

        public  List<IProduct> Select(string name)
        {
            List<IProduct> results = new List<IProduct>();

            foreach (IProduct p in products)
            {
                if (p.Name.Contains(name))
                    results.Add(p);

            }
            return results;
        }

        public  bool Insert(IProduct product)
        {
            products.Add(product);
            return true;
        }

        public  bool Delete(string name)
        {
            foreach (IProduct p in products)
            {
                if (p.Name == name)
                {
                    products.Remove(p);
                    return true;
                }

            }
            return false;
        }

        public  bool Update(string name, IProduct newProduct)
        {
            for(int i=0;i<products.Count;i++)
            {
                
                if (products[i].Name == name)
                {
                    products[i] = newProduct;
                    return true;
                }

            }
            return true;
        }

    }
}
