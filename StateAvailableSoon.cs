using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep
{
    class StateAvailableSoon:State
    {
        public override string GetState() { return "dostepny wkrotce"; }


        public override State ChangeState()
        {
            return new StateAvailable();
        }
    }
}
