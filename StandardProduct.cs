using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep
{
    class StandardProduct:IProduct
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public State ProductState { get; set; }

        public StandardProduct(string name, float price, State state)
        {
            Name = name;
            Price = price;
            ProductState = state;
        }


        public virtual void Print()
        {
            Console.WriteLine(Name + ", " + Price + ", " + ProductState.GetState());
        }
    }
}
