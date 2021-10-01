using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep
{
    class CreatorPromoProduct : Creator
    {
        string name;
        float price;
        State state;
        float discount;

        public CreatorPromoProduct(string name, float price, State state,float discount)
        {
            this.name = name;
            this.price = price;
            this.state = state;
            this.discount = discount;
        }
        public override IProduct FactoryMethod()
        {
            return new PromoProduct( name,  price,  state, discount);
        }

    }
}
