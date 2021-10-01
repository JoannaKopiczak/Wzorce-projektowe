using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep
{
    class StateAvailable:State
    {
        public override string GetState() { return "dostepny"; }


        public override State ChangeState()
        {
            return new StateInavailable();
        }

    }
}
