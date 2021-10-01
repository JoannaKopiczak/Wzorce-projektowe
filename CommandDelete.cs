using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep
{
    class CommandDelete :ICommand
    {
        private string name;
        private DataBase receiver;
        public CommandDelete(string name,DataBase receiver)
        {
            this.name = name;
            this.receiver = receiver;

        }
        public  void execute()
        {
            receiver.Delete(name);
        }
    }
}
