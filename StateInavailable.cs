using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep
{
    class StateInavailable:State
    {
        public override string GetState() { return "niedostepny"; }


        public override State ChangeState()
        {
            return new StateAvailableSoon();
        }

    }
}
