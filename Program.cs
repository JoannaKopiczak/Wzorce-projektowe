using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 
Temat projektu: Aplikacja konsolowa do zarządzania towarem w sklepie.

Wzorce:

-Factory Method (różne produkty)

-Command (dodaj nowy produkt, usuń produkt, zaktualizuj dane)

-State (produkt niedostępny, produkt juz wkrótce dostępny, produkt dostępny)

-Singleton (baza danych)

Język programowania: C#
  
 */
namespace Sklep
{
    class Program
    {
        
        static State CreateState(string state_str)
        {
            State state = new StateAvailable();
            if (state_str.Equals("n"))
            {
                state = new StateInavailable();
            }
            else if (state_str.Equals("w"))
            {
                state = new StateAvailableSoon();
            }
           

            return state;
        }

        static IProduct CreateProduct(State prev_state=null)
        {
            Creator creator = null;

            Console.WriteLine("Podaj nazwę: ");
            string pname = Console.ReadLine();
            Console.WriteLine("Podaj cenę: ");
            float price = float.Parse(Console.ReadLine());
            Console.WriteLine("Podaj znizkę: ");
            float discount = float.Parse(Console.ReadLine());
            State state;
            if (prev_state == null)
            {
                Console.WriteLine("Podaj stan (d = dostpeny, n = niedostepny, w = dostepny wkrotce): ");
                state = CreateState(Console.ReadLine());
            }
            else
            {
               Console.WriteLine("Zmienic stan? (t/n): ");
               string change = Console.ReadLine();
                if (change == "t")
                    state = prev_state.ChangeState();
                else
                    state = prev_state;
            }
    
            if (discount == 0)
            {
                creator = new CreatorStandardProduct(pname, price, state);
            }
            else
            {
                creator = new CreatorPromoProduct(pname, price, state, discount);
            }

            return creator.FactoryMethod();

        }



        static void Main(string[] args)
        {
            string name;

            DataBase db = DataBase.GetInstance();
            

            while (true) 
            {
                Console.WriteLine("Sklep odzieżowy");
                Console.WriteLine("l - lista produktów");
                Console.WriteLine("s - szukaj produktów");
                Console.WriteLine("d - dodaj produkt");
                Console.WriteLine("a - aktualizuj produkt");
                Console.WriteLine("u - usuń produkt");
                Console.WriteLine("w - wyjscie");

                Console.Write("> ");
                string k = Console.ReadLine();

                if (k.Equals("l"))
                {
                    db.Print();
                }
                else if (k.Equals("s")) 
                {
                    if(db.Count()==0)
                    {
                        Console.WriteLine("Baza jest pusta");
                        continue;
                    }

                    Console.WriteLine("Podaj nazwę lub jej część: ");
                    name = Console.ReadLine();
                    db.Print(name);
                }
                else if (k.Equals("d"))
                {

                    try
                    {
                       
                        IProduct p = CreateProduct();
                        CommandInsert ci = new CommandInsert(p,db);
                        ci.execute();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                       
                    }

            

                }
                else if (k.Equals("a"))
                {

                    if (db.Count() == 0)
                    {
                        Console.WriteLine("Baza jest pusta");
                        continue;
                    }

                    Console.WriteLine("Podaj nazwę produktu do aktualizacji: ");
                    name = Console.ReadLine();

                    IProduct pa = db.SelectOne(name);
                    if (pa != null)
                    {
                        pa = CreateProduct(pa.ProductState);
                        CommandUpdate cu = new CommandUpdate(name, pa, db);
                        cu.execute();
                    }
                }
                else if(k.Equals("u"))
                {

                    if (db.Count() == 0)
                    {
                        Console.WriteLine("Baza jest pusta");
                        continue;
                    }

                    Console.WriteLine("Podaj nazwę: ");
                    name = Console.ReadLine();
                    CommandDelete cd = new CommandDelete(name, db);
                    cd.execute();
                }

                else if(k.Equals("w"))
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Nieznane polecenie");
                }

                

            }

        }
    }
}
