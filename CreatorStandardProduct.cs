using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep
{
    class CreatorStandardProduct : Creator
    {
        string name;
        float price;
        State state;
        public CreatorStandardProduct(string name, float price, State state)
        {
            this.name = name;
            this.price = price;
            this.state = state;
        }
        public override IProduct FactoryMethod()
        {
            return new StandardProduct(name, price, state);
        }
    }
}
