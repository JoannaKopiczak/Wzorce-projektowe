using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep
{
    class CommandUpdate: ICommand
    {
        private string name;
        private IProduct newProduct; 
        private DataBase receiver;
        public CommandUpdate(string name, IProduct newProduct, DataBase receiver)
        {
            this.name = name;
            this.newProduct = newProduct;
            this.receiver = receiver;

        }
        public void execute()
        {
            receiver.Update(name, newProduct);
        }
    }
}
