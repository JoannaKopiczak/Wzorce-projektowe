using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep
{
    class CommandInsert:ICommand
    {
        private IProduct product;
        private DataBase receiver;
        public CommandInsert(IProduct p, DataBase receiver)
        {
            product = p;
            this.receiver = receiver;
        }
        public void execute()
        {
            receiver.Insert(product);
        }

    }
}
