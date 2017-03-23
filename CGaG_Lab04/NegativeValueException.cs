using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGaG_Lab04 {
    class NegativeValueException : Exception {

        public NegativeValueException( ) : base("This variable can not be negative") { }

    }
}
