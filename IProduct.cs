using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep
{
    interface IProduct
    {

        string Name { get; set; }
        float Price { get; set; }
        State ProductState { get; set; }
        void Print();

    }
}
