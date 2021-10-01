using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep
{
    class PromoProduct:IProduct
    {

        public string Name { get; set; }
        public float Price { get; set; }
        public State ProductState { get; set; }
        public float Discount { get; set; }

        public PromoProduct(string name, float price, State state,float discount)
        {

            Name = name;
            Price = price;
            ProductState = state;
            Discount = discount;

        }

        public  void Print()
        {
            Console.WriteLine(Name + ", " + Price + ", " + ProductState.GetState() +", znizka = "+Discount);
        }

    }
}
